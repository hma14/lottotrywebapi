namespace Lottotry.WebApi.Domain.LottoMax.Features
{
    using Lottotry.WebApi.Domain.LottoMax;
    using Lottotry.WebApi.Dtos.LottoMax;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using Lottotry.WebApi.Wrappers;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Sieve.Models;
    using Sieve.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public static class GetLottoMaxList
    {
        public class LottoMaxListQuery : IRequest<PagedList<LottoMaxDto>>
        {
            public LottoMaxParametersDto QueryParameters { get; set; }

            public LottoMaxListQuery(LottoMaxParametersDto queryParameters)
            {
                QueryParameters = queryParameters;
            }
        }

        public class Handler : IRequestHandler<LottoMaxListQuery, PagedList<LottoMaxDto>>
        {
            private readonly LottotryDbContext _db;
            private readonly SieveProcessor _sieveProcessor;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper, SieveProcessor sieveProcessor)
            {
                _mapper = mapper;
                _db = db;
                _sieveProcessor = sieveProcessor;
            }

            public async Task<PagedList<LottoMaxDto>> Handle(LottoMaxListQuery request, CancellationToken cancellationToken)
            {
                if (request.QueryParameters == null)
                    throw new ApiException("Invalid query parameters.");

                var collection = _db.LottoMax
                    as IQueryable<LottoMax>;

                var sieveModel = new SieveModel
                {
                    Sorts = request.QueryParameters.SortOrder ?? "DrawNumber",
                    Filters = request.QueryParameters.Filters
                };

                var appliedCollection = _sieveProcessor.Apply(sieveModel, collection);
                var dtoCollection = appliedCollection
                    .ProjectTo<LottoMaxDto>(_mapper.ConfigurationProvider);

                return await PagedList<LottoMaxDto>.CreateAsync(dtoCollection,
                    request.QueryParameters.PageNumber,
                    request.QueryParameters.PageSize,
                    cancellationToken);
            }
        }
    }
}