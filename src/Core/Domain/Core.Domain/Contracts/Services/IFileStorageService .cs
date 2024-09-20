using Ardalis.Result;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Contracts.Services
{
    public interface IFileStorageService
    {
        Task<Result<string>> SaveFileAsync( IFormFile file ,string filePath);
        Task<Result> DeleteFileAsync(string filePath);
    }
}
