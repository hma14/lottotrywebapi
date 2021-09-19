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

    public static class UpdateBC49
    {
        public class UpdateBC49Command : IRequest<bool>
        {
            public int DrawNumber { get; set; }
            public BC49ForUpdateDto BC49ToUpdate { get; set; }

            public UpdateBC49Command(int bC49, BC49ForUpdateDto newBC49Data)
            {
                DrawNumber = bC49;
                BC49ToUpdate = newBC49Data;
            }
        }

        public class Handler : IRequestHandler<UpdateBC49Command, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(UpdateBC49Command request, CancellationToken cancellationToken)
            {
                var bC49ToUpdate = await _db.BC49
                    .FirstOrDefaultAsync(b => b.DrawNumber == request.DrawNumber);

                if (bC49ToUpdate == null)
                    throw new KeyNotFoundException();

                _mapper.Map(request.BC49ToUpdate, bC49ToUpdate);

                await _db.SaveChangesAsync();

                return true;
            }
        }
    }
}