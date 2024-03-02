using AutoMapper;
using FluentValidation;
using VictorVentralCustomer.Application.Customers.Dtos;
using VictorVentralCustomer.Application.Customers.Interfaces;
using VictorVentralCustomer.Domain.Entities;
using VictorVentralCustomer.Domain.Interfaces;

namespace VictorVentralCustomer.Application.Customers.Services
{
    public class CustomerService(ICustomerRepository customerRepository, IValidator<CreateCustomer> createCustomerValidator, IMapper mapper) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IValidator<CreateCustomer> _createCustomerValidator = createCustomerValidator;
        private readonly IMapper _mapper = mapper;

        public async Task<CreatedCustomerResponse?> AddCustomerAsync(CreateCustomer createCustomer)
        {
            var validateCreateCustomerResult = _createCustomerValidator.Validate(createCustomer);
            if (validateCreateCustomerResult.IsValid)
            {
                var customer = new Customer
                {
                    Name = createCustomer.Name,
                    LastName = createCustomer.LastName,
                    Email = createCustomer.Email,
                    PhoneNumber = createCustomer.PhoneNumber,
                    Address = createCustomer.Address,
                };
                var newCustomer = await _customerRepository.AddAsync(customer);
                return _mapper.Map<CreatedCustomerResponse>(newCustomer);
            }
            return null;
           
            
        }

        public async Task<DeletedCustomerResponse?> DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.DeleteAsync(id);
            return _mapper.Map<DeletedCustomerResponse>(customer);
        }

        public async Task<List<GetCustomer>> GetAllCustomersAsync()
        {
            var customer = await _customerRepository.GetAllAsync();
            return customer.Select(st => _mapper.Map<GetCustomer>(st)).ToList();
        }

        public async Task<GetCustomer?> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetbyIdAsync(id);
            return _mapper.Map<GetCustomer>(customer);
        }

        public async Task<UpdatedCostumerResponse?> UpdateCustomerAsync(int id, CreateCustomer updateCustomer)
        {
            var validateCreateCustomerResult = _createCustomerValidator.Validate(updateCustomer);
            if (validateCreateCustomerResult.IsValid)
            {
                var customer = new Customer
                {
                    Name = updateCustomer.Name,
                    LastName = updateCustomer.LastName,
                    Email = updateCustomer.Email,
                    PhoneNumber = updateCustomer.PhoneNumber,
                    Address = updateCustomer.Address,
                };
                var newCustomer = await _customerRepository.UpdateAsync(id, customer);
                return _mapper.Map<UpdatedCostumerResponse>(newCustomer);
            }
            return null;
        }
    }
}
