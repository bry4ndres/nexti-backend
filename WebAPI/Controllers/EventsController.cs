using Application.Commands;
using Application.DTOs;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController: ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetEventByIdQuery(id);
            var evento = await _mediator.Send(query);
            if (evento == null) return NotFound();
            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEventCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateEventCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteEventCommand { Id = id };
            var result=await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        //public async Task<ActionResult<IEnumerable<EventDTO>>> GetAllEventos()
        //{
        //    var query = new GetAllEventsQuery();
        //    var events = await _mediator.Send(query);
        //    return Ok(events);
        //}
        public async Task<ActionResult<PagedResult<EventDTO>>> GetAllEventos([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
        {
            var query = new GetAllEventsQuery { PageNumber = pageNumber, PageSize = pageSize };
            var pagedResult = await _mediator.Send(query);
            return Ok(pagedResult);
        }
    }
}
