using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using social_events_manager.Data;
using social_events_manager.Middlewares;
using social_events_manager.Modules.Attendees;
using social_events_manager.Modules.Attendees.Interfaces;
using social_events_manager.Modules.Auth.Interfaces;
using social_events_manager.Modules.Auth.Models;
using social_events_manager.Modules.Auth.Services;
using social_events_manager.Modules.Locations;
using social_events_manager.Modules.Locations.Interfaces;
using social_events_manager.Modules.SocialEvents;
using social_events_manager.Modules.SocialEvents.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// override JWT signing key
builder.Configuration["JWT:SigningKey"] = Environment.GetEnvironmentVariable("JWT_SIGNING_KEY");

// --- Configuración de la cadena de conexión ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
connectionString = string.Format(
    $"Server={dbHost},{dbPort};Database={dbName};User Id={dbUser};Password={dbPassword};TrustServerCertificate=True;"
);

// --- Servicios base ---
builder
    .Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Social Event Manager", Version = "v1" });
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer",
        }
    );
    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    },
                },
                new string[] { }
            },
        }
    );
});
builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddHealthChecks();

// --- CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAllOrigins",
        policyBuilder =>
            policyBuilder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .SetIsOriginAllowed(_ => true)
    );
});

// --- Base de datos y autenticación ---
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder
    .Services.AddIdentity<AppUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 8;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme =
            options.DefaultChallengeScheme =
            options.DefaultForbidScheme =
            options.DefaultScheme =
            options.DefaultSignInScheme =
            options.DefaultSignOutScheme =
                JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
            ),
        };
    });

// --- Inyección de dependencias ---
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISocialEventRepository, SocialEventRepository>();
builder.Services.AddScoped<ISocialEventService, SocialEventService>();
builder.Services.AddScoped<IAttendeeRepository, AttendeeRepository>();
builder.Services.AddScoped<IAttendeeService, AttendeeService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

// --- Migraciones automáticas ---
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

// --- Middlewares ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(option =>
    {
        option.RouteTemplate = "docs/{documentName}/swagger.json";
    });
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/docs/v1/swagger.json", "Social Event Manager API v1");
        option.RoutePrefix = "docs";
    });
}

app.UseExceptionHandler();
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/");
app.MapControllers();

app.Run();
