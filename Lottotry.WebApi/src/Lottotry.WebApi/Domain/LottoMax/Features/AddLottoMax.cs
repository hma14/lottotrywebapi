namespace Lottotry.WebApi.Domain.LottoMax.Features
{
    using Lottotry.WebApi.Domain.LottoMax;
    using Lottotry.WebApi.Dtos.LottoMax;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using Lottotry.WebApi.Domain.LottoMax.Validators;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public static class AddLottoMax
    {
        public class AddLottoMaxCommand : IRequest<LottoMaxDto>
        {
            public LottoMaxForCreationDto LottoMaxToAdd { get; set; }

            public AddLottoMaxCommand(LottoMaxForCreationDto lottoMaxToAdd)
            {
                LottoMaxToAdd = lottoMaxToAdd;
            }
        }

        public class Handler : IRequestHandler<AddLottoMaxCommand, LottoMaxDto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<LottoMaxDto> Handle(AddLottoMaxCommand request, CancellationToken cancellationToken)
            {
                var lottoMax = _mapper.Map<LottoMax> (request.LottoMaxToAdd);
                _db.LottoMax.Add(lottoMax);

                await _db.SaveChangesAsync();

                return await _db.LottoMax
                    .ProjectTo<LottoMaxDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(l => l.DrawNumber == lottoMax.DrawNumber);
            }
        }
    }
}