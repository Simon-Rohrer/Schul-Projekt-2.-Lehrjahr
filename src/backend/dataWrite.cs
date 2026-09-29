using System;
using MySql.Data.MySqlClient;

namespace Ueb_Datenbankzugriff
{
    internal class dataWrite
    {
        public void DataWrite(MySqlConnection con)
        {
            string cmdString = "INSERT INTO Kunde (Kundennummer, Vorname, Name) VALUES (@kundennummer, @vorname, @name)";
            MySqlCommand cmd = new MySqlCommand(cmdString, con);
            cmd.Parameters.AddWithValue("@kundennummer", "00038");
            cmd.Parameters.AddWithValue("@vorname", "Emil");
            cmd.Parameters.AddWithValue("@name", "Maier");
            cmd.ExecuteNonQuery();
        }
    }
}
