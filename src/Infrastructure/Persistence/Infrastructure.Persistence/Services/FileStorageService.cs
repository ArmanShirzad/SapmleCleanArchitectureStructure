using Ardalis.Result;

using Core.Domain.Contracts.Services;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Services
{
    public class FileStorageService : IFileStorageService
    {
        public async Task<Result> DeleteFileAsync(string filePath)
        {
            try
            {
                var fullPath = Path.Combine("wwwroot", filePath);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                return Result.Success();
            }
            catch (Exception ex)
            {

                return Result.Error(new[] { ex.Message });

            }
        }

        public async Task<Result<string>> SaveFileAsync(IFormFile file, string folderName)
        {
            try
            {
                var uploadsFolder = Path.Combine("wwwroot", folderName);
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);

                var relativePath = Path.Combine(folderName, uniqueFileName).Replace("\\", "/");
                return Result<string>.Success(relativePath);
            }
            catch (Exception ex)
            {
                return Result<string>.Error(new[] { ex.Message });
            }
        }
    }
}
