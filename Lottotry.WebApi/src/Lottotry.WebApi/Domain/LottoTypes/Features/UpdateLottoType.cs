namespace Lottotry.WebApi.Domain.LottoTypes.Features
{

    using Lottotry.WebApi.Domain.LottoTypes;
    using Lottotry.WebApi.Dtos.LottoType;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using Lottotry.WebApi.Domain.LottoTypes.Validators;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;

    public static class UpdateLottoType
    {
        public class UpdateLottoTypeCommand : IRequest<bool>
        {
            public Guid Id { get; set; }
            public LottoTypeForUpdateDto LottoTypeToUpdate { get; set; }

            public UpdateLottoTypeCommand(Guid lottoType, LottoTypeForUpdateDto newLottoTypeData)
            {
                Id = lottoType;
                LottoTypeToUpdate = newLottoTypeData;
            }
        }

        public class Handler : IRequestHandler<UpdateLottoTypeCommand, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(UpdateLottoTypeCommand request, CancellationToken cancellationToken)
            {
                var lottoTypeToUpdate = await _db.LottoTypes
                    .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

                if (lottoTypeToUpdate == null)
                    //throw new NotFoundException("LottoType", request.Id);
                    throw new KeyNotFoundException();

                _mapper.Map(request.LottoTypeToUpdate, lottoTypeToUpdate);

                await _db.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}