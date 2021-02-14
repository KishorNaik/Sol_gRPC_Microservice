using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Product.Grpc.Query.Applications.DomainQueries.Queries;
using Product.Shared.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Grpc.Query.Services
{
    public class GetAllProductServics : GetAllProductGrpc.GetAllProductGrpcBase
    {
        private readonly IMediator mediator = null;

        public GetAllProductServics(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public override async Task GetAllProduct(Empty request, IServerStreamWriter<GetAllProductResponse> responseStream, ServerCallContext context)
        {
            var getAllProductTask = mediator.Send<IReadOnlyList<ProductModel>>(new GetAllProductQuery());

            foreach (var data in await getAllProductTask)
            {
                await responseStream.WriteAsync(new GetAllProductResponse()
                {
                    ProductIdentity = data.ProductIdentity.ToString(),
                    ProductName = data.ProductName,
                    UnitPrice = data.UnitPrice
                });
            }
        }
    }
}