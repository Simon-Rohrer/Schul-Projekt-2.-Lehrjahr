using System;
using MySql.Data.MySqlClient;

namespace Ueb_Datenbankzugriff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection myConnection = null;
            try
            {
                dataConnect dbConnector = new dataConnect();
                myConnection = dbConnector.GetConnection();

                dataRead dbReader = new dataRead();
                dbReader.DataRead(myConnection);

                dataWrite dbWrite = new dataWrite();
                dbWrite.DataWrite(myConnection);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection?.Close();
            }
        }
    }
}
