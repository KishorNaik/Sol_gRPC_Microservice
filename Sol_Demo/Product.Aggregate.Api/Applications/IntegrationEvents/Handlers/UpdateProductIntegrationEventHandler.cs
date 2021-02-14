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
    public sealed class UpdateProductIntegrationEventHandler : IRequestHandler<UpdateProductIntegrationEvent, bool>
    {
        private readonly UpdateProductGrpc.UpdateProductGrpcClient client = null;

        public UpdateProductIntegrationEventHandler(UpdateProductGrpc.UpdateProductGrpcClient client)
        {
            this.client = client;
        }

        async Task<bool> IRequestHandler<UpdateProductIntegrationEvent, bool>.Handle(UpdateProductIntegrationEvent request, CancellationToken cancellationToken)
        {
            try
            {
                UpdateProductRequest updateProductRequest = new()
                {
                    ProductIdentity = request.ProductIdentity.ToString(),
                    ProductName = request.ProductName,
                    UnitPrice = request.UnitPrice
                };

                var result = await client.UpdateProductAsync(updateProductRequest);
                return result.Result;
            }
            catch
            {
                throw;
            }
        }
    }
}