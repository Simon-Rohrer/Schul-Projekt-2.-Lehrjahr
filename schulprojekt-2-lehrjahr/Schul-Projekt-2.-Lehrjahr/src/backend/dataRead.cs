using System;
using MySql.Data.MySqlClient;

namespace Ueb_Datenbankzugriff
{
    internal class dataRead
    {
        public void DataRead(MySqlConnection con)
        {
            string cmdString = "SELECT * FROM Essensliste";

            MySqlCommand cmd = new MySqlCommand(cmdString, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string gericht = Convert.ToString(reader["Gericht"]);
                    string preis = Convert.ToString(reader["Preis"]);
                    string vegetarisch = Convert.ToString(reader["Vegetarisch"]);

                    Console.WriteLine("{0} {1} {2}", gericht, preis, vegetarisch);
                }
            }
            else
            {
                Console.WriteLine("Keine Daten gefunden.");
            }
        }
    }
}
