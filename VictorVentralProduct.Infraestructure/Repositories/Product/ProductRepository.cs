using Microsoft.EntityFrameworkCore;
using VictorVentralProduct.Domain.Interfaces;
using VictorVentralProduct.Infraestructure.Context;


namespace VictorVentralProduct.Infraestructure.Repositories.Product
{
    public class ProductRepository(ProductDbContext context) : IProductRepository
    {
        private readonly ProductDbContext _context = context;

        public async Task<VictorVentralProduct.Domain.Entities.Product> AddAsync(VictorVentralProduct.Domain.Entities.Product newProduct)
        {
            newProduct.ProductId = GetNextProductId();
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<VictorVentralProduct.Domain.Entities.Product?> DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
                return null;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<List<VictorVentralProduct.Domain.Entities.Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<VictorVentralProduct.Domain.Entities.Product?> GetbyIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
                return null;
            return product;
        }

        public async Task<VictorVentralProduct.Domain.Entities.Product?> UpdateAsync(int id, VictorVentralProduct.Domain.Entities.Product newProduct)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return null;

            product.Name = newProduct.Name;
            product.Description = newProduct.Description;
            product.UnitPrice = newProduct.UnitPrice;
            product.Stock = newProduct.Stock;
            product.Category = newProduct.Category;

            await _context.SaveChangesAsync();

            return product;
        }

        public int GetNextProductId()
        {
            var maxProductId = _context.Products.Max(p => (int?)p.ProductId) ?? 0;
            return maxProductId + 1;
        }
    }
}
