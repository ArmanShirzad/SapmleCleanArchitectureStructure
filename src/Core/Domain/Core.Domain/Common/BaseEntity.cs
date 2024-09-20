using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public class BaseEntity<T> : AuditableEntity where T : struct
    {
        public T Id { get; set; }
    }
}
