using Microsoft.EntityFrameworkCore;
using VictorVentralProduct.Infraestructure.Context;

namespace VictorVentralProduct.API.Config
{
    public static class DbConfig
    {
        public static IServiceCollection ConfigDbConnection(this IServiceCollection service, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            service.AddDbContext<ProductDbContext>(options => options.UseSqlServer(connectionString));

            return service;
        }
    }
}
