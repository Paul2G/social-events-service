using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using web_api_learning.Data;
using web_api_learning.Modules.Attendees.Interfaces;
using web_api_learning.Modules.Attendees.Repositories;
using web_api_learning.Modules.Locations.Interfaces;
using web_api_learning.Modules.Locations.Repositories;
using web_api_learning.Modules.SocialEvents.Interfaces;
using web_api_learning.Modules.SocialEvents.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ??
                       builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.MaxDepth = 2;
});

builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(connectionString); });

builder.Services.AddScoped<ISocialEventRepository, SocialEventRepository>();
builder.Services.AddScoped<IAttendeeRepository, AttendeeRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapHealthChecks("/");

app.MapControllers();

app.Run();