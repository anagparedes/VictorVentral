using Microsoft.Extensions.DependencyInjection;
using VictorVentralProduct.Domain.Interfaces;
using VictorVentralProduct.Infraestructure.Repositories.Product;

namespace VictorVentralProduct.Infraestructure
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
