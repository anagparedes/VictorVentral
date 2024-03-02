using Microsoft.Extensions.DependencyInjection;
using VictorVentralCustomer.Domain.Interfaces;
using VictorVentralCustomer.Infraestructure.Repositories.Customer;

namespace VictorVentralCustomer.Infraestructure
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ICustomerRepository, CustomerRepository>();
        }

    }
}
