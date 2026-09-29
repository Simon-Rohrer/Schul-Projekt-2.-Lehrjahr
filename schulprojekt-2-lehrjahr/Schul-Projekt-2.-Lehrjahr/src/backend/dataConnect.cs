using System;
using MySql.Data.MySqlClient;

namespace Ueb_Datenbankzugriff
{
    internal class dataConnect
    {
        public MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=ueb_datenbankzugriff;Uid=root;Pwd=/data/mysql/mysql8.0.33-winx64/bin/mysql.exe;";
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();

            return con;
        }
    }
}
