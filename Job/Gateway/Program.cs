using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Add Ocelot
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("ocelot.json")
                            .AddEnvironmentVariables()
                            .Build();

// Add services to the container.
builder.Services.AddSwaggerForOcelot(configuration);
builder.Services.AddOcelot(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerForOcelotUI(opt =>
    {
        opt.PathToSwaggerGenerator = "/swagger/docs";

    });
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseOcelot().Wait();

app.Run();
