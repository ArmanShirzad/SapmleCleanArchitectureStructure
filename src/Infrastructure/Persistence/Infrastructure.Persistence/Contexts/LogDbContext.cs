using Core.Domain.Common;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class LogDbContext : DbContext
    {
        public DbSet<RestApiRequestResponse> RestApiRequestResponse { get; set; }
        public DbSet<ExceptionLog> ExceptionsLog { get; set; }

        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {

        }
    }
}
