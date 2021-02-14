using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Aggregate.Api.Applications.IntegrationEvents.Events
{
    public class RemoveProductIntegrationEvent : IRequest<bool>
    {
        public Guid ProductIdentity { get; set; }
    }
}