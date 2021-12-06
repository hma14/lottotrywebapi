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

    public static class AddLottoType
    {
        public class AddLottoTypeCommand : IRequest<LottoTypeDto>
        {
            public LottoTypeForCreationDto LottoTypeToAdd { get; set; }

            public AddLottoTypeCommand(LottoTypeForCreationDto lottoTypeToAdd)
            {
                LottoTypeToAdd = lottoTypeToAdd;
            }
        }

        public class Handler : IRequestHandler<AddLottoTypeCommand, LottoTypeDto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<LottoTypeDto> Handle(AddLottoTypeCommand request, CancellationToken cancellationToken)
            {
                var lottoType = _mapper.Map<LottoType>(request.LottoTypeToAdd);
                _db.LottoTypes.Add(lottoType);

                await _db.SaveChangesAsync(cancellationToken);

                return await _db.LottoTypes
                    .AsNoTracking()
                    .ProjectTo<LottoTypeDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(l => l.Id == lottoType.Id, cancellationToken);
            }
        }
    }
}