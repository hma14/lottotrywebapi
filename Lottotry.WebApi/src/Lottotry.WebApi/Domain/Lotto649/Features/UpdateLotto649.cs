namespace Lottotry.WebApi.Domain.Lotto649.Features
{
    using Lottotry.WebApi.Domain.Lotto649;
    using Lottotry.WebApi.Dtos.Lotto649;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Databases;
    using Lottotry.WebApi.Domain.Lotto649.Validators;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public static class UpdateLotto649
    {
        public class UpdateLotto649Command : IRequest<bool>
        {
            public int DrawNumber { get; set; }
            public Lotto649ForUpdateDto Lotto649ToUpdate { get; set; }

            public UpdateLotto649Command(int lotto649, Lotto649ForUpdateDto newLotto649Data)
            {
                DrawNumber = lotto649;
                Lotto649ToUpdate = newLotto649Data;
            }
        }

        public class Handler : IRequestHandler<UpdateLotto649Command, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(UpdateLotto649Command request, CancellationToken cancellationToken)
            {
                var lotto649ToUpdate = await _db.Lotto649
                    .FirstOrDefaultAsync(l => l.DrawNumber == request.DrawNumber);

                if (lotto649ToUpdate == null)
                    throw new KeyNotFoundException();

                _mapper.Map(request.Lotto649ToUpdate, lotto649ToUpdate);

                await _db.SaveChangesAsync();

                return true;
            }
        }
    }
}