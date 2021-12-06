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
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public static class AddNumberList
    {
        public class AddNumberListCommand : IRequest<IEnumerable<NumberDto>>
        {
            public IEnumerable<NumberForCreationDto> NumberListToAdd { get; set; }
            public Guid LottoTypeId { get; set; }

            public AddNumberListCommand(IEnumerable<NumberForCreationDto> numberListListToAdd, Guid lottoTypeId)
            {
                NumberListToAdd = numberListListToAdd;
                LottoTypeId = lottoTypeId;
            }
        }

        public class Handler : IRequestHandler<AddNumberListCommand, IEnumerable<NumberDto>>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<IEnumerable<NumberDto>> Handle(AddNumberListCommand request, CancellationToken cancellationToken)
            {
                var numberList = _mapper.Map<IEnumerable<Number>>(request.NumberListToAdd);
                numberList = numberList.ToList().Select(n => { n.LottoTypeId = request.LottoTypeId; return n; });


                _db.Numbers.AddRange(numberList);

                await _db.SaveChangesAsync(cancellationToken);

                var result = _db.Numbers.Where(n => numberList.Select(n => n.Id).Contains(n.Id));
                return _mapper.Map<IEnumerable<NumberDto>>(result);
            }
        }
    }
}