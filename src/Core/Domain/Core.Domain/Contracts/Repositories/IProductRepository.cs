using Core.Domain.Dtos.Books;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task CreateProduct(Product model);
        Task UpdateProduct(Product model);
        Task DeleteProduct(int id);

        // image gallery
        Task AddProductImageAsync(ProductImage image);
        Task DeleteProductImageAsync(int productId,int imageId);

    }
}
