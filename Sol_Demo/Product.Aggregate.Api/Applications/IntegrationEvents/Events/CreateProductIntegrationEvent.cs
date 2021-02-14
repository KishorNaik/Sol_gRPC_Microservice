using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Aggregate.Api.Applications.IntegrationEvents.Events
{
    public class CreateProductIntegrationEvent : IRequest<bool>
    {
        public String ProductName { get; set; }

        public double UnitPrice { get; set; }
    }
}