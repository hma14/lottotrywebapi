namespace Lottotry.WebApi.Domain.Numbers.Features
{

    using Lottotry.WebApi.Domain.Numbers;
    using Lottotry.WebApi.Dtos.Number;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using Lottotry.WebApi.Wrappers;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Sieve.Models;
    using Sieve.Services;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;

    public static class GetNumberList
    {
        public class NumberListQuery : IRequest<PagedList<NumberDto>>
        {
            public NumberParametersDto QueryParameters { get; set; }

            public NumberListQuery(NumberParametersDto queryParameters)
            {
                QueryParameters = queryParameters;
            }
        }

        public class Handler : IRequestHandler<NumberListQuery, PagedList<NumberDto>>
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

            public async Task<PagedList<NumberDto>> Handle(NumberListQuery request, CancellationToken cancellationToken)
            {
                var collection = _db.Numbers
                    as IQueryable<Number>;

                var sieveModel = new SieveModel
                {
                    Sorts = request.QueryParameters.SortOrder ?? "Id",
                    Filters = request.QueryParameters.Filters
                };

                var appliedCollection = _sieveProcessor.Apply(sieveModel, collection);
                var dtoCollection = appliedCollection
                    .ProjectTo<NumberDto>(_mapper.ConfigurationProvider);

                return await PagedList<NumberDto>.CreateAsync(dtoCollection,
                    request.QueryParameters.PageNumber,
                    request.QueryParameters.PageSize,
                    cancellationToken);
            }
        }
    }
}