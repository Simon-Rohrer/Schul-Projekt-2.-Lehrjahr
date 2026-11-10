using Restaurant;

class Program
{
    static void Main(string[] args)
    {
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
        // Alle Gerichte lesen
        app.MapGet("/api/essen", () =>
        {
            using var connection = new DataConnect().GetConnection();
            var liste = new DataRead().GetAlleGerichte(connection);
            return Results.Ok(liste);
        });

        // Neues Gericht speichern
        app.MapPost("/api/essen", (Gericht gericht) =>
        {
            using var connection = new DataConnect().GetConnection();
            new DataWrite(connection, gericht.Name, gericht.Preis, gericht.Vegetarisch);
            return Results.Ok();
        });

        // Gericht ändern
        app.MapPut("/api/essen/{id}", (int id, Gericht gericht) =>
        {
            using var connection = new DataConnect().GetConnection();
            new DataUpdate(connection, id, gericht.Name, gericht.Preis, gericht.Vegetarisch);
            return Results.Ok();
        });

        // Gericht löschen
        app.MapDelete("/api/essen/{id}", (int id) =>
        {
            using var connection = new DataConnect().GetConnection();
            new DataDelete(connection, id);
            return Results.Ok();
        });

        // Bestellung speichern
        app.MapPost("/api/bestellung", (List<Bestellposition> positionen) =>
        {
            using var connection = new DataConnect().GetConnection();
            new DataBestellung(connection, positionen);
            return Results.Ok();
        });

        app.Run("http://localhost:5000");
    }
}
