using CleanArchitectureApp.Domain.Common;

namespace CleanArchitectureApp.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
