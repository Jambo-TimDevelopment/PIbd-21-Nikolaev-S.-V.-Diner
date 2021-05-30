using AbstractDinerDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace AbstractDinerDatabaseImplement
{
    public class AbstractDinerDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AbstractDinerDatabase_Hard;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        
        public virtual DbSet<Component> Components { set; get; }
        
        public virtual DbSet<Snack> Snacks { set; get; }
        
        public virtual DbSet<SnackComponent> SnackComponents { set; get; }
        
        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<Warehouse> Warehouses { set; get; }

        public virtual DbSet<WarehouseComponent> WarehouseComponents { set; get; }
    }
}
