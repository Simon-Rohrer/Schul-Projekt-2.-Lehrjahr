namespace Restaurant
{
    public class Gericht
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Preis { get; set; }
        public bool Vegetarisch { get; set; }

        public Gericht(int Id, string Name, decimal Preis, bool Vegetarisch)
        {
            this.Id = Id;
            this.Name = Name;
            this.Preis = Preis;
            this.Vegetarisch = Vegetarisch;
        }
    }
}
