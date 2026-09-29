using System;
using MySql.Data.MySqlClient;

namespace Ueb_Datenbankzugriff
{
    internal class dataRead
    {
        public void DataRead(MySqlConnection con)
        {
            string cmdString = "SELECT * FROM Kunde";

            MySqlCommand cmd = new MySqlCommand(cmdString, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string kundennummer = Convert.ToString(reader["Kundennummer"]);
                    string vorname = Convert.ToString(reader["Vorname"]);
                    string name = Convert.ToString(reader["Name"]);

                    Console.WriteLine("{0} {1} {2}", kundennummer, vorname, name);
                }
            }
            else
            {
                Console.WriteLine("Keine Daten gefunden.");
            }
        }
    }
}
