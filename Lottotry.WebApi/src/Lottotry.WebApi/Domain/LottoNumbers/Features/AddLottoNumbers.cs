namespace Lottotry.WebApi.Domain.LottoNumbers.Features
{
    using Lottotry.WebApi.Domain.LottoNumbers;
    using Lottotry.WebApi.Dtos.LottoNumbers;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using Lottotry.WebApi.Domain.LottoNumbers.Validators;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public static class AddLottoNumbers
    {
        public class AddLottoNumbersCommand : IRequest<LottoNumbersDto>
        {
            public LottoNumbersForCreationDto LottoNumbersToAdd { get; set; }

            public AddLottoNumbersCommand(LottoNumbersForCreationDto lottoNumbersToAdd)
            {
                LottoNumbersToAdd = lottoNumbersToAdd;
            }
        }

        public class Handler : IRequestHandler<AddLottoNumbersCommand, LottoNumbersDto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<LottoNumbersDto> Handle(AddLottoNumbersCommand request, CancellationToken cancellationToken)
            {
                var lottoNumbers = _mapper.Map<LottoNumbers> (request.LottoNumbersToAdd);
                _db.LottoNumbers.Add(lottoNumbers);

                await _db.SaveChangesAsync();

                return await _db.LottoNumbers
                    .ProjectTo<LottoNumbersDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(l => l.LottoName == lottoNumbers.LottoName);
            }
        }
    }
}