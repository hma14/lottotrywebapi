namespace Lottotry.WebApi.Domain.Numbers.Features
{

    using Lottotry.WebApi.Domain.Numbers;
    using Lottotry.WebApi.Dtos.Number;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using Lottotry.WebApi.Domain.Numbers.Validators;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public static class AddNumber
    {
        public class AddNumberCommand : IRequest<NumberDto>
        {
            public NumberForCreationDto NumberToAdd { get; set; }

            public AddNumberCommand(NumberForCreationDto numberToAdd)
            {
                NumberToAdd = numberToAdd;
            }
        }

        public class Handler : IRequestHandler<AddNumberCommand, NumberDto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<NumberDto> Handle(AddNumberCommand request, CancellationToken cancellationToken)
            {
                var number = _mapper.Map<Number>(request.NumberToAdd);
                _db.Numbers.Add(number);

                await _db.SaveChangesAsync(cancellationToken);

                return await _db.Numbers
                    .AsNoTracking()
                    .ProjectTo<NumberDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(n => n.Id == number.Id, cancellationToken);
            }
        }
    }
}