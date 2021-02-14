using MediatR;
using Product.Aggregate.Api.Applications.IntegrationEvents.Events;
using Product.Grpc.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Aggregate.Api.Applications.IntegrationEvents.Handlers
{
    public sealed class RemoveProductIntegrationEventHandler : IRequestHandler<RemoveProductIntegrationEvent, bool>
    {
        private readonly RemoveProductGrpc.RemoveProductGrpcClient client = null;

        public RemoveProductIntegrationEventHandler(RemoveProductGrpc.RemoveProductGrpcClient client)
        {
            this.client = client;
        }

        async Task<bool> IRequestHandler<RemoveProductIntegrationEvent, bool>.Handle(RemoveProductIntegrationEvent request, CancellationToken cancellationToken)
        {
            try
            {
                RemoveProductRequest removeProductRequest = new()
                {
                    ProductIdentity = request.ProductIdentity.ToString()
                };

                var result = await client.RemoveProductAsync(removeProductRequest);
                return result.Result;
            }
            catch
            {
                throw;
            }
        }
    }
}