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

    public static class UpdateLottoNumbers
    {
        public class UpdateLottoNumbersCommand : IRequest<bool>
        {
            public int LottoName { get; set; }
            public LottoNumbersForUpdateDto LottoNumbersToUpdate { get; set; }

            public UpdateLottoNumbersCommand(int lottoNumbers, LottoNumbersForUpdateDto newLottoNumbersData)
            {
                LottoName = lottoNumbers;
                LottoNumbersToUpdate = newLottoNumbersData;
            }
        }

        public class Handler : IRequestHandler<UpdateLottoNumbersCommand, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(UpdateLottoNumbersCommand request, CancellationToken cancellationToken)
            {
                var lottoNumbersToUpdate = await _db.LottoNumbers
                    .FirstOrDefaultAsync(l => l.LottoName == request.LottoName);

                if (lottoNumbersToUpdate == null)
                    throw new KeyNotFoundException();

                _mapper.Map(request.LottoNumbersToUpdate, lottoNumbersToUpdate);

                await _db.SaveChangesAsync();

                return true;
            }
        }
    }
}