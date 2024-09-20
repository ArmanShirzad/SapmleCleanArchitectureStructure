using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Book : BaseEntity<int>
    {
        public string Title { get; set; }
        public Type UseageType { get; set; }
        public List<Writer> Writers { get; set; }

        public enum Type
        {
            General = 1,
            Specialized = 2
        }
    }
}
