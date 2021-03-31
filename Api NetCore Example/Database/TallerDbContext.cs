using Api_NetCore_Example.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_NetCore_Example.Database
{
    public class TallerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public TallerDbContext(DbContextOptions<TallerDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //if (!optionsBuilder.IsConfigured)
            //{
            //    //var connectionString = "Server=localhost;Database=example;Port=5432;User Id=postgres;Password=postgres";
            //    //optionsBuilder.UseNpgsql(connectionString);
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp")
              .HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v1()");
            });

            modelBuilder.Entity<CustomerPhones>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v1()");
            });

        }
    }
}
