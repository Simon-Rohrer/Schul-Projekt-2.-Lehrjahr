using System;
using MySql.Data.MySqlClient;

namespace Restaurant
{
    // Neues Gericht speichern
    internal class DataWrite
    {
        public DataWrite(MySqlConnection con, string name, decimal preis, bool vegetarisch)
        {
            string cmdString = "INSERT INTO Speisekarte (name, preis, vegetarisch) VALUES (@name, @preis, @vegetarisch)";
            MySqlCommand cmd = new MySqlCommand(cmdString, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@preis", preis);
            cmd.Parameters.AddWithValue("@vegetarisch", vegetarisch);
            cmd.ExecuteNonQuery();
        }
    }

    // Ein gewähltes Gericht mit Menge (kommt vom Frontend)
    public record Bestellposition(int SpeiseId, int Menge);

    // Bestellung speichern: erst die Bestellung, dann jede Position dazu
    internal class DataBestellung
    {
        public DataBestellung(MySqlConnection con, List<Bestellposition> positionen)
        {
            MySqlCommand bestellCmd = new MySqlCommand("INSERT INTO Bestellung () VALUES ()", con);
            bestellCmd.ExecuteNonQuery();
            long bestellId = bestellCmd.LastInsertedId;

            foreach (Bestellposition position in positionen)
            {
                string cmdString = "INSERT INTO Bestellposition (bestellid, speiseid, menge) VALUES (@bestellid, @speiseid, @menge)";
                MySqlCommand cmd = new MySqlCommand(cmdString, con);
                cmd.Parameters.AddWithValue("@bestellid", bestellId);
                cmd.Parameters.AddWithValue("@speiseid", position.SpeiseId);
                cmd.Parameters.AddWithValue("@menge", position.Menge);
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Gericht ändern
    internal class DataUpdate
    {
        public DataUpdate(MySqlConnection con, int id, string name, decimal preis, bool vegetarisch)
        {
            string cmdString = "UPDATE Speisekarte SET name = @name, preis = @preis, vegetarisch = @vegetarisch WHERE speiseid = @id";
            MySqlCommand cmd = new MySqlCommand(cmdString, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@preis", preis);
            cmd.Parameters.AddWithValue("@vegetarisch", vegetarisch);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }

    // Gericht löschen
    internal class DataDelete
    {
        public DataDelete(MySqlConnection con, int id)
        {
            string cmdString = "DELETE FROM Speisekarte WHERE speiseid = @id";
            MySqlCommand cmd = new MySqlCommand(cmdString, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
