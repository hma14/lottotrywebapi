namespace Lottotry.WebApi.Domain.BC49.Features
{
    using Lottotry.WebApi.Domain.BC49;
    using Lottotry.WebApi.Dtos.BC49;
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

    public static class GetBC49List
    {
        public class BC49ListQuery : IRequest<PagedList<BC49Dto>>
        {
            public BC49ParametersDto QueryParameters { get; set; }

            public BC49ListQuery(BC49ParametersDto queryParameters)
            {
                QueryParameters = queryParameters;
            }
        }

        public class Handler : IRequestHandler<BC49ListQuery, PagedList<BC49Dto>>
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

            public async Task<PagedList<BC49Dto>> Handle(BC49ListQuery request, CancellationToken cancellationToken)
            {
                if (request.QueryParameters == null)
                    throw new ApiException("Invalid query parameters.");

                var collection = _db.BC49
                    as IQueryable<BC49>;

                var sieveModel = new SieveModel
                {
                    Sorts = request.QueryParameters.SortOrder ?? "DrawNumber",
                    Filters = request.QueryParameters.Filters
                };

                var appliedCollection = _sieveProcessor.Apply(sieveModel, collection);
                var dtoCollection = appliedCollection
                    .ProjectTo<BC49Dto>(_mapper.ConfigurationProvider);

                return await PagedList<BC49Dto>.CreateAsync(dtoCollection,
                    request.QueryParameters.PageNumber,
                    request.QueryParameters.PageSize);
            }
        }
    }
}