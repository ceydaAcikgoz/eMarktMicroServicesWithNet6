using eMarkt.Order.Application.Feature.CQRS.Queries.OrderDetailQueries;
using eMarkt.Order.Application.Feature.Mediator.Commands.OrderingCommands;
using eMarkt.Order.Application.Feature.Mediator.Handlers.OrderingHandlers;
using eMarkt.Order.Application.Feature.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMarkt.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var values = await _mediator.Send(new GetOrderDetailByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CrateOrderingCommand createOrderingCommand)
        {
            await _mediator.Send(createOrderingCommand);
            return Ok("Sipariş eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
        {
            await _mediator.Send(updateOrderingCommand);
            return Ok("Sipariş güncellendi");
        }
    }
}
