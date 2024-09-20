using Core.Domain.Common;
using Core.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public ProductType Type { get; set; }
        public int StockQuantity { get; set; }
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        // Enum for product categories
 
    }



}
