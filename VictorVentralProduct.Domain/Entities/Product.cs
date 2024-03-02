using VictorVentralProduct.Domain.Models;

namespace VictorVentralProduct.Domain.Entities
{
    public class Product: BaseEntity
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Stock {  get; set; }
        public string? Category { get; set; }
    }
}
