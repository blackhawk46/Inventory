using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server
{
    public class DataContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DataContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb13;Trusted_Connection=True;");
        }
    }
}
