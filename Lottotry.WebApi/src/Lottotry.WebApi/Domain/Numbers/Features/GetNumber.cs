namespace Lottotry.WebApi.Domain.Numbers.Features
{

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

    public static class GetNumber
    {
        public class NumberQuery : IRequest<NumberDto>
        {
            public Guid Id { get; set; }

            public NumberQuery(Guid id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<NumberQuery, NumberDto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<NumberDto> Handle(NumberQuery request, CancellationToken cancellationToken)
            {
                var result = await _db.Numbers
                    .AsNoTracking()
                    .ProjectTo<NumberDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

                if (result == null)
                    //throw new NotFoundException("Number", request.Id);
                    throw new KeyNotFoundException();

                return result;
            }
        }
    }
}