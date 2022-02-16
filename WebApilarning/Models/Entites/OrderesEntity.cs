using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApilarning.Models.Entites
{
    public class OrderesEntity
    {
        public OrderesEntity(DateTime created, string antalProducts, string status, int productId)
        {
            Created = created;
            AntalProducts = antalProducts;
            Status = status;
            ProductId = productId;
        }

        public OrderesEntity(DateTime created, string antalProducts, string status, int productId, int userId)
        {
            Created = created;
            AntalProducts = antalProducts;
            Status = status;
            ProductId = productId;
            UserId = userId;
        }

        public OrderesEntity(int id, DateTime created, string antalProducts, string status, int productId, int userId)
        {
            Id = id;
            Created = created;
            AntalProducts = antalProducts;
            Status = status;
            ProductId = productId;
            UserId = userId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
  
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string AntalProducts { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; }

        public int ProductId { get; set; }
        
  
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public virtual ICollection<OrderLineEntity> OrderLines { get; set; }


    }
}
