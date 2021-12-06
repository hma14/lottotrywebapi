namespace Lottotry.WebApi.Domain.LottoTypes.Features
{

    using Lottotry.WebApi.Domain.LottoTypes;
    using Lottotry.WebApi.Dtos.LottoType;
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
    using System.Collections.Generic;

    public static class GetLottoTypeList
    {
        public class LottoTypeListQuery : IRequest<PagedList<LottoTypeDto>>
        {
            public LottoTypeParametersDto QueryParameters { get; set; }

            public LottoTypeListQuery(LottoTypeParametersDto queryParameters)
            {
                QueryParameters = queryParameters;
            }
        }

        public class Handler : IRequestHandler<LottoTypeListQuery, PagedList<LottoTypeDto>>
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
#if true

            public async Task<PagedList<LottoTypeDto>> Handle(LottoTypeListQuery request, CancellationToken cancellationToken)
            {
                var collection = _db.LottoTypes.Where(x => request.QueryParameters.LottoName > 0 ? x.LottoName == (int) request.QueryParameters.LottoName : true) as IQueryable<LottoType>;

                var sieveModel = new SieveModel
                {
                    Sorts = request.QueryParameters.SortOrder ?? "DrawDate",
                    Filters = request.QueryParameters.Filters
                };

                var appliedCollection = _sieveProcessor.Apply(sieveModel, collection);
                var dtoCollection = appliedCollection
                    .ProjectTo<LottoTypeDto>(_mapper.ConfigurationProvider);


                return await PagedList<LottoTypeDto>.CreateAsync(   dtoCollection.OrderByDescending(x => x.DrawNumber),
                                                                    request.QueryParameters.PageNumber,
                                                                    request.QueryParameters.PageSize,
                                                                    cancellationToken);
            }
#else
            public async Task<PagedList<LottoTypeDto>> Handle(LottoTypeListQuery request, CancellationToken cancellationToken)
            {
                if (request.QueryParameters == null)
                    throw new ApiException("Invalid query parameters.");

                var collection = _db.LottoTypes.Where(x => x.LottoName == (int)request.QueryParameters.LottoName)
                    as IQueryable<LottoType>;


                // my changes
                List<LottoTypeDto> list = new();
                var drawNumbers = collection.GroupBy(x => x.DrawNumber).Select(g => g.Key).AsEnumerable();
                List<int> drawList = drawNumbers.ToList();

                foreach (var dn in drawList)
                {
                    List<LottoTypeDto> tmp = new();
                    collection.ProjectTo<LottoTypeDto>(_mapper.ConfigurationProvider).Where(x => x.DrawNumber == dn).ToList().All(y => { tmp.Add(y); return true; });

                    var item = new LottoTypeDto
                    {
                        Id = tmp.First().Id,
                        LottoName = tmp.First().LottoName,
                        DrawNumber = tmp.First().DrawNumber,
                        DrawDate = tmp.First().DrawDate,
                        NumberRange = tmp.First().NumberRange,
                        Numbers = tmp.First().Numbers.OrderBy(x => x.Value).ToList(),
                    };
                    list.Add(item);
                }


                var sieveModel = new SieveModel
                {
                    Sorts = request.QueryParameters.SortOrder ?? "LottoName",
                    Filters = request.QueryParameters.Filters
                };

                var dtoCollection = _sieveProcessor.Apply(sieveModel, list.AsQueryable());

                // sort always by DrawNumber Descending
                return await Task.FromResult(PagedList<LottoTypeDto>
                    .Create(dtoCollection.OrderByDescending(x => x.DrawNumber),
                            request.QueryParameters.PageNumber,
                            request.QueryParameters.PageSize));
            }

#endif

        }
    }
}