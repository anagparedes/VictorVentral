using VictorVentralCustomer.Domain.Entities;

namespace VictorVentralCustomer.Domain.Interfaces
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        int GetNextCustomerId();
    }
}
