using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Restaurant
{
    internal class dataRead
    {
        public List<Speisen> GetAlleGerichte(MySqlConnection connection)
        {
            var gerichte = new List<Speisen>();
            string sqlCommand = "SELECT speiseid, name, preis, vegetarisch FROM Speisekarte";

            var cmd = new MySqlCommand(sqlCommand, connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                gerichte.Add(new Gericht
                {
                    Id = Convert.ToInt32(reader["speiseid"]),
                    Name = Convert.ToString(reader["name"]) ?? "",
                    Preis = Convert.ToDecimal(reader["preis"]),
                    Vegetarisch = Convert.ToBoolean(reader["vegetarisch"])
                });
            }
            return gerichte;
        }
    }
}