using WebApilarning.Models.Entites;

namespace WebApilarning.Models
{
    public class SubCategory
    {
        public SubCategory(string name)
        {
            Name = name;
        }

        public SubCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public SubCategory(string name, int categoryId)
        {
            Name = name;
            CategoeryId = categoryId;
        }

        public SubCategory(int id, string name, int categoryId)
        {
            Id = id;
            Name = name;
            CategoeryId = categoryId;
        }

        public int Id { get; set; }
 
        public string Name { get; set; }


        public int CategoeryId { get; set; }
       // public CategoryEntity Category { get; set; }
    }
}
