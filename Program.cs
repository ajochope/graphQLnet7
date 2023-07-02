using Microsoft.Extensions.Configuration;
using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using GraphQL;
using GraphQL.Server.Ui.Voyager;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// SQL Server DB Connection
// Console.WriteLine("--> Usando SQL Server DB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr")));

//GraphQL services for SQL Server DB
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

    // .AddMutationType<Mutation>()
    // .AddSubscriptionType<Subscription>()
    // .AddProjections()
    // .AddFiltering()
    // .AddSorting()
    // .AddInMemorySubscriptions()
    // .AddDataLoader<PlatformByIdDataLoader>()
    // .AddDataLoader<CommandByIdDataLoader>()
    // .AddDataLoader<PlatformByIdDataLoader>();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseRouting();

// GraphQL endpoint Mapping
app.MapControllers();
app.MapGraphQL(path: "/graphql");

// GraphQL Voyager .net 7
app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
{
    GraphQLEndPoint = "/graphql",
    Path = "/graphql-voyager"
});

app.Run();
