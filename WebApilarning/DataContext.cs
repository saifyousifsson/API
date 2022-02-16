using Microsoft.EntityFrameworkCore;
using WebApilarning.Models.Entites;

namespace WebApilarning
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<AddressEntity> Addresses { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet <ProductEntity> Products { get; set; }
        public virtual DbSet <CategoryEntity> Categories { get; set; }
        public virtual DbSet <SubCategoryEntity> SubCategoeries { get; set; }
        public virtual DbSet <OrderLineEntity> OrderLines { get; set; }
        public virtual DbSet <OrderesEntity> Orderes { get; set; }

    }

}