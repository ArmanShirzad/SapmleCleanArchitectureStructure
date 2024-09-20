using Ardalis.Result;
using Ardalis.Result.AspNetCore;

using Core.Domain.Contracts.Services;
using Core.Domain.Dtos.Product;
using Core.Domain.Dtos.Product.ProductImage;
using Core.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;

using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [TranslateResultToActionResult]
        public async Task<Result<IEnumerable<ProductDto>>> GetAllProduct()
        {
            return await _productService.GetAllProducts();

        }

        // GET api/<ProductController>/5
        [HttpGet("GetProductBy/{id}")]
        [TranslateResultToActionResult]
        public async Task<Result<ProductDto>> GetProductById(int id)
        {
            return await _productService.GetProductById(id);  
        }

        // POST api/<ProductController>
        [HttpPost("CreateNewProduct")]
        [TranslateResultToActionResult]
        public async Task<Result<int>> CreateProduct([FromBody]  CreateProductDto model) 
        {
            return await _productService.CreateProduct(model);
        }
        [HttpPut("UpdateProduct/{id}")]
        [TranslateResultToActionResult]
        public async Task<Result> UpdateProduct(int id, [FromBody] UpdateProductDto updateDto)
        {
            var update = await _productService.UpdateProduct(id, updateDto);
            if (update.IsSuccess)
            {
                return Result.Success();
            }
            else
            {
                return Result.Error("Something happened");
            }
        }

        [HttpDelete("{id}")]
        [TranslateResultToActionResult]
        public async Task<Result> DeleteProduct(int id)
        {
            return await _productService.DeleteProduct(id);
        }


        //gallery handling
        // Image Management
        [HttpPost("{id}/images")]
        [Consumes("multipart/form-data")]
        [TranslateResultToActionResult]
        public async Task<Result<ProductImageDto>> AddProductImage(int id, [FromForm] IFormFile image)
        {
            return await _productService.AddProductImageAsync(id, image);
        }

        [HttpDelete("{id}/images/{imageId}")]
        [TranslateResultToActionResult]
        public async Task<Result> DeleteProductImage(int id, int imageId)
        {
            return await _productService.DeleteProductImageAsync(id, imageId);
        }
    }
}
