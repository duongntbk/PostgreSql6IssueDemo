This is a sample app for my blog post at the link below.

[https://duongnt.com/datetime-net6-postgresql](https://duongnt.com/datetime-net6-postgresql)

# Usage

## Set up the test database

You need a PostgreSQL database to run the code in this repository. It can either be a Docker image, a local server, or a remote server. Please update the connection string in [here](/Common/Constants.cs) with the correct credentials.

Restore the database and populate it with test data by running the following command inside the `DbSetup` folder (you might have to install the [dotnet ef](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) tool).
```
dotnet ef database update
```

## Verify that the code in .NET Core 3.1 works

Run the following command inside the `Net3.1` folder.
```
dotnet run
```

You should see the following result.
```
Success...
```

## Reproduce the error in .NET 6

Running the following command inside the `Net6` folder.
```
dotnet run
```

You should see the following error.
```
Unhandled exception. Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while saving the entity changes. See the inner exception for details.
 ---> System.InvalidCastException: Cannot write DateTime with Kind=Local to PostgreSQL type 'timestamp with time zone', only UTC is supported. Note that it's not possible to mix DateTimes with different Kinds in an array/range. See the Npgsql.EnableLegacyTimestampBehavior AppContext switch to enable legacy behavior.
```

## Verify the fix

Still inside the `NET 6` folder, run the following command.
```
dotnet run fixed
```

Or

```
dotnet run legacy
```

You should see the following result.
```
Success...
```

# License

MIT License

https://opensource.org/licenses/MIT