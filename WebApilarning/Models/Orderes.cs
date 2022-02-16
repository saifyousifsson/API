namespace WebApilarning.Models
{
    public class Orderes
    {
        public Orderes(int id, DateTime created, string antalProducts, string status, int productId, int userId)
        {
            Id = id;
            Created = created;
            AntalProducts = antalProducts;
            Status = status;
            ProductId = productId;
        //    OrderLineId = orderLineId;
            UserId = userId;
        }
        public Orderes( DateTime created, string antalProducts, string status, int productId, int userId)
        {
            Created = created;
            AntalProducts = antalProducts;
            Status = status;
            ProductId = productId;
            
            UserId = userId;
        }

        public Orderes(int id, DateTime created, string antalProducts, string status, int productId, int userId, User user)
        {
            Id = id;
            Created = created;
            AntalProducts = antalProducts;
            Status = status;
            ProductId = productId;
            UserId = userId;
        }

     

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string AntalProducts { get; set; }
        public string Status { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }

        //   public int OrderLineId { get; set; }


       
     //   public User User  { get; set; }
     //   public Product Product  { get; set; }
       // public OrderLine OrderLine  { get; set; }
    }
}
