namespace Lottotry.WebApi.Domain.Lotto649.Features
{
    using Lottotry.WebApi.Domain.Lotto649;
    using Lottotry.WebApi.Dtos.Lotto649;
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

    public static class DeleteLotto649
    {
        public class DeleteLotto649Command : IRequest<bool>
        {
            public int DrawNumber { get; set; }

            public DeleteLotto649Command(int lotto649)
            {
                DrawNumber = lotto649;
            }
        }

        public class Handler : IRequestHandler<DeleteLotto649Command, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(DeleteLotto649Command request, CancellationToken cancellationToken)
            {
                var recordToDelete = await _db.Lotto649
                    .FirstOrDefaultAsync(l => l.DrawNumber == request.DrawNumber);

                if (recordToDelete == null)
                    throw new KeyNotFoundException();

                _db.Lotto649.Remove(recordToDelete);
                await _db.SaveChangesAsync();

                return true;
            }
        }
    }
}