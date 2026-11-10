using System;
using MySql.Data.MySqlClient;

namespace Restaurant
{
    public class gericht
    {
        public int SpeiseID;
        public string Name;
        public decimal Preis;
        public bool Vegetarisch;

        public gericht(int SpeiseID, string Name, decimal Preis, bool Vegetarisch)
        {
            this.SpeiseID = SpeiseID;
            this.Name = Name;
            this.Preis = Preis;
            this.Vegetarisch = Vegetarisch;
        }
    }
}
