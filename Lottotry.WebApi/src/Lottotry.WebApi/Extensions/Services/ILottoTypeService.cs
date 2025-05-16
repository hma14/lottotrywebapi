using Lottotry.WebApi.Dtos.LottoType;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace Lottotry.WebApi.Extensions.Services
{
    public interface ILottoTypeService
    {
        Task<bool> LottoTypeExistsAsync(Guid id, CancellationToken cancellationToken = default);
        Task<LottoTypeDto> GetLottoTypeAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
