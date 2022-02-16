namespace WebApilarning.Models
{
    public class OrderLine
    {
       

        public OrderLine(int orderesId, int productId)
        {
            OrderesId = orderesId;
            ProductId = productId;
        }

        public OrderLine(int orderesId, int productId, Orderes orderes)
        {
            OrderesId = orderesId;
            ProductId = productId;
            Orderes = orderes;
        }

        public int OrderesId { get; set; }
        public int ProductId { get; set; }
        public Orderes Orderes { get; set; }
        public Product Product  { get; set; }
        
    }
}
