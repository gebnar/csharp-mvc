using System.Data.Entity;

namespace CartonScanApp.Models {
    public class CartonScanDbContext : DbContext {
        public DbSet<Carton> Cartons { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}