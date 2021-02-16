using AttributeInjection.Attributes;
using AttributeInjection.Models;
using AttributeInjection.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AttributeInjection.Controllers
{
    [ApiController]
    [Route("api/attribute/injection")]
    public class AttributeInjectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttributeInjectionController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("restricted/data")]
        public async Task<IActionResult> First()
        {
            GetRestrictedDataQuery _query = new GetRestrictedDataQuery();
            RestrictedData _result = await this._mediator.Send(_query);
            return Ok(_result);
        }
    }
}
