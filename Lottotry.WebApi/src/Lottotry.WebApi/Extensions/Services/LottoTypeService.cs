using AutoMapper;
using Lottotry.WebApi.Databases;
using Lottotry.WebApi.Dtos.LottoType;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lottotry.WebApi.Extensions.Services
{
    public class LottoTypeService : ILottoTypeService
    {
        private readonly LottotryDbContext _dbContext;
        private readonly IMapper _mapper;
        public LottoTypeService(LottotryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<LottoTypeDto> GetLottoTypeAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var lottoType = await _dbContext.LottoTypes.FindAsync(new object[] { id }, cancellationToken);
            if (lottoType == null) 
                return null;

            var dto = _mapper.Map<LottoTypeDto>(lottoType);
            
            return dto;
            
        }

        public async Task<bool> LottoTypeExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty) 
                return false;

            return await _dbContext.LottoTypes.AnyAsync(t => t.Id == id, cancellationToken);
        }
    }
}
