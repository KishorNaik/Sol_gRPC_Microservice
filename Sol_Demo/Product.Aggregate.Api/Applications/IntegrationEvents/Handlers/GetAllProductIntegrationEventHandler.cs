using Grpc.Core;
using MediatR;
using Product.Aggregate.Api.Applications.IntegrationEvents.Events;
using Product.Grpc.Query;
using Product.Shared.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Aggregate.Api.Applications.IntegrationEvents.Handlers
{
    public sealed class GetAllProductIntegrationEventHandler : IRequestHandler<GetAllProductIntegrationEvent, List<ProductModel>>
    {
        private readonly GetAllProductGrpc.GetAllProductGrpcClient client = null;

        public GetAllProductIntegrationEventHandler(GetAllProductGrpc.GetAllProductGrpcClient client)
        {
            this.client = client;
        }

        async Task<List<ProductModel>> IRequestHandler<GetAllProductIntegrationEvent, List<ProductModel>>.Handle(GetAllProductIntegrationEvent request, CancellationToken cancellationToken)
        {
            try
            {
                List<ProductModel> listProduct = new List<ProductModel>();

                using var call = client.GetAllProduct(new Google.Protobuf.WellKnownTypes.Empty());
                await foreach (var data in call.ResponseStream.ReadAllAsync())
                {
                    listProduct.Add(new ProductModel()
                    {
                        ProductIdentity = Guid.Parse(data.ProductIdentity),
                        ProductName = data.ProductName,
                        UnitPrice = data.UnitPrice
                    });
                }

                return listProduct;
            }
            catch
            {
                throw;
            }
        }
    }
}