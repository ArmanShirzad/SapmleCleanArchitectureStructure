using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class Profile : BaseEntity<int>
    {
        public string FullName { get; set; }
    }
}
