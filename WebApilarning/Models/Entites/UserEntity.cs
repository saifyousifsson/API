using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApilarning.Models.Entites
{
    [Index(nameof(Email), IsUnique = true)]
    public class UserEntity
    {
        public UserEntity()
        {

        }
        public UserEntity(string firstName, string lastName, string email, string passWord, DateTime created, DateTime modified, AddressEntity address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PassWord = passWord;
            Created = created;
            Modified = modified;
            Address = address;
        }

        public UserEntity(string firstName, string lastName, string email, string passWord, DateTime created, DateTime modified, int addressId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PassWord = passWord;
            Created = created;
            Modified = modified;
            AddressId = addressId;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string PassWord { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime Modified { get; set; }

        public int AddressId { get; set; }

        public AddressEntity Address { get; set; }

        public virtual ICollection<OrderesEntity> Orderes { get; set; }


    }
}
