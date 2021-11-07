namespace Lottotry.WebApi.Domain.LottoNumbers.Features
{
    using Lottotry.WebApi.Dtos.LottoNumbers;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public static class GetLottoNumbers
    {
        public class LottoNumbersQuery : IRequest<LottoNumbersDto>
        {
            public int LottoName { get; set; }

            public LottoNumbersQuery(int lottoName)
            {
                LottoName = lottoName;
            }
        }

        public class Handler : IRequestHandler<LottoNumbersQuery, LottoNumbersDto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<LottoNumbersDto> Handle(LottoNumbersQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.LottoNumbers
                    .ProjectTo<LottoNumbersDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(l => l.LottoName == request.LottoName);

                if (result == null)
                    throw new KeyNotFoundException();

                return result;
            }
        }
    }
}