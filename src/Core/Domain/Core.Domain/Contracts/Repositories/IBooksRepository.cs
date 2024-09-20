using Core.Domain.Dtos.Books;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Contracts.Repositories
{
    public interface IBooksRepository
    {
        Task<Book> GetById(int id);
        Task<List<Book>> Get(GeneralBookRequestDto model);
        Task Register(Book model);
    }
}
