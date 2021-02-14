using Grpc.Core;
using MediatR;
using Product.Grpc.Command.Applications.DomainCommands.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Grpc.Command.Services
{
    public class UpdateProductService : UpdateProductGrpc.UpdateProductGrpcBase
    {
        private readonly IMediator mediator = null;

        public UpdateProductService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async override Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request, ServerCallContext context)
        {
            try
            {
                UpdateProductResponse updateProductResponse = new()
                {
                    Result = await mediator.Send<bool>(new UpdateProductCommand()
                    {
                        ProductIdentity = Guid.Parse(request.ProductIdentity),
                        ProductName = request.ProductName,
                        UnitPrice = request.UnitPrice
                    })
                };

                return updateProductResponse;
            }
            catch
            {
                throw;
            }
        }
    }
}