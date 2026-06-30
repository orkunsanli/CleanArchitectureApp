using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Infrastructure.Persistence;

namespace CleanArchitectureApp.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
