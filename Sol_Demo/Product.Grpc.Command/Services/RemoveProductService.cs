using Grpc.Core;
using MediatR;
using Product.Grpc.Command.Applications.DomainCommands.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Grpc.Command.Services
{
    public class RemoveProductService : RemoveProductGrpc.RemoveProductGrpcBase
    {
        private readonly IMediator mediator = null;

        public RemoveProductService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async override Task<RemoveProductResponse> RemoveProduct(RemoveProductRequest request, ServerCallContext context)
        {
            try
            {
                RemoveProductResponse removeProductResponse = new()
                {
                    Result = await mediator.Send<bool>(new RemoveProductCommand()
                    {
                        ProductIdentity = Guid.Parse(request.ProductIdentity)
                    })
                };

                return removeProductResponse;
            }
            catch
            {
                throw;
            }
        }
    }
}