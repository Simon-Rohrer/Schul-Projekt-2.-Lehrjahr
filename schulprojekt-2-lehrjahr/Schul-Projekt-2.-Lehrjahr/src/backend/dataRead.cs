using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Ueb_Datenbankzugriff
{
    internal class dataRead
    {
        public List<Gericht> GetAlleGerichte(MySqlConnection con)
        {
            var gerichte = new List<Gericht>();
            string cmdString = "SELECT listenid, essensname, preis, vegetarisch FROM Essensliste";

            using var cmd = new MySqlCommand(cmdString, con);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                gerichte.Add(new Gericht
                {
                    Id = Convert.ToInt32(reader["listenid"]),
                    Name = Convert.ToString(reader["essensname"]) ?? "",
                    Preis = Convert.ToDecimal(reader["preis"]),
                    Vegetarisch = Convert.ToBoolean(reader["vegetarisch"])
                });
            }

            return gerichte;
        }
    }
}