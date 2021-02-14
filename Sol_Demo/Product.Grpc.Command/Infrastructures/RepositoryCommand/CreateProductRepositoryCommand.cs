using MediatR;
using Product.Shared.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Grpc.Command.Infrastructures.RepositoryCommand
{
    public class CreateProductRepositoryCommand : ProductModel, IRequest<bool>
    {
    }
}