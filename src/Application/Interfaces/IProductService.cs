using Application.DTOs;

namespace Application.Interfaces;

public interface IProductService
{
    Task<object> GetAllAsync(int pageNumber, int pageSize);
    Task<ProductDto> GetByIdAsync(int id);
    Task<ProductDto> CreateAsync(CreateProductRequest request);
    Task<ProductDto> UpdateAsync(int id, UpdateProductRequest request);
    Task DeleteAsync(int id);
}