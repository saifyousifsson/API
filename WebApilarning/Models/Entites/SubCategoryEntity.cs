using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApilarning.Models.Entites
{
    public class SubCategoryEntity
    {
        public SubCategoryEntity(string name)
        {
            Name = name;
        }

        public SubCategoryEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public SubCategoryEntity(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }

        public SubCategoryEntity(int id, string name, int categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public ICollection<ProductEntity> Products { get; set; }

    }
}
