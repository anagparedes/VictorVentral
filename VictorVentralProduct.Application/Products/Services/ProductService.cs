using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentralProduct.Application.Products.Dtos;
using VictorVentralProduct.Application.Products.Interfaces;
using VictorVentralProduct.Domain.Entities;
using VictorVentralProduct.Domain.Interfaces;

namespace VictorVentralProduct.Application.Products.Services
{
    public class ProductService(IProductRepository productRepository, IValidator<CreateProduct> createProductValidator, IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IValidator<CreateProduct> _createProductValidator = createProductValidator;
        private readonly IMapper _mapper = mapper;

        public async Task<CreatedProductResponse?> AddProductAsync(CreateProduct createProduct)
        {
            var validateCreateProductResult = _createProductValidator.Validate(createProduct);
            if (validateCreateProductResult.IsValid)
            {
                var product = new Product
                {
                    Name = createProduct.Name,
                    Description = createProduct.Description,
                    UnitPrice = createProduct.UnitPrice,
                    Stock = createProduct.Stock,
                    Category = createProduct.Category,
                };
                var newProduct = await _productRepository.AddAsync(product);
                return _mapper.Map<CreatedProductResponse>(newProduct);
            }
            return null;
        }

        public async Task<DeletedProductResponse?> DeleteProductAsync(int id)
        {
            var product = await _productRepository.DeleteAsync(id);
            return _mapper.Map<DeletedProductResponse>(product);
        }

        public async Task<List<GetProduct>> GetAllProductsAsync()
        {
            var product = await _productRepository.GetAllAsync();
            return product.Select(st => _mapper.Map<GetProduct>(st)).ToList();
        }

        public async Task<GetProduct?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetbyIdAsync(id);
            return _mapper.Map<GetProduct>(product);
        }

        public async Task<UpdatedProductResponse?> UpdateProductAsync(int id, CreateProduct updateProduct)
        {
            var validateCreateProductResult = _createProductValidator.Validate(updateProduct);
            if (validateCreateProductResult.IsValid)
            {
                var product = new Product
                {
                    Name = updateProduct.Name,
                    Description = updateProduct.Description,
                    UnitPrice = updateProduct.UnitPrice,
                    Stock = updateProduct.Stock,
                    Category = updateProduct.Category,
                };
                var newProduct = await _productRepository.UpdateAsync(id, product);
                return _mapper.Map<UpdatedProductResponse>(newProduct);
            }
            return null;
        }
    }
}
