using Core.Domain.Contracts.Repositories;
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
    public class LogsRepository : ILogsRepository
    {
        private readonly LogDbContext _context;

        public LogsRepository(LogDbContext context)
        {
            this._context = context;
        }

        public async Task AddRestApiRequestResponseLog(RestApiRequestResponse logModel)
        {
            _context.RestApiRequestResponse.Add(logModel);
            await _context.SaveChangesAsync();
        }

        public async Task AddExceptionLog(ExceptionLog logModel)
        {
            _context.ExceptionsLog.Add(logModel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RestApiRequestResponse>> GetAllRestApiRequestResponseLog()
        {
            return await _context.RestApiRequestResponse.ToListAsync();
        }

        public async Task<List<ExceptionLog>> GetAllExceptionLog()
        {
            return await _context.ExceptionsLog.ToListAsync();
        }
    }
}
