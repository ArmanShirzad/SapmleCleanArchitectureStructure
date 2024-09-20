using Core.Domain.Contracts.Repositories;
using Core.Domain.Dtos.Books;
using Core.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Infrastructure.Persistence.Mocks
{
    internal class MockBooksRepository
    {
        public static Mock<IBooksRepository> GetMock()
        {
            var mock = new Mock<IBooksRepository>();
            var books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Title = "Book 1",
                    UseageType = Book.Type.General,
                    Writers = new List<Writer>()
                    {
                        new Writer()
                        {
                            Id = 1,
                            FullName = "Ali Akbari",
                        }
                    }
                },
                new Book()
                {
                    Id = 2,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Title = "Book 2",
                    UseageType = Book.Type.General,
                    Writers = new List<Writer>()
                    {
                        new Writer()
                        {
                            Id = 2,
                            FullName = "Yashar Mohajer",
                        }
                    }
                }
            };

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .ReturnsAsync((int id) => books.Single(x => x.Id == id));

            mock.Setup(m => m.Get(It.IsAny<GeneralBookRequestDto>()))
                .ReturnsAsync((GeneralBookRequestDto model) =>
                {
                    if(model == null)
                    {
                        return books;
                    }
                    return books.Where(x => (model.Id == null || model.Id == 0 || x.Id == model.Id)
                        && (string.IsNullOrEmpty(model.Title) || x.Title.Contains(model.Title)))
                        .Select(x => x)
                        .ToList();
                });

            mock.Setup(m => m.Register(It.IsAny<Book>()))
                .Callback((Book model) => { books.Add(model); });

            return mock;
        }
    }
}
