using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;

using Core.Domain.Dtos.Product;
using Core.Domain.Dtos.Product.ProductImage;
using Core.Domain.Entities;

using Microsoft.AspNetCore.Http;


namespace Core.Domain.Contracts.Services
{
    public interface IProductService
    {
        Task<Result<IEnumerable<ProductDto>>> GetAllProducts();
        Task<Result<ProductDto>> GetProductById(int id);
        Task<Result<int>> CreateProduct(CreateProductDto model);
        Task<Result> UpdateProduct(int id, UpdateProductDto model);
        Task<Result> DeleteProduct(int id);

        //image gallery
        Task<Result<ProductImageDto>> AddProductImageAsync(int productId, IFormFile image);
        Task<Result> DeleteProductImageAsync(int productId, int imageId);

    }
}
