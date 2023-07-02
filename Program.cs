using Microsoft.Extensions.Configuration;
using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

    // SQL Server DB Connection
    // Console.WriteLine("--> Usando SQL Server DB");
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr")));

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseRouting();

app.MapGet("/", () => "Hello World!");

app.Run();
