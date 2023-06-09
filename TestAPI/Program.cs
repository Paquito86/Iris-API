using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TestAPI.Agents;
using TestAPI.Models;

var Title = "Iris API";
var Version = "v1";

var builder = WebApplication.CreateBuilder(args);
var connectionStr2 = builder.Configuration.GetConnectionString("Nodes") ?? "Data Source=Nodes.db";
var connectionStr1 = builder.Configuration.GetConnectionString("Keys") ?? "Data Source=Keys.db";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<NodeDb>(connectionStr1);
builder.Services.AddSqlite<KeyDb>(connectionStr2);
builder.Services.AddSwaggerGen(c => {

    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = Title, Version = Version });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "IRIS API v1"));
}

app.UseHttpsRedirection();

app.MapGet("/", () => $"¡Hello! | {Title} {Version} ");

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

#region SSH_Keys Endpoints

app.MapGet("/pubkey", async (KeyDb db) => await db.Keys.ToListAsync());

app.MapPost("/pubkey", async (KeyDb db, SSHPubKey key) =>
{
    await db.Keys.AddAsync(key);
    await db.SaveChangesAsync();
    return Results.Created($"/nodes/{key.Id}", key);
});

app.MapGet("/pubkey/{id}", async (KeyDb db, int id) => await db.Keys.FindAsync(id));

app.MapPut("/pubkey/{id}", async (KeyDb db, SSHPubKey updatekey, int id) =>
{
    var key = await db.Keys.FindAsync(id);
    if (key is null) { return Results.NotFound(); }
    key.Name = updatekey.Name;
    key.Workstation = updatekey.Workstation;
    key.Node_Id = updatekey.Node_Id;
    key.RSA = updatekey.RSA;
    
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/pubkey/{id}", async (KeyDb db, int id) =>
{
    var node = await db.Keys.FindAsync(id);
    if (node is null)
    {
        return Results.NotFound();
    }
    db.Keys.Remove(node);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.MapGet("/keygen", () =>
{
    SSHKeyAgent sshKeyAgent = new SSHKeyAgent();
    string result = sshKeyAgent.SSHGen("workstation00");
    return result;
});
#endregion

app.Run();