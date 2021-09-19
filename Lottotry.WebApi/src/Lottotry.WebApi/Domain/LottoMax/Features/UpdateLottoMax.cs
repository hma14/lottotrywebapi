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

    public static class UpdateLottoMax
    {
        public class UpdateLottoMaxCommand : IRequest<bool>
        {
            public int DrawNumber { get; set; }
            public LottoMaxForUpdateDto LottoMaxToUpdate { get; set; }

            public UpdateLottoMaxCommand(int lottoMax, LottoMaxForUpdateDto newLottoMaxData)
            {
                DrawNumber = lottoMax;
                LottoMaxToUpdate = newLottoMaxData;
            }
        }

        public class Handler : IRequestHandler<UpdateLottoMaxCommand, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(UpdateLottoMaxCommand request, CancellationToken cancellationToken)
            {
                var lottoMaxToUpdate = await _db.LottoMax
                    .FirstOrDefaultAsync(l => l.DrawNumber == request.DrawNumber);

                if (lottoMaxToUpdate == null)
                    throw new KeyNotFoundException();

                _mapper.Map(request.LottoMaxToUpdate, lottoMaxToUpdate);

                await _db.SaveChangesAsync();

                return true;
            }
        }
    }
}