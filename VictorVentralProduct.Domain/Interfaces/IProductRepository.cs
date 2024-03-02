using VictorVentralProduct.Domain.Entities;

namespace VictorVentralProduct.Domain.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        int GetNextProductId();
    }
}
