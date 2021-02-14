using AutoMapper;
using MediatR;
using Product.Grpc.Command.Applications.DomainCommands.Commands;
using Product.Grpc.Command.Infrastructures.RepositoryCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Grpc.Command.Applications.DomainCommands.Handlers
{
    public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private IMediator mediator = null;
        private IMapper mapper = null;

        public UpdateProductCommandHandler(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateProductCommand, bool>.Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return mediator.Send<bool>(this.mapper.Map<UpdateProductRepositoryCommand>(request));
            }
            catch
            {
                throw;
            }
        }
    }
}