# Warehouse

Netsurf Távközlési Szolgáltató Kft. stock management application.

This project was bootstrapped with `dotnet new angular` .NET command.

## Set up project locally

### Download third-party dependencies

### Backend

### `dotnet restore`

In the root of the project directory execute this command in command line\
to download third-party dependencies to your local machine.

### Frontend

### `npm install`

In the root of the `ClientApp` directory execute this command in command line\
to download third-party dependencies to your local machine.

### Initialize user secrets

### `dotnet user-secrets set`

In the root of the project directory execute this command in command line\
to create directory for user secrets on your local machine

#### in a Windows machine:

`C:\Users\[YOUR_USERNAME]\AppData\Roaming\Microsoft\UserSecrets\warehouse-secrets`

#### in a UNIX machine:

`~/.microsoft/usersecrets/warehouse-secrets`

```bash
{
    dotnet user-secrets set "ConnectionStrings:Default": "SERVER=127.0.0.1;DATABASE=warehouse;UID=[YOUR_MYSQL_USERNAME];PASSWORD=[YOUR_MYSQL_PASSWORD];PORT=3306;"
}
```

### Build database schema

### `dotnet ef database update`

This command will automatically build the database schema with the test data to your local database from the migration scripts.

### `npm install`

This will install third-party dependencies for Angular.\
Use this command in the root of the ClientApp directory.

### Run project

### `dotnet run`

In the root of the project directory execute this command in command line to run the app in the development mode.

Open [https://localhost:5001](https://localhost:5001) to view it in the browser.
