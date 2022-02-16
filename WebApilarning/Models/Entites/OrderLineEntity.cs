using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApilarning.Models.Entites
{
    public class OrderLineEntity


    {
        public OrderLineEntity(int orderesId, int productId)
        {
            OrderesId = orderesId;
            ProductId = productId;
        }

        [Key]
        public int OrderesId { get; set; }
        [Required]
        public int ProductId { get; set; }
      
      
       
        public ProductEntity Product { get; set; }

        

        public  OrderesEntity Orderes { get; set; }
       
        
    }
}
