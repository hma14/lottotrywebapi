namespace Lottotry.WebApi.Domain.LottoTypes.Features
{

    using Lottotry.WebApi.Domain.LottoTypes;
    using Lottotry.WebApi.Dtos.LottoType;
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

    public static class DeleteLottoType
    {
        public class DeleteLottoTypeCommand : IRequest<bool>
        {
            public Guid Id { get; set; }

            public DeleteLottoTypeCommand(Guid lottoType)
            {
                Id = lottoType;
            }
        }

        public class Handler : IRequestHandler<DeleteLottoTypeCommand, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(DeleteLottoTypeCommand request, CancellationToken cancellationToken)
            {
                var recordToDelete = await _db.LottoTypes
                    .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

                if (recordToDelete == null)
                    //throw new NotFoundException("LottoType", request.Id);
                    throw new KeyNotFoundException();

                _db.LottoTypes.Remove(recordToDelete);
                await _db.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}