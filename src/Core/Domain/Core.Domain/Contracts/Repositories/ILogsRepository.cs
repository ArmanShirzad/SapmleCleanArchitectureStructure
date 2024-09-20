using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Contracts.Repositories
{
    public interface ILogsRepository
    {
        Task AddRestApiRequestResponseLog(RestApiRequestResponse logModel);
        Task AddExceptionLog(ExceptionLog logModel);
        Task<List<RestApiRequestResponse>> GetAllRestApiRequestResponseLog();
        Task<List<ExceptionLog>> GetAllExceptionLog();
    }
}
