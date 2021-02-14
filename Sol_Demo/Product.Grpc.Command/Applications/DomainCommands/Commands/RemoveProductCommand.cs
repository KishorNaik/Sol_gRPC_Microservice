using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Grpc.Command.Applications.DomainCommands.Commands
{
    public class RemoveProductCommand : IRequest<Boolean>
    {
        public Guid ProductIdentity { get; set; }
    }
}