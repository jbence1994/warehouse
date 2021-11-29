# Warehouse

Netsurf Távközlési Szolgáltató Kft. stock management application.

This project was bootstrapped with `dotnet new angular` .NET command.

## Set up project locally

### Download third-party dependencies

### .NET

In the root of the project directory execute this command in command line or bash terminal:

```bash
dotnet restore
```

### Angular

In the root of the `ClientApp` directory execute this command in command line or bash terminal:

```bash
npm install
```

### Initialize user secrets

The user secrets id is already set in the `Warehouse.csproj` with the value:

`<UserSecretsId>warehouse-secrets</UserSecretsId>`

#### Initialize database connection string

In the root of the project directory execute this command in command line or bash terminal:

```bash
dotnet user-secrets set "ConnectionStrings:Default": "SERVER=127.0.0.1;DATABASE=warehouse;UID=[YOUR_MYSQL_USERNAME];PASSWORD=[YOUR_MYSQL_PASSWORD];PORT=3306;"
```

This command will create a file called `secrets.json` that stores the secret on local machine.

#### The location of `secrets.json` on a Windows machine:

`C:\Users\[YOUR_USERNAME]\AppData\Roaming\Microsoft\UserSecrets\warehouse-api-secrets`

#### The location of `secrets.json` on a UNIX machine:

`~/.microsoft/usersecrets/warehouse-api-secrets`

To verify a user secret has been added to the project, in the root of the `Warehouse.Api` project directory execute this command in command line or bash terminal:

```bash
dotnet user-secrets list
```

#### Note that: There is an issues with special characters (e.g.: exclamation mark, etc.) when setting user secrets in command line or bash terminal. If your secrets contains special characters, just set it except the special character then update the `secrets.json` manually to the correct value.

### Build database schema

In the root of the project directory execute this command in command line or bash terminal:

```bash
dotnet ef database update
```

### Run project

In the root of the project directory execute this command in command line or bash terminal:

```bash
dotnet run
```

Open [https://localhost:5001](https://localhost:5001) to view it in the browser.
