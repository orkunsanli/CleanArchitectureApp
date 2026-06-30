using CleanArchitectureApp.Domain.Common;

namespace CleanArchitectureApp.Domain.Entities;

public class Order : BaseEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
}
