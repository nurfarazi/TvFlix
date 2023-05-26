## Getting Started

Use these instructions to get the project up and running.

### Prerequisites

You will need the following tools:

- [Visual Studio Code or Visual Studio](https://visualstudio.microsoft.com/vs/) (Latest)
- [.NET Core SDK 7.0](https://dotnet.microsoft.com/download/dotnet-core/7.0)
- [PostgreSQL](https://postgresapp.com/downloads.html)

### Knowledge That you must have

- [Repository pattern](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)
- [Specification pattern](https://en.wikipedia.org/wiki/Specification_pattern)

### Setup

Follow these steps to get your development environment set up, Open a command prompt in the repository folder :

- Clone the repository

#### PostgreSQL Server

Run the postgres server

#### Cache server

make sure you have installed docker and run this command, if you are running this redis server for the first time

`Docker run --name redis -p 6379:6379 redis`

once you added this docker container, next time you can simply restart `redis` container from docker GUI or command

### Run project

`dotnet run watch -p API`

## Swagger UI

After you run the project you can check this link
[developer Swagger UI](https://localhost:7272/swagger/index.html)

# Basic commands

### Database update

`dotnet ef database update -p Infrastructure -s API`

### Add new migration StoreDBContext

`dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations`

### Add New migration for identity 

`dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations -c AppIdentityDbContext`

### Remove migration

`dotnet ef migrations remove -p Infrastructure -s API`

### Database Drop

`dotnet ef database drop -p Infrastructure -s API`
