using Ardalis.Result;

using Core.Domain.Common;
using Core.Domain.Contracts.Repositories;
using Core.Domain.Contracts.Services;
using Core.Domain.Dtos.Product;
using Core.Domain.Dtos.Product.ProductImage;
using Core.Domain.Entities;

using Mapster;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services.Product
{
    // Inject other repositories if needed (e.g., IProductImageRepository)

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileStorageService _fileStorageService;
        public ProductService(IProductRepository productRepository, IFileStorageService fileStorageService)
        {
            _productRepository = productRepository;
            _fileStorageService = fileStorageService;
        }
        public async Task<Result<int>> CreateProduct(CreateProductDto model)
        {

            var product = model.Adapt< Core.Domain.Entities.Product>();
            await _productRepository.CreateProduct(product);
            return Result<int>.Success(product.Id);

        }


        public async Task<Result<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            var productDtos = products.Adapt<IEnumerable<ProductDto>>();
            return Result<IEnumerable<ProductDto>>.Success(productDtos);
        }

        public async Task<Result<ProductDto>> GetProductById(int id)
        {
            var product= await _productRepository.GetProductById(id);
            if (product== null)
                     return   Result<ProductDto>.NotFound("product was not found, unfortunately");
            
         
                var productDto = product.Adapt<ProductDto>();
                return Result.Success(productDto);
  
        }


        public async Task<Result> UpdateProduct(int id , UpdateProductDto model)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
                return Result.NotFound("product was not found, unfortunately");
            
            var mappedProduct = model.Adapt(product);
           await _productRepository.UpdateProduct(mappedProduct);
            return Result.Success();


        }

        public async Task<Result>  DeleteProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
                return Result.NotFound();

            await _productRepository.DeleteProduct(id);
            return Result.Success();

        }

        public async Task<Result<ProductImageDto>> AddProductImageAsync(int productId, IFormFile image)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product == null)
                return Result<ProductImageDto>.NotFound();

            var saveResult = await _fileStorageService.SaveFileAsync(image, FolderNames.ProductImages );
            if (!saveResult.IsSuccess)
                return Result<ProductImageDto>.Error(string.Join(", ", saveResult.Errors));

            var productImage = new ProductImage
            {
                ProductId = productId,
                ImageUrl = saveResult.Value
            };

            await _productRepository.AddProductImageAsync(productImage);
            var imageDto = productImage.Adapt<ProductImageDto>();
            return Result<ProductImageDto>.Success(imageDto);
        }

        public async Task<Result> DeleteProductImageAsync(int productId, int imageId)   
        {
            var product = await _productRepository.GetProductById(productId);
            if (product == null)
                return Result.NotFound();
            var image = product.Images.FirstOrDefault(x => x.Id == imageId);
            if (image == null)
                return Result.Error("image not found");
            await _fileStorageService.DeleteFileAsync(image.ImageUrl);
            await _productRepository.DeleteProductImageAsync(productId ,image.Id);
            return Result.Success();
        }

    }
}
