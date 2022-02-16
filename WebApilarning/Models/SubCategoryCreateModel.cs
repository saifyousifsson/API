namespace WebApilarning.Models
{
    public class SubCategoryCreateModel
    {
     

      

        public SubCategoryCreateModel(int id, string name, int categoryId)
        {
            Id = id;
            Name = name;
            CategoeryId = categoryId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoeryId { get; set; }
    }
}
