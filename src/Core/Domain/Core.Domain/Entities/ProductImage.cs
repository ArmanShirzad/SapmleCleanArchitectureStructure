using Core.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class ProductImage : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }

        public Product Product { get; set; }
    }
}
