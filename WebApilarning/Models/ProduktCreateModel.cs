namespace WebApilarning.Models
{
    public class ProduktCreateModel
    {
        public ProduktCreateModel( string artikelnummer, string name, string description, decimal price, string antalProducts,int subCategoryId)
        { var curentDateTime = DateTime.Now;
            
            Artikelnummer = artikelnummer;
            Name = name;
            Description = description;
            Price = price;
            Created = curentDateTime;
            Modified = curentDateTime;
            AntalProducts = antalProducts;
       
            SubCategoryId = subCategoryId;
        }

       
        public string Artikelnummer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string AntalProducts { get; set; }
      
        public int SubCategoryId { get; set; }
    }
}
