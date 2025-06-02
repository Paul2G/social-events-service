# Social Events Service

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)

## Overview

**Social Events Service** is a backend microservice written in C# (.NET 8) designed to manage social events, locations, and attendees. The service enforces strict ownership: only the user who created an event, location, or attendee record can modify or delete it. Authentication is required for all modifying operations.

## Features

- RESTful API with dedicated controllers for:
  - **Social Events** (`/api/social-events`)
  - **Locations** (`/api/locations`)
  - **Attendees** (`/api/attendees`)
- User authentication and registration endpoints
- Only resource creators have permission to modify or delete their data
- Query events by date, location, or organizer
- Manage event participants (RSVP, invitations, removals)
- Docker support for easy deployment

## Ownership Model

All data (events, locations, attendees) can only be created or modified by the user who originally created it. Other users have read-only access to these resources.

## Authentication

Authentication is required for any action that creates, updates, or deletes resources. Two endpoints are provided:

- `POST /auth/register` — Register a new user account
- `POST /auth/login` — Authenticate and receive an access token

Include your access token in the `Authorization` header as a Bearer token for all protected routes.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/) (optional, for containerization)

### Running Locally

1. **Clone the repository:**

   ```sh
   git clone https://github.com/Paul2G/social-events-service.git
   cd social-events-service
   ```

2. **Restore dependencies & build:**

   ```sh
   dotnet restore
   dotnet build
   ```

3. **Run the service:**

   ```sh
   dotnet run
   ```

   The service will start and listen on the default port (usually 5000 or 8080).

### Running with Docker

1. **Build the Docker image:**

   ```sh
   docker build -t social-events-service .
   ```

2. **Run the container:**

   ```sh
   docker run -p 8080:8080 social-events-service
   ```

   Adjust the port mapping as needed.

## API Endpoints

### Authentication

- `POST /auth/register` — Register a new user
- `POST /auth/login` — User login

### Social Events

- `GET /api/social-events` — List all social events
- `GET /api/social-events/{id}` — Get a social event by ID
- `POST /api/social-events` — Create a new event
- `PUT /api/social-events/{id}` — Update an event
- `DELETE /api/social-events/{id}` — Delete an event

### Locations

- `GET /api/locations` — List all locations
- `GET /api/locations/{id}` — Get a location by ID
- `POST /api/locations` — Create a new location
- `PUT /api/locations/{id}` — Update a location
- `DELETE /api/locations/{id}` — Delete a location

### Attendees

- `GET /api/attendees` — List all attendees
- `GET /api/attendees/{id}` — Get an attendee by ID
- `POST /api/attendees` — Add an attendee
- `PUT /api/attendees/{id}` — Update attendee details
- `DELETE /api/attendees/{id}` — Remove attendee

> ⚠️ **Note:** All POST, PUT, and DELETE operations require authentication. Only the creator of a resource may modify or delete it.

## Configuration

Configuration options (e.g., database connection strings, environment variables) can be set in the `appsettings.json` file or via environment variables.

## Contributing

Contributions are welcome! Please open issues or submit pull requests for bug fixes, improvements, or new features.

1. Fork the repository
2. Create a new branch (`git checkout -b feature/my-feature`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature/my-feature`)
5. Open a pull request

## License

This project is licensed under the [MIT License](LICENSE).

## Contact

For questions or support, please open an issue or contact [Paul2G](https://github.com/Paul2G).
