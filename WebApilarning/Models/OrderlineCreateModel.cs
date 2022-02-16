namespace WebApilarning.Models
{
    public class OrderlineCreateModel
    {
     

        public OrderlineCreateModel(int orderesId, int productId)
        {
            OrderesId = orderesId;
            ProductId = productId;
        }

        public int OrderesId { get; set; }
        public int ProductId { get; set; }
    }
}
