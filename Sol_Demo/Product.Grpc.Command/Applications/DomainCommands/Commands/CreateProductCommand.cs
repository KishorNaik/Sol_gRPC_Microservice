using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Grpc.Command.Applications.DomainCommands.Commands
{
    public class CreateProductCommand : IRequest<bool>
    {
        public String ProductName { get; set; }

        public double UnitPrice { get; set; }
    }
}