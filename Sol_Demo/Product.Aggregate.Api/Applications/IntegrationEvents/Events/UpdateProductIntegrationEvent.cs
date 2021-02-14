using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Aggregate.Api.Applications.IntegrationEvents.Events
{
    public class UpdateProductIntegrationEvent : IRequest<Boolean>
    {
        public Guid ProductIdentity { get; set; }

        public String ProductName { get; set; }

        public double UnitPrice { get; set; }
    }
}