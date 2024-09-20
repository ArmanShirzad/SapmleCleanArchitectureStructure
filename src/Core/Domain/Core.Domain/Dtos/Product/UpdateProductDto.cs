using Core.Domain.Entities;
using Core.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Core.Domain.Entities.Product;

namespace Core.Domain.Dtos.Product
{
    public class UpdateProductDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
        public int StockQuantity { get; set; }

    }
}
