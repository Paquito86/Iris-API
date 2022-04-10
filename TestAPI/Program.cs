using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<NodeDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSwaggerGen(c => {

    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "IRIS by AlphaTech API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "IRIS API v1"));
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/", () => "¡Hello! -- IRIS by AlphaTech API v1");

#region Node Endpoints

app.MapGet("/node", async (NodeDb db) => await db.Nodes.ToListAsync());

app.MapPost("/node", async (NodeDb db, Node node) =>
{
    await db.Nodes.AddAsync(node);
    await db.SaveChangesAsync();
    return Results.Created($"/nodes/{node.Id}", node);
});

app.MapGet("/node/{id}", async (NodeDb db, int id) => await db.Nodes.FindAsync(id));

app.MapPut("/node/{id}", async (NodeDb db, Node updatenode, int id) =>
{
    var node = await db.Nodes.FindAsync(id);
    if (node is null) { return Results.NotFound(); }
    node.longId = updatenode.longId;
    node.DatacenterId = updatenode.DatacenterId;

    node.CPU = updatenode.CPU;
    node.CPUCores = updatenode.CPUCores;
    node.RAM = updatenode.RAM;

    node.Cost = updatenode.Cost;
    node.Provider = updatenode.Provider;

    node.Retired = updatenode.Retired;
    node.Pterodactyl = updatenode.Pterodactyl;
    node.Monolith = updatenode.Monolith;
    node.Docker = updatenode.Docker;
    node.Kubernetes = updatenode.Kubernetes;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/node/{id}", async (NodeDb db, int id) =>
{
    var node = await db.Nodes.FindAsync(id);
    if (node is null)
    {
        return Results.NotFound();
    }
    db.Nodes.Remove(node);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}