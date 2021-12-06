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
    using System;
    using System.Collections.Generic;

    public static class UpdateNumber
    {
        public class UpdateNumberCommand : IRequest<bool>
        {
            public Guid Id { get; set; }
            public NumberForUpdateDto NumberToUpdate { get; set; }

            public UpdateNumberCommand(Guid number, NumberForUpdateDto newNumberData)
            {
                Id = number;
                NumberToUpdate = newNumberData;
            }
        }

        public class Handler : IRequestHandler<UpdateNumberCommand, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(UpdateNumberCommand request, CancellationToken cancellationToken)
            {
                var numberToUpdate = await _db.Numbers
                    .FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

                if (numberToUpdate == null)
                    //throw new NotFoundException("Number", request.Id);
                    throw new KeyNotFoundException();

                _mapper.Map(request.NumberToUpdate, numberToUpdate);

                await _db.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}