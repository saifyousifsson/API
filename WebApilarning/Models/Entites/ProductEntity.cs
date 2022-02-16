using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApilarning.Models.Entites
{
    public class ProductEntity
    {
        public ProductEntity(string artikelnummer, string name, string description, decimal price, DateTime created, DateTime modified, string antalProducts)
        {
            Artikelnummer = artikelnummer;
            Name = name;
            Description = description;
            Price = price;
            Created = created;
            Modified = modified;
            AntalProducts = antalProducts;
        }

        public ProductEntity(string artikelnummer, string name, string description, decimal price, DateTime created, DateTime modified, string antalProducts, int subCategoryId)
        {
            Artikelnummer = artikelnummer;
            Name = name;
            Description = description;
            Price = price;
            Created = created;
            Modified = modified;
            AntalProducts = antalProducts;
            SubCategoryId = subCategoryId;
        }

        public ProductEntity(int id, string artikelnummer, string name, string description, decimal price, DateTime created, DateTime modified, string antalProducts, int subCategoryId)
        {
            Id = id;
            Artikelnummer = artikelnummer;
            Name = name;
            Description = description;
            Price = price;
            Created = created;
            Modified = modified;
            AntalProducts = antalProducts;
            SubCategoryId = subCategoryId;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Artikelnummer { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required]
        [Column (TypeName ="datetime2")]
        public DateTime Created { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string AntalProducts { get; set; }
        public int SubCategoryId { get; set; } 
        public SubCategoryEntity SubCategory { get; set; }
       // public  ICollection<OrderLineEntity> OrderLines { get; set; }


    }
}
