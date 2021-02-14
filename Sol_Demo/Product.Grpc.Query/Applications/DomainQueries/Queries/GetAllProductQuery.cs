using MediatR;
using Product.Shared.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Grpc.Query.Applications.DomainQueries.Queries
{
    public class GetAllProductQuery : IRequest<IReadOnlyList<ProductModel>>
    {
    }
}