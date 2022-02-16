namespace WebApilarning.Models
{
    public class Product
    {
        public Product(int id, string name, string artikelnummer, string description, decimal price, string antalProducts)
        {
            Id = id;
            Name = name;
            Artikelnummer = artikelnummer;
            Description = description;
            Price = price;
            AntalProducts = antalProducts;
        }

        public Product(int id, string name, string artikelnummer, string description, decimal price, string antalProducts, string antalProducts1)
        {
            Id = id;
            Name = name;
            Artikelnummer = artikelnummer;
            Description = description;
            Price = price;
            AntalProducts = antalProducts;
        }

        public Product(int id, string artikelnummer, string name, string description, decimal price, string antalProducts, SubCategory subCategory)
        {
            Id = id;
            Artikelnummer = artikelnummer;
            Name = name;
            Description = description;
            Price = price;
            AntalProducts = antalProducts;
        }

        public Product(int id, string artikelnummer, string name, string description, decimal price, string antalProducts, int subCategoryId)
        {
            Id = id;
            Artikelnummer = artikelnummer;
            Name = name;
            Description = description;
            Price = price;
            AntalProducts = antalProducts;
            SubCategoryId = subCategoryId;
        }

        public Product(int id, string artikelnummer, string name, string description, decimal price, DateTime created, DateTime modified, string antalProducts)
        {
            Id = id;
            Artikelnummer = artikelnummer;
            Name = name;
            Description = description;
            Price = price;
            Created = created;
            Modified = modified;
            AntalProducts = antalProducts;
        }

        public Product(string artikelnummer, string name, string description, decimal price, string antalProducts, DateTime created, DateTime modified, int subCategoryId)
        {
            Artikelnummer = artikelnummer;
            Name = name;
            Description = description;
            Price = price;
            AntalProducts = antalProducts;
            Created = created;
            Modified = modified;
            SubCategoryId = subCategoryId;
        }

        public Product(int id, string artikelnummer, string name, string description, decimal price, DateTime created, DateTime modified, string antalProducts, User users)
        {
            Id = id;
            Artikelnummer = artikelnummer;
            Name = name;
            Description = description;
            Price = price;
            Created = created;
            Modified = modified;
            AntalProducts = antalProducts;
          //  Users = users;
        }

      

        public int Id { get; set; }
        public string Artikelnummer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string AntalProducts { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int SubCategoryId { get; set; }
        public OrderLine OrderLine { get; set; }

        //  public User Users { get; set; }
        // public SubCategory SubCategory { get; set; }




    }
}
