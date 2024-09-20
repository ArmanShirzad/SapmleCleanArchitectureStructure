using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class Writer : BaseEntity<int>
    {
        public string FullName { get; set; }
        public List<Book> Books { get; set; }
    }
}
