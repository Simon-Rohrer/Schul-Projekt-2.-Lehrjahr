using Ueb_Datenbankzugriff;

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
        using var con = connector.GetConnection();
        var reader = new dataRead();
        var liste = reader.GetAlleGerichte(con);
        return Results.Ok(liste);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fehler bei /api/essen: {ex.Message}");
        return Results.Problem(ex.Message);
    }
});

Console.WriteLine("Backend Server läuft auf http://localhost:5000 ...");
app.Run("http://localhost:5000");

namespace Ueb_Datenbankzugriff
{
    public class Gericht
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Preis { get; set; }
        public bool Vegetarisch { get; set; }
    }
}