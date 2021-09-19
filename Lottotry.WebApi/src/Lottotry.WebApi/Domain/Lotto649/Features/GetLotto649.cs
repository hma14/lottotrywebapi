namespace Lottotry.WebApi.Domain.Lotto649.Features
{
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

    public static class GetLotto649
    {
        public class Lotto649Query : IRequest<Lotto649Dto>
        {
            public int DrawNumber { get; set; }

            public Lotto649Query(int drawNumber)
            {
                DrawNumber = drawNumber;
            }
        }

        public class Handler : IRequestHandler<Lotto649Query, Lotto649Dto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<Lotto649Dto> Handle(Lotto649Query request, CancellationToken cancellationToken)
            {
                var result = await _db.Lotto649
                    .ProjectTo<Lotto649Dto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(l => l.DrawNumber == request.DrawNumber);

                if (result == null)
                    throw new KeyNotFoundException();

                return result;
            }
        }
    }
}