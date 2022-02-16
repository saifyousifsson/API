namespace WebApilarning.Models
{
    public class OrderesCreateModel
    {
        public OrderesCreateModel(DateTime created, string antalProducts, int productId, int userId, string status =  "Unknown")
        {
            Created = created;
            AntalProducts = antalProducts;
            ProductId = productId;
            UserId = userId;
            Status = status;
        }

        public DateTime Created { get; set; }
        public string AntalProducts { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
      //  public int OrderLineId { get; set; }

       
    }
}
