using Core.Domain.Contracts.Repositories;
using Core.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Infrastructure.Persistence.Mocks;

namespace UnitTests.Infrastructure.Persistence
{
    public class LogsRepositoryUnitTests
    {
        private readonly Mock<ILogsRepository> _repository;

        public LogsRepositoryUnitTests()
        {
            _repository = MockLogsRepository.GetMock();
        }

        [Fact]
        public async Task Register_WithValidModel_AddsRestApiRequestResponseToContext()
        {
            // Arrange
            long id = 10L;
            var model = new RestApiRequestResponse() { DateTime = DateTime.Now, Id = id };

            // Act
            await _repository.Object.AddRestApiRequestResponseLog(model);
            var result = await _repository.Object.GetAllRestApiRequestResponseLog();

            // Assert
            Assert.NotNull(result.Single(x => x.Id == id));
        }

        [Fact]
        public async Task Register_WithValidModel_AddsExceptionLogToContext()
        {
            // Arrange
            long id = 10L;
            var model = new ExceptionLog() { DateTime = DateTime.Now, Id = id };

            // Act
            await _repository.Object.AddExceptionLog(model);
            var result = await _repository.Object.GetAllExceptionLog();

            // Assert
            Assert.NotNull(result.Single(x => x.Id == id));
        }
    }
}
