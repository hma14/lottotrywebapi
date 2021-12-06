namespace Lottotry.WebApi.Domain.LottoTypes.Features
{

    using Lottotry.WebApi.Dtos.LottoType;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class GetLottoTypeByLottoName
    {
        public class LottoTypeQuery : IRequest<LottoTypeDto>
        {
            public int LottoName { get; set; }

            public LottoTypeQuery(int lottoName)
            {
                LottoName = lottoName;
            }
        }

        public class Handler : IRequestHandler<LottoTypeQuery, LottoTypeDto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<LottoTypeDto> Handle(LottoTypeQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.LottoTypes
                    .AsNoTracking()
                    .ProjectTo<LottoTypeDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(l => l.LottoName == request.LottoName, cancellationToken);

                if (result == null)
                    //throw new NotFoundException("LottoType", request.Id);
                    throw new KeyNotFoundException();
                result.Numbers = result.Numbers.OrderBy(x => x.Value).ToList();
                return result;
            }
        }
    }
}