using CleanArchMvc.Domain.Enitities;

namespace CleanArchMvc.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetByIdAsync(int? id);
    Task<Product> GetProductCategoryAsync(int? id);
    Task<Category> CreateAsync(Product category);
    Task<Category> UpdateAsync(Product category);
    Task<Category> RemoveAsync(Product category);
}
