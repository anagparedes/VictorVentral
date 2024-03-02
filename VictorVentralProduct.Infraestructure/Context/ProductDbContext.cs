using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VictorVentralProduct.Domain.Entities;

namespace VictorVentralProduct.Infraestructure.Context
{
    public interface IProductDbContext : IDbContext { }

    public class ProductDbContext(DbContextOptions<ProductDbContext> options) : BaseDbContext(options), IProductDbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetAssembly(typeof(ProductDbContext));

            if (assembly is not null)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
