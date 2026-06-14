using Domain.Entities;

namespace Application.Interfaces;

public interface IProductRepository
{
    Task<(IEnumerable<Product> Products, int TotalRecords)> GetAllAsync(int pageNumber, int pageSize);
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}