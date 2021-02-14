using MediatR;
using Product.Shared.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Aggregate.Api.Applications.IntegrationEvents.Events
{
    public class GetAllProductIntegrationEvent : IRequest<List<ProductModel>>
    {
    }
}