using Core.Domain.Contracts.Repositories;
using Core.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Infrastructure.Persistence.Mocks
{
    internal class MockLogsRepository
    {
        public static Mock<ILogsRepository> GetMock()
        {
            var mock = new Mock<ILogsRepository>();

            var exceptionLogs = new List<ExceptionLog>();
            var restApiRequestResponses = new List<RestApiRequestResponse>();

            mock.Setup(m => m.AddExceptionLog(It.IsAny<ExceptionLog>()))
               .Callback((ExceptionLog model) => { exceptionLogs.Add(model); });

            mock.Setup(m => m.AddRestApiRequestResponseLog(It.IsAny<RestApiRequestResponse>()))
               .Callback((RestApiRequestResponse model) => { restApiRequestResponses.Add(model); });

            mock.Setup(m => m.GetAllRestApiRequestResponseLog())
               .ReturnsAsync(() => restApiRequestResponses);

            mock.Setup(m => m.GetAllExceptionLog())
              .ReturnsAsync(() => exceptionLogs);

            return mock;
        }
    }
}
