using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApilarning.Models.Entites
{
    public class CategoryEntity
    {
        public CategoryEntity(string name)
        {
            Name = name;
        }

        public CategoryEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public virtual ICollection<SubCategoryEntity> SubCategories { get; set; }


    }
}
