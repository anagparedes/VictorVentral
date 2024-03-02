using Microsoft.EntityFrameworkCore;
using VictorVentralCustomer.Domain.Interfaces;
using VictorVentralCustomer.Infraestructure.Context;

namespace VictorVentralCustomer.Infraestructure.Repositories.Customer
{
    public class CustomerRepository(CustomerDbContext context) : ICustomerRepository
    {
        private readonly CustomerDbContext _context = context;

        public async Task<Domain.Entities.Customer> AddAsync(Domain.Entities.Customer newCustomer)
        {
            newCustomer.CustomerId = GetNextCustomerId();
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer;
        }

        public async Task<Domain.Entities.Customer?> DeleteAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(p => p.CustomerId == id);
            if (customer == null)
                return null;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<List<Domain.Entities.Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Domain.Entities.Customer?> GetbyIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null)
                return null;
            return customer;
        }

        public async Task<Domain.Entities.Customer?> UpdateAsync(int id, Domain.Entities.Customer newCustomer)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
                return null;

            customer.Name = newCustomer.Name;
            customer.LastName = newCustomer.LastName;
            customer.Email = newCustomer.Email;
            customer.PhoneNumber = newCustomer.PhoneNumber;
            customer.Address = newCustomer.Address;

            await _context.SaveChangesAsync();

            return customer;
        }

        public int GetNextCustomerId()
        {
            var maxProductId = _context.Customers.Max(p => (int?)p.CustomerId) ?? 0;
            return maxProductId + 1;
        }
    }
}
