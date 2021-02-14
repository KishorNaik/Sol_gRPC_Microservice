using MediatR;
using Product.Grpc.Query.Applications.DomainQueries.Queries;
using Product.Grpc.Query.Infrastructures.RepositoryQuery;
using Product.Shared.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Grpc.Query.Applications.DomainQueries.Handlers
{
    public sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IReadOnlyList<ProductModel>>
    {
        private readonly IMediator mediator = null;

        public GetAllProductQueryHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        Task<IReadOnlyList<ProductModel>> IRequestHandler<GetAllProductQuery, IReadOnlyList<ProductModel>>.Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return mediator.Send<IReadOnlyList<ProductModel>>(new GetAllProductRepositoryQuery());
            }
            catch
            {
                throw;
            }
        }
    }
}