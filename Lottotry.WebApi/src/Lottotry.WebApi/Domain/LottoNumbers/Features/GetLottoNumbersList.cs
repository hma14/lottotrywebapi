namespace Lottotry.WebApi.Domain.LottoNumbers.Features
{
    using Lottotry.WebApi.Domain.LottoNumbers;
    using Lottotry.WebApi.Dtos.LottoNumbers;
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
    using Lottotry.WebApi.Dtos;
    using Microsoft.EntityFrameworkCore;

    public static class GetLottoNumbersList
    {
        public class LottoNumbersListQuery : IRequest<PagedList<LottoNumbersResponseDto>>
        {
            public LottoNumbersParametersDto QueryParameters { get; set; }

            public LottoNumbersListQuery(LottoNumbersParametersDto queryParameters)
            {
                QueryParameters = queryParameters;
            }
        }

        public class Handler : IRequestHandler<LottoNumbersListQuery, PagedList<LottoNumbersResponseDto>>
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

            public async Task<PagedList<LottoNumbersResponseDto>> Handle(LottoNumbersListQuery request, CancellationToken cancellationToken)
            {
                if (request.QueryParameters == null)
                    throw new ApiException("Invalid query parameters.");

                var collection = _db.LottoNumbers.Where(x => x.LottoName == (int) request.QueryParameters.LottoName)
                    as IQueryable<LottoNumbers>;


                // my changes
                List<LottoNumbersResponseDto> list = new();
                var drawNumbers = collection.GroupBy(x => x.DrawNumber).Select(g => g.Key).AsEnumerable();
                List<int> drawList = drawNumbers.ToList();

                foreach (var dn in drawList)
                {
                    List<LottoNumbersDto> tmp = new();
                    collection.ProjectTo<LottoNumbersDto>(_mapper.ConfigurationProvider).Where(x => x.DrawNumber == dn).ToList().All(y => { tmp.Add(y); return true; });

                    var item = new LottoNumbersResponseDto
                    {
                        DrawNumber = tmp.First().DrawNumber,
                        DrawDate = tmp.First().DrawDate,
                        Numbers = tmp,
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
                return await Task.FromResult(PagedList<LottoNumbersResponseDto>
                    .Create(dtoCollection.OrderByDescending(x => x.DrawNumber), request.QueryParameters.PageNumber, request.QueryParameters.PageSize));
            }
        }
    }
}