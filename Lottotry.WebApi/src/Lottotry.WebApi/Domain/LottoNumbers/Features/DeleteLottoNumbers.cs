namespace Lottotry.WebApi.Domain.LottoNumbers.Features
{
    using Lottotry.WebApi.Domain.LottoNumbers;
    using Lottotry.WebApi.Dtos.LottoNumbers;
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

    public static class DeleteLottoNumbers
    {
        public class DeleteLottoNumbersCommand : IRequest<bool>
        {
            public int LottoName { get; set; }

            public DeleteLottoNumbersCommand(int lottoNumbers)
            {
                LottoName = lottoNumbers;
            }
        }

        public class Handler : IRequestHandler<DeleteLottoNumbersCommand, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(DeleteLottoNumbersCommand request, CancellationToken cancellationToken)
            {
                var recordToDelete = await _db.LottoNumbers
                    .FirstOrDefaultAsync(l => l.LottoName == request.LottoName);

                if (recordToDelete == null)
                    throw new KeyNotFoundException();

                _db.LottoNumbers.Remove(recordToDelete);
                await _db.SaveChangesAsync();

                return true;
            }
        }
    }
}