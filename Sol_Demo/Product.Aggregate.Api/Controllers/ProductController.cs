using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Aggregate.Api.Applications.IntegrationEvents.Events;
using Product.Shared.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Aggregate.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator = null;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductIntegrationEvent createProductIntegrationEvent)
            => base.Ok(await mediator.Send<bool>(createProductIntegrationEvent));

        [HttpPost("update")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductIntegrationEvent updateProductIntegrationEvent)
            => base.Ok(await mediator.Send<bool>(updateProductIntegrationEvent));

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveProductAsync([FromBody] RemoveProductIntegrationEvent removeProductIntegrationEvent)
           => base.Ok(await mediator.Send<bool>(removeProductIntegrationEvent));

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAllProductAsync()
           => base.Ok(await mediator.Send<List<ProductModel>>(new GetAllProductIntegrationEvent()));
    }
}