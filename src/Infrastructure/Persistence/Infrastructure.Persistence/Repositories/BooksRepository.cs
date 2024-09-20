using Core.Domain.Contracts.Repositories;
using Core.Domain.Dtos.Books;
using Core.Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext _context;

        public BooksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Get(GeneralBookRequestDto model)
        {
            if (model == null)
                return await _context.Books.ToListAsync();

            return await _context.Books.Where(x => 
                (model.Id == null || model.Id == 0 || x.Id == model.Id)
                && (string.IsNullOrEmpty(model.Title) || x.Title.Contains(model.Title)))
                .Select(x => x)
                .ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            var books = await Get(new GeneralBookRequestDto() { Id = id });
            if (books != null && books.Count != 0)
                return books[0];
            return null;
        }

        public async Task Register(Book model)
        {
            _context.Books.Add(model);
            await _context.SaveChangesAsync();  
        }
    }
}
