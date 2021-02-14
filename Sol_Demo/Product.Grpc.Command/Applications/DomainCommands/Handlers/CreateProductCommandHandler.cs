using MediatR;
using Product.Grpc.Command.Applications.DomainCommands.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DapperFluent;
using Framework.SqlClient.Helper;
using Product.Shared.DomainEntity;
using AutoMapper;
using Product.Grpc.Command.Infrastructures.RepositoryCommand;

namespace Product.Grpc.Command.Applications.DomainCommands.Handlers
{
    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IMediator mediator = null;
        private readonly IMapper mapper = null;

        public CreateProductCommandHandler(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        Task<bool> IRequestHandler<CreateProductCommand, bool>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return mediator.Send<bool>(mapper.Map<CreateProductRepositoryCommand>(request));
            }
            catch
            {
                throw;
            }
        }
    }
}