namespace WebApilarning.Models
{
    public class ProduktUpdateModel
    {
        public ProduktUpdateModel(int id, string artikelnummer, string name, string description, decimal price, string antalProducts)
        {
            Id = id;
            Artikelnummer = artikelnummer;
            Name = name;
            Description = description;
            Price = price;
            Modified = DateTime.Now;
            AntalProducts = antalProducts;
        }

        public int Id { get; set; }
        public string Artikelnummer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Modified { get; set; }
        public string AntalProducts { get; set; }

    }
}
