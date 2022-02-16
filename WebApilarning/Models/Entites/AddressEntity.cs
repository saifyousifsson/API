using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApilarning.Models.Entites
{
    public class AddressEntity
    {
        public AddressEntity()
        {
        }
        public AddressEntity(string streetName, string postalCode, string country, string city)
        {
            StreetName = streetName;
            PostalCode = postalCode;
            Country = country;
            City = city;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string  StreetName { get; set; }
        [Required]
        [Column(TypeName = "char(5)")]
        public string PostalCode { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        public virtual ICollection<UserEntity> Users { get;}
      
    }
}
