using Core.Domain.Contracts.Repositories;
using Core.Domain.Contracts.Services;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services.AppLog
{
    public class LogsService : ILogsService
    {
        private readonly ILogsRepository _logRepository;

        public LogsService(ILogsRepository logRepository)
        {
            this._logRepository = logRepository;
        }
        public async Task AddRestApiRequestResponseLog(RestApiRequestResponse logModel)
        {
            await _logRepository.AddRestApiRequestResponseLog(logModel);
        }
        public async Task AddExceptionLog(ExceptionLog logModel)
        {
            await _logRepository.AddExceptionLog(logModel);
        }
    }
}
