using Anrtd.Application.XXENTITY_NAMEXXs.Commands.Create;
using Anrtd.Application.XXENTITY_NAMEXXs.Commands.SoftDelete;
using Anrtd.Application.XXENTITY_NAMEXXs.Commands.Update;
using Anrtd.Application.XXENTITY_NAMEXXs.Queries.GetById;
using Anrtd.Application.XXENTITY_NAMEXXs.Queries.GetPaginated;
using Anrtd.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anrtd.Api.Controllers
{
    [ApiController]
    [Route("api/xXENTITY_NAMEXXs")]
    public class XXENTITY_NAMEXXsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public XXENTITY_NAMEXXsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<XXENTITY_NAMEXXEntity>>> GetPaginatedXXENTITY_NAMEXXs(
            [FromQuery] GetPaginatedXXENTITY_NAMEXXsQuery query)
        {
            var result = await _mediator.Send(query);

            if (result.IsBadRequest) return BadRequest(result.ValidationFailures);

            return Ok(result.Content);
        }

        [HttpGet("{xXENTITY_NAMEXXId}")]
        public async Task<ActionResult<XXENTITY_NAMEXXDetailsDto>> GetById(int xXENTITY_NAMEXXId)
        {
            var query = new GetXXENTITY_NAMEXXByIdQuery(xXENTITY_NAMEXXId);
            var result = await _mediator.Send(query);

            if (result.IsNotFound) return NotFound();

            return Ok(result.Content);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateXXENTITY_NAMEXX([FromBody] CreateXXENTITY_NAMEXXCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsBadRequest) return BadRequest(result.ValidationFailures);

            return StatusCode(201, result.Content);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateXXENTITY_NAMEXX([FromBody] UpdateXXENTITY_NAMEXXCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsBadRequest) return BadRequest(result.ValidationFailures);
            if (result.IsNotFound) return NotFound();

            return Ok();
        }

        [HttpDelete("{xXENTITY_NAMEXXId}")]
        public async Task<ActionResult> DeleteXXENTITY_NAMEXX(int xXENTITY_NAMEXXId)
        {
            var command = new SoftDeleteXXENTITY_NAMEXXCommand(xXENTITY_NAMEXXId);
            var result = await _mediator.Send(command);

            if (result.IsNotFound) return NotFound();

            return Ok();
        }
    }
}
