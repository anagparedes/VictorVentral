using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentralProduct.Application.Products.Dtos;

namespace VictorVentralProduct.Application.Products.Interfaces
{
    public interface IProductService
    {
        Task<List<GetProduct>> GetAllProductsAsync();
        Task<CreatedProductResponse?> AddProductAsync(CreateProduct createProduct);
        Task<GetProduct?> GetProductByIdAsync(int id);
        Task<UpdatedProductResponse?> UpdateProductAsync(int id, CreateProduct updateProduct);
        Task<DeletedProductResponse?> DeleteProductAsync(int id);
    }
}
