using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VictorVentralCustomer.Domain.Entities;

namespace VictorVentralCustomer.Infraestructure.Context
{
    public interface ICustomerDbContext : IDbContext { }

    public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : BaseDbContext(options) , ICustomerDbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetAssembly(typeof(CustomerDbContext));

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
