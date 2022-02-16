namespace WebApilarning.Models
{
    public class CategoryCreateModel
    {
        public CategoryCreateModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
