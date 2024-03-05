using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VictorVentralProduct.Domain.Interfaces;
using VictorVentralProduct.Infraestructure.Repositories.Product;
using VictorVentralProduct.Infraestructure.ServiceBus;

namespace VictorVentralProduct.Infraestructure
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IProductRepository, ProductRepository>();
        }
        public static IServiceCollection AddServiceBus(this IServiceCollection services, IConfiguration Configuration)
        {
            return services
                .AddHostedService<CreatedSaleConsumerService>()
                .AddSingleton<ISubscriptionClient>(x => new SubscriptionClient(
                    Configuration.GetValue<string>("ServiceBus:ConnectionString"),
                    Configuration.GetValue<string>("ServiceBus:TopicName"),
                    Configuration.GetValue<string>("ServiceBus:SubscriptionName")));
        }
    }
}
