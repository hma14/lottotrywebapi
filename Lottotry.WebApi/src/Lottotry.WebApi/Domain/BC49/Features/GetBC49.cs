namespace Lottotry.WebApi.Domain.BC49.Features
{
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

    public static class GetBC49
    {
        public class BC49Query : IRequest<BC49Dto>
        {
            public int DrawNumber { get; set; }

            public BC49Query(int drawNumber)
            {
                DrawNumber = drawNumber;
            }
        }

        public class Handler : IRequestHandler<BC49Query, BC49Dto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<BC49Dto> Handle(BC49Query request, CancellationToken cancellationToken)
            {
                var result = await _db.BC49
                    .ProjectTo<BC49Dto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(b => b.DrawNumber == request.DrawNumber);

                if (result == null)
                    throw new KeyNotFoundException();

                return result;
            }
        }
    }
}