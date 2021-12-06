namespace Lottotry.WebApi.Domain.LottoTypes.Features
{

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

    public static class BatchAddLottoTypes
    {
        public class BatchAddLottoTypesCommand : IRequest<bool>
        {
            public BatchAddLottoTypesCommand()
            {
            }
        }

        public class Handler : IRequestHandler<BatchAddLottoTypesCommand, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(BatchAddLottoTypesCommand request, CancellationToken cancellationToken)
            {
                // Add your command logic for your feature here!

                return true;
            }
        }
    }
}