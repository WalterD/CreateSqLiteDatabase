using CreateSqLiteDatabase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


// 1. Install Microsoft.EntityFrameworkCore.Tools Nugget package.
// 2. Install Microsoft.EntityFrameworkCore.Sqlite Nugget package.
// 3. Run in the Package Manager console: Add-Migration InitialCreation -o Data/Database/Migrations
// 4. Run in the Package Manager console: Update-Database

// The process will create MySQLiteDatabase.db file in /Data/Database folder.
// Table __EFMigrationsHistory will be added to the database file. The table will contain 2 columns, MigrationId and ProductVersion.
// The process will also add two files in /Data/Database/Migrations folder.

var builder = Host.CreateApplicationBuilder();

builder.Configuration
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false);




// get connection string from configuration
var section = builder.Configuration.GetSection("ConnectionStrings");
var connectionString = section.GetValue<string>("MyDatabaseConnectionString");

// Add DbContext.
builder.Services.AddDbContext<MyDatabaseDbContext>(options => options.UseSqlite(connectionString));

// Build application.
var app =  builder.Build();




Console.WriteLine("Hello, World!");