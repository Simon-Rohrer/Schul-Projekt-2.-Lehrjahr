using System;
using MySql.Data.MySqlClient;

namespace Restaurant
{
    internal class dataWrite
    {
        public void DataWrite(MySqlConnection con)
        {
            string cmdString = "INSERT INTO Speisekarte (name, preis, vegetarisch) VALUES (@name, @preis, @vegetarisch)";
            MySqlCommand cmd = new MySqlCommand(cmdString, con);
            cmd.Parameters.AddWithValue("@name");
            cmd.Parameters.AddWithValue("@preis");
            cmd.Parameters.AddWithValue("@vegetarisch");
            cmd.ExecuteNonQuery();
        }
    }
}
