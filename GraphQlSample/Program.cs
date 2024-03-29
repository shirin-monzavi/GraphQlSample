using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQlSample;
using GraphQlSample.Context;
using GraphQlSample.Contract;
using GraphQlSample.GraphQls.GraphQlSchema;
using GraphQlSample.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(opt =>
    opt.UseSqlServer("Server=.;Initial Catalog=GraphQlDb;Integrated Security=true;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;"));

builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<AppSchema>();
builder.Services.AddGraphQL(options => { options.EnableMetrics = false; })
        .AddGraphTypes(ServiceLifetime.Scoped)
        .AddDataLoader()
        .AddSystemTextJson(d => { }, s => { });

builder.Services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient("https://localhost:7051/graphql", new GraphQL.Client.Serializer.SystemTextJson.SystemTextJsonSerializer()));
builder.Services.AddScoped<OwnerConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseGraphQL<AppSchema>();
app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

app.MapControllers();

app.Run();
