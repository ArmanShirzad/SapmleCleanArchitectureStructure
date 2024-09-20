using Core.Domain.Contracts.Repositories;
using Core.Domain.Contracts.Services;
using Core.Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Extentions
{
    public static class PersistenceServicesConfig
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // config of ef-core
            services.AddDbContext<ApplicationDbContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("MainConnection"));
            });

            services.AddDbContext<LogDbContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("LogConnection"));
            });

            // config identity
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireLowercase = true;
                config.Password.RequireUppercase = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // add services
            services.AddScoped<ILogsRepository, LogsRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IFileStorageService, FileStorageService>();

        }

    }
}
