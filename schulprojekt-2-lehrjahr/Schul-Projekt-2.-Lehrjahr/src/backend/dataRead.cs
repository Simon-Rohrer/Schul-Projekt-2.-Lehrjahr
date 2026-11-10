using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Restaurant
{
    internal class DataRead
    {
        public List<Gericht> GetAlleGerichte(MySqlConnection connection)
        {
            var gericht = new List<Gericht>();
            string sqlCommand = "SELECT speiseid, name, preis, vegetarisch FROM Speisekarte";

            var cmd = new MySqlCommand(sqlCommand, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                gericht.Add(new Gericht(
                    Convert.ToInt32(reader["speiseid"]),
                    Convert.ToString(reader["name"]) ?? "",
                    Convert.ToDecimal(reader["preis"]),
                    Convert.ToBoolean(reader["vegetarisch"])
                ));
            }
            return gericht;
        }
    }
}