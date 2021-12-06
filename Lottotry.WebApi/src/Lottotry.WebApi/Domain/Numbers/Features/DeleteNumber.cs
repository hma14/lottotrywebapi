namespace Lottotry.WebApi.Domain.Numbers.Features
{

    using Lottotry.WebApi.Domain.Numbers;
    using Lottotry.WebApi.Dtos.Number;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;

    public static class DeleteNumber
    {
        public class DeleteNumberCommand : IRequest<bool>
        {
            public Guid Id { get; set; }

            public DeleteNumberCommand(Guid number)
            {
                Id = number;
            }
        }

        public class Handler : IRequestHandler<DeleteNumberCommand, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(DeleteNumberCommand request, CancellationToken cancellationToken)
            {
                var recordToDelete = await _db.Numbers
                    .FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

                if (recordToDelete == null)
                    //throw new NotFoundException("Number", request.Id);
                    throw new KeyNotFoundException();

                _db.Numbers.Remove(recordToDelete);
                await _db.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}