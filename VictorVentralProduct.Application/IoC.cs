using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VictorVentralProduct.Application.Products.Dtos;
using VictorVentralProduct.Application.Products.Interfaces;
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
    }
}
