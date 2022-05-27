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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>()
        //        .HasOne(e => e.Department)
        //        .WithMany(e => e.Employees)
        //        .IsRequired();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb5;Trusted_Connection=True;");
        }
    }
}
