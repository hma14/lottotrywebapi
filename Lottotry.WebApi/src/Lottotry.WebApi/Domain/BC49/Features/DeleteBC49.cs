namespace Lottotry.WebApi.Domain.BC49.Features
{
    using Lottotry.WebApi.Domain.BC49;
    using Lottotry.WebApi.Dtos.BC49;
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

    public static class DeleteBC49
    {
        public class DeleteBC49Command : IRequest<bool>
        {
            public int DrawNumber { get; set; }

            public DeleteBC49Command(int bC49)
            {
                DrawNumber = bC49;
            }
        }

        public class Handler : IRequestHandler<DeleteBC49Command, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(DeleteBC49Command request, CancellationToken cancellationToken)
            {
                var recordToDelete = await _db.BC49
                    .FirstOrDefaultAsync(b => b.DrawNumber == request.DrawNumber);

                if (recordToDelete == null)
                    throw new KeyNotFoundException();

                _db.BC49.Remove(recordToDelete);
                await _db.SaveChangesAsync();

                return true;
            }
        }
    }
}