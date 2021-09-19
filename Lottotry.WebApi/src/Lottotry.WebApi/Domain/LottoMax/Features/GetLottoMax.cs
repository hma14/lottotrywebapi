namespace Lottotry.WebApi.Domain.LottoMax.Features
{
    using Lottotry.WebApi.Dtos.LottoMax;
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

    public static class GetLottoMax
    {
        public class LottoMaxQuery : IRequest<LottoMaxDto>
        {
            public int DrawNumber { get; set; }

            public LottoMaxQuery(int drawNumber)
            {
                DrawNumber = drawNumber;
            }
        }

        public class Handler : IRequestHandler<LottoMaxQuery, LottoMaxDto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<LottoMaxDto> Handle(LottoMaxQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.LottoMax
                    .ProjectTo<LottoMaxDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(l => l.DrawNumber == request.DrawNumber);

                if (result == null)
                    throw new KeyNotFoundException();

                return result;
            }
        }
    }
}