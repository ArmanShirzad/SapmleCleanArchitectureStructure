using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Dtos.Books
{
    public class RegisterBookRequestDto
    {
        public string Title { get; set; }
        public Book.Type UseageType { get; set; }
        public List<RegisterBookWriterDto> Writers { get; set; }

        public class RegisterBookWriterDto
        {
            public string FullName { get; set; }
        }
    }
}
