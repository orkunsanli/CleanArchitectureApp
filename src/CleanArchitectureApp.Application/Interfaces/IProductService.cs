using CleanArchitectureApp.Application.DTOs;

namespace CleanArchitectureApp.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto?> GetByIdAsync(int id);
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> CreateAsync(CreateProductDto dto);
    Task<bool> UpdateAsync(int id, UpdateProductDto dto);
    Task<bool> DeleteAsync(int id);
}
