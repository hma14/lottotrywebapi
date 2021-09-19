namespace Lottotry.WebApi.Domain.LottoMax.Features
{
    using Lottotry.WebApi.Domain.LottoMax;
    using Lottotry.WebApi.Dtos.LottoMax;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public static class DeleteLottoMax
    {
        public class DeleteLottoMaxCommand : IRequest<bool>
        {
            public int DrawNumber { get; set; }

            public DeleteLottoMaxCommand(int lottoMax)
            {
                DrawNumber = lottoMax;
            }
        }

        public class Handler : IRequestHandler<DeleteLottoMaxCommand, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(DeleteLottoMaxCommand request, CancellationToken cancellationToken)
            {
                var recordToDelete = await _db.LottoMax
                    .FirstOrDefaultAsync(l => l.DrawNumber == request.DrawNumber);

                if (recordToDelete == null)
                    throw new KeyNotFoundException();

                _db.LottoMax.Remove(recordToDelete);
                await _db.SaveChangesAsync();

                return true;
            }
        }
    }
}