namespace WebApilarning.Models
{
    public class OrderesUpdateModel
    {
        public OrderesUpdateModel(DateTime created, string antalProducts, string status)
        {
            Created = created;
            AntalProducts = antalProducts;
            Status = status;
        }

        public OrderesUpdateModel(int id, DateTime created, string antalProducts, string status)
        {
            Id = id;
            Created = created;
            AntalProducts = antalProducts;
            Status = status;
        }

        public int Id { get; set; }


        public DateTime Created { get; set; }


        public string AntalProducts { get; set; }

        public string Status { get; set; }

      

    }
}
