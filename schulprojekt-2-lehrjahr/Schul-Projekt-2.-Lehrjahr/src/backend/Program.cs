using Restaurant;

var builder = WebApplication.CreateBuilder(args);

// CORS erlauben, damit das Frontend anfragen darf
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors();

// API
app.MapGet("/api/essen", () =>
{
    try
    {
        var connector = new dataConnect();
        var connection = connector.GetConnection();
        var reader = new dataRead();
        var liste = reader.GetAlleGerichte(connection);
        return Results.Ok(liste);
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Fehler bei /api/essen: {exception.Message}");
        return Results.Problem(exception.Message);
    }
});

Console.WriteLine("Backend Server läuft auf http://localhost:5000 ...");
app.Run("http://localhost:5000");

namespace Restaurant
{
    public class Gericht
    {
        dataConnect dataConnect = new dataConnect();
    }
}