using Api_NetCore_Example.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_NetCore_Example.Database
{
    public class TallerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }


        public TallerDbContext(DbContextOptions<TallerDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp")
              .HasAnnotation("Relational:Collation", "en_US.utf8");

            // configure entities
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v1()");
            });

            modelBuilder.Entity<CustomerPhones>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v1()");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v1()");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v1()");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW()");
            });
        }
    }
}
