using Microsoft.EntityFrameworkCore;
using VictorVentralCustomer.Infraestructure.Context;

namespace VictorVentralCustomer.API.Config
{
    public static class DbConfig
    {
        public static IServiceCollection ConfigDbConnection(this IServiceCollection service, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            service.AddDbContext<CustomerDbContext>(options => options.UseSqlServer(connectionString));

            return service;
        }

    }
}
