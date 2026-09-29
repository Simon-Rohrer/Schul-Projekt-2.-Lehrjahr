using System;
using MySql.Data.MySqlClient;

namespace Ueb_Datenbankzugriff
{
    internal class dataWrite
    {
        public void DataWrite(MySqlConnection con)
        {
            string cmdString = "INSERT INTO Essensliste (Gericht, Preis, Vegetarisch) VALUES (@gericht, @preis, @vegetarisch)";
            MySqlCommand cmd = new MySqlCommand(cmdString, con);
            cmd.Parameters.AddWithValue("@gericht", "Pizze Margherita");
            cmd.Parameters.AddWithValue("@preis", 12.99);
            cmd.Parameters.AddWithValue("@vegetarisch", 1);
            cmd.ExecuteNonQuery();
        }
    }
}
