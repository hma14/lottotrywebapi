namespace Lottotry.WebApi.Domain.LottoNumberss.Features
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

    public static class BatchAddLottoNumbers
    {
        public class BatchAddLottoNumbersCommand : IRequest<bool>
        {
            public BatchAddLottoNumbersCommand()
            {
            }
        }

        public class Handler : IRequestHandler<BatchAddLottoNumbersCommand, bool>
        {
            private readonly LottotryDbContext _db;
            private readonly IMapper _mapper;

            public Handler(LottotryDbContext db, IMapper mapper)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<bool> Handle(BatchAddLottoNumbersCommand request, CancellationToken cancellationToken)
            {
                // Add your command logic for your feature here!

                return true;
            }
        }
    }
}