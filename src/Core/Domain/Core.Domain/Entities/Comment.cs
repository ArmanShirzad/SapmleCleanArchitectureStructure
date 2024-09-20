using Core.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Comment : BaseEntity<int>
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
