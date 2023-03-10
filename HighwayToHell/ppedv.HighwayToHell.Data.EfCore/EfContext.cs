using Microsoft.EntityFrameworkCore;
using ppedv.HighwayToHell.Model;

namespace ppedv.HighwayToHell.Data.EfCore
{
    public class EfContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        private readonly string _conString;

        public EfContext(string conString)
        {
            _conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(x => x.BillingCustomer).WithMany(x => x.BillingOrders);
            modelBuilder.Entity<Order>().HasOne(x => x.DeliveryCustomer).WithMany(x => x.DeliveryOrders);

            //modelBuilder.Entity<OrderItem>().Property(x => x.Color).HasColumnName("Farbe").HasMaxLength(200);
        }
    }
}