using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VictorVentralCustomer.Application.Customers.Dtos;
using VictorVentralCustomer.Application.Customers.Interfaces;
using VictorVentralCustomer.Application.Customers.Services;
using VictorVentralCustomer.Application.Customers.Validators;

namespace VictorVentralCustomer.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddTransient<IValidator<CreateCustomer>, CreateCustomerValidator>()
                .AddScoped<ICustomerService, CustomerService>();
        }

    }
}
