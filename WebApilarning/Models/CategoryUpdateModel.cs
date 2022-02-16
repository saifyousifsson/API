namespace WebApilarning.Models
{
    public class CategoryUpdateModel
    {
        public CategoryUpdateModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
      
        public string Name { get; set; }
    }
}
