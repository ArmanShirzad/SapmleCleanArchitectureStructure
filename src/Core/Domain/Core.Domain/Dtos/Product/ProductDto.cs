using Core.Domain.Dtos.Product.Comments;
using Core.Domain.Dtos.Product.ProductImage;
using Core.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Core.Domain.Entities.Product;

namespace Core.Domain.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
        public int StockQuantity { get; set; }
        public List<ProductImageDto> Images { get; set; } = new List<ProductImageDto>();
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();

    }
}
