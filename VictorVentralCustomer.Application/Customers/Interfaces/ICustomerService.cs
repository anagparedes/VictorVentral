using VictorVentralCustomer.Application.Customers.Dtos;

namespace VictorVentralCustomer.Application.Customers.Interfaces
{
    public interface ICustomerService
    {
        Task<List<GetCustomer>> GetAllCustomersAsync();
        Task<CreatedCustomerResponse?> AddCustomerAsync(CreateCustomer createCustomer);
        Task<GetCustomer?> GetCustomerByIdAsync(int id);
        Task<UpdatedCostumerResponse?> UpdateCustomerAsync(int id, CreateCustomer updateCustomer);
        Task<DeletedCustomerResponse?> DeleteCustomerAsync(int id);
    }
}
