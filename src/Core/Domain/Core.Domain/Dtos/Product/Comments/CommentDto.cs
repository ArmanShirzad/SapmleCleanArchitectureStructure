using Core.Domain.Entities; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Dtos.Product.Comments
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public Core.Domain.Entities.Product Product { get; set; }
        public User User { get; set; }
    }
}
