using Grpc.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Product.Grpc.Command.Applications.DomainCommands.Commands;

namespace Product.Grpc.Command.Services
{
    public class CreateProductService : CreateProductGrpc.CreateProductGrpcBase
    {
        private readonly IMediator mediator = null;

        public CreateProductService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public override async Task<CreateProductResponse> CreateProduct(CreateProductRequest request, ServerCallContext context)
        {
            CreateProductResponse createProductResponse = new()
            {
                Result = await mediator.Send<bool>(new CreateProductCommand()
                {
                    ProductName = request.ProductName,
                    UnitPrice = request.UnitPrice
                })
            };

            return createProductResponse;
        }
    }
}