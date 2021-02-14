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
    public sealed class CreateProductIntegrationEventHandler : IRequestHandler<CreateProductIntegrationEvent, bool>
    {
        private readonly CreateProductGrpc.CreateProductGrpcClient client = null;

        public CreateProductIntegrationEventHandler(CreateProductGrpc.CreateProductGrpcClient client)
        {
            this.client = client;
        }

        async Task<bool> IRequestHandler<CreateProductIntegrationEvent, bool>.Handle(CreateProductIntegrationEvent request, CancellationToken cancellationToken)
        {
            try
            {
                var createProductRequets = new CreateProductRequest()
                {
                    ProductName = request.ProductName,
                    UnitPrice = request.UnitPrice
                };
                var result = await client.CreateProductAsync(createProductRequets);
                return result.Result;
            }
            catch
            {
                throw;
            }
        }
    }
}