using AutoMapper;
using VictorVentralProduct.Application.Products.Dtos;
using VictorVentralProduct.Domain.Entities;

namespace VictorVentralProduct.Application.Products.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProduct>();
            CreateMap<GetProduct, Product>();

            CreateMap<Product, CreateProduct>();
            CreateMap<CreateProduct, Product>();

            CreateMap<CreatedProductResponse, Product>();
            CreateMap<Product, CreatedProductResponse>();

            CreateMap<UpdatedProductResponse, Product>();
            CreateMap<Product, UpdatedProductResponse>();

            CreateMap<DeletedProductResponse, Product>();
            CreateMap<Product, DeletedProductResponse>();

        }
    }
}
