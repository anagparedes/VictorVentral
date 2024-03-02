using AutoMapper;
using VictorVentralCustomer.Application.Customers.Dtos;
using VictorVentralCustomer.Domain.Entities;

namespace VictorVentralCustomer.Application.Customers.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetCustomer, Customer>();
            CreateMap<Customer, GetCustomer>();

            CreateMap<CreateCustomer, Customer>();
            CreateMap<Customer, CreateCustomer>();

            CreateMap<CreatedCustomerResponse, Customer>();
            CreateMap<Customer, CreatedCustomerResponse>();

            CreateMap<UpdatedCostumerResponse, Customer>();
            CreateMap<Customer, UpdatedCostumerResponse>();

            CreateMap<DeletedCustomerResponse, Customer>();
            CreateMap<Customer, DeletedCustomerResponse>();

        }
    }
}
