namespace Lottotry.WebApi.Domain.BC49.Features
{
    using Lottotry.WebApi.Domain.BC49;
    using Lottotry.WebApi.Dtos.BC49;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using Lottotry.WebApi.Domain.BC49.Validators;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public static class AddBC49
    {
        public class AddBC49Command : IRequest<BC49Dto>
        {
            public BC49ForCreationDto BC49ToAdd { get; set; }

            public AddBC49Command(BC49ForCreationDto bC49ToAdd)
            {
                BC49ToAdd = bC49ToAdd;
            }
        }

        public class Handler : IRequestHandler<AddBC49Command, BC49Dto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<BC49Dto> Handle(AddBC49Command request, CancellationToken cancellationToken)
            {
                var bC49 = _mapper.Map<BC49> (request.BC49ToAdd);
                _db.BC49.Add(bC49);

                await _db.SaveChangesAsync();

                return await _db.BC49
                    .ProjectTo<BC49Dto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(b => b.DrawNumber == bC49.DrawNumber);
            }
        }
    }
}