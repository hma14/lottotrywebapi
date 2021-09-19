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

    public static class AddLotto649
    {
        public class AddLotto649Command : IRequest<Lotto649Dto>
        {
            public Lotto649ForCreationDto Lotto649ToAdd { get; set; }

            public AddLotto649Command(Lotto649ForCreationDto lotto649ToAdd)
            {
                Lotto649ToAdd = lotto649ToAdd;
            }
        }

        public class Handler : IRequestHandler<AddLotto649Command, Lotto649Dto>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<Lotto649Dto> Handle(AddLotto649Command request, CancellationToken cancellationToken)
            {
                var lotto649 = _mapper.Map<Lotto649> (request.Lotto649ToAdd);
                _db.Lotto649.Add(lotto649);

                await _db.SaveChangesAsync();

                return await _db.Lotto649
                    .ProjectTo<Lotto649Dto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(l => l.DrawNumber == lotto649.DrawNumber);
            }
        }
    }
}