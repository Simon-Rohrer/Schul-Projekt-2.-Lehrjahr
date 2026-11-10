using System;
using MySql.Data.MySqlClient;

namespace Restaurant
{
    internal class DataConnect
    {
        public MySqlConnection GetConnection()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=Restaurant;Uid=root;Pwd=;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            return connection;
        }
    }
}
