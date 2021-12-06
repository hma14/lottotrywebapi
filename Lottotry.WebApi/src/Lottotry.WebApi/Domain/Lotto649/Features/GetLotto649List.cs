namespace Lottotry.WebApi.Domain.Lotto649.Features
{
    using Lottotry.WebApi.Domain.Lotto649;
    using Lottotry.WebApi.Dtos.Lotto649;
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

    public static class GetLotto649List
    {
        public class Lotto649ListQuery : IRequest<PagedList<Lotto649Dto>>
        {
            public Lotto649ParametersDto QueryParameters { get; set; }

            public Lotto649ListQuery(Lotto649ParametersDto queryParameters)
            {
                QueryParameters = queryParameters;
            }
        }

        public class Handler : IRequestHandler<Lotto649ListQuery, PagedList<Lotto649Dto>>
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

            public async Task<PagedList<Lotto649Dto>> Handle(Lotto649ListQuery request, CancellationToken cancellationToken)
            {
                if (request.QueryParameters == null)
                    throw new ApiException("Invalid query parameters.");

                var collection = _db.Lotto649
                    as IQueryable<Lotto649>;

                var sieveModel = new SieveModel
                {
                    Sorts = request.QueryParameters.SortOrder ?? "DrawNumber",
                    Filters = request.QueryParameters.Filters
                };

                var appliedCollection = _sieveProcessor.Apply(sieveModel, collection);
                var dtoCollection = appliedCollection
                    .ProjectTo<Lotto649Dto>(_mapper.ConfigurationProvider);

                return await PagedList<Lotto649Dto>.CreateAsync(dtoCollection,
                    request.QueryParameters.PageNumber,
                    request.QueryParameters.PageSize,
                    cancellationToken
                    );
            }
        }
    }
}