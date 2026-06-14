using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<object> GetAllAsync(int pageNumber, int pageSize)
    {
        var result = await _productRepository.GetAllAsync(pageNumber, pageSize);

        return new
        {
            TotalRecords = result.TotalRecords,
            Data = result.Products.Select(x => new ProductDto
            {
                Id = x.Id,
                ProductName = x.ProductName,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                ModifiedBy = x.ModifiedBy,
                ModifiedOn = x.ModifiedOn
            })
        };
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        return new ProductDto
        {
            Id = product.Id,
            ProductName = product.ProductName,
            CreatedBy = product.CreatedBy,
            CreatedOn = product.CreatedOn,
            ModifiedBy = product.ModifiedBy,
            ModifiedOn = product.ModifiedOn
        };
    }

    public async Task<ProductDto> CreateAsync(CreateProductRequest request)
    {
        var product = new Product
        {
            ProductName = request.ProductName,
            CreatedBy = request.CreatedBy,
            CreatedOn = DateTime.UtcNow
        };

        var created = await _productRepository.CreateAsync(product);

        return new ProductDto
        {
            Id = created.Id,
            ProductName = created.ProductName,
            CreatedBy = created.CreatedBy,
            CreatedOn = created.CreatedOn
        };
    }

    public async Task<ProductDto> UpdateAsync(int id, UpdateProductRequest request)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        product.ProductName = request.ProductName;
        product.ModifiedBy = request.ModifiedBy;
        product.ModifiedOn = DateTime.UtcNow;

        await _productRepository.UpdateAsync(product);

        return new ProductDto
        {
            Id = product.Id,
            ProductName = product.ProductName,
            CreatedBy = product.CreatedBy,
            CreatedOn = product.CreatedOn,
            ModifiedBy = product.ModifiedBy,
            ModifiedOn = product.ModifiedOn
        };
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        await _productRepository.DeleteAsync(product);
    }
}