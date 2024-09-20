using Ardalis.Result;
using Core.Domain.Dtos.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Contracts.Services
{
    public interface IBooksService
    {
        Task<Result<List<GeneralBookResponseDto>>> GetGeneralBooks(GeneralBookRequestDto model);
        Task<Result> Register(RegisterBookRequestDto model);
    }
}
