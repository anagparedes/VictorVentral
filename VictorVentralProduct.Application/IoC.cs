using FluentValidation;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VictorVentralProduct.Application.Products.Dtos;
using VictorVentralProduct.Application.Products.Interfaces;
using VictorVentralProduct.Application.Products.ServiceBus;
using VictorVentralProduct.Application.Products.Services;
using VictorVentralProduct.Application.Products.Validators;

namespace VictorVentralProduct.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddTransient<IValidator<CreateProduct>, CreateProductValidator>()
                .AddScoped<IProductService, ProductService>();
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
