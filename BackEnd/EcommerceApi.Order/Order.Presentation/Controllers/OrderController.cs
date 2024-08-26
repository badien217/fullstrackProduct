using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Features.Order.Add;
using Order.Application.Features.Order.Delete;
using Order.Application.Features.Order.GetAll;
using Order.Application.Features.Order.GetOne.GetOrderById;
using Order.Application.Features.Order.Update;

namespace Order.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;

        }
        [HttpGet]

        public async Task<IActionResult> GetAllOrder()
        {
            var response = await mediator.Send(new GetAllOrderRequest());

            return Ok(response);

        }
        [HttpPost]

        public async Task<IActionResult> GetOrderById(GetOneOrderByIdRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrder(int id, UpdateOrderRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest("Id mismatch in request body and URL parameter.");
            }

            await mediator.Send(request);

            return Ok();

        }
        [HttpPost]
        public async Task<IActionResult> DeleteOrder(DeleteOrderRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
    }
}
