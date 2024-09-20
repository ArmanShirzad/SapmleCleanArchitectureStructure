using Core.Domain.Contracts.Repositories;
using Core.Domain.Dtos.Books;
using Core.Domain.Entities;
using Moq;
using UnitTests.Infrastructure.Persistence.Mocks;

namespace UnitTests.Infrastructure.Persistence
{
    public class BooksRepositoryUnitTests
    {
        private readonly Mock<IBooksRepository> _repository;

        public BooksRepositoryUnitTests()
        {
            _repository = MockBooksRepository.GetMock();
        }

        [Fact]
        public async Task Get_NullModel_ReturnsAllOfBooks()
        {
            // Act
            var result = await _repository.Object.Get(null);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Get_WithValidModel_ReturnsFilteredBooks()
        {
            // Arrange
            var model = new GeneralBookRequestDto() { Id = 1 };

            // Act
            var result = await _repository.Object.Get(model);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetById_WithValidId_ReturnsBook()
        {
            // Arrange
            int id = 2;

            // Act
            var result = await _repository.Object.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Register_WithValidModel_AddsBookToContext()
        {
            // Arrange
            int id = 5;
            var model = new Book() { Id = id, Title = "Test Book" };

            // Act
            await _repository.Object.Register(model);
            var bookObj = await _repository.Object.GetById(id);

            // Assert
            Assert.Equal(id, bookObj.Id);
        }
    }
}
