using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSolution.Application.Features.Categories.Add;
using ProductSolution.Application.Features.Categories.Delete;
using ProductSolution.Application.Features.Categories.GetAll;
using ProductSolution.Application.Features.Categories.GetBy;
using ProductSolution.Application.Features.Categories.Update;
using ProductSolution.Application.Features.Products.Add;
using ProductSolution.Application.Features.Products.Delete;
using ProductSolution.Application.Features.Products.GetAll;
using ProductSolution.Application.Features.Products.GetBy;
using ProductSolution.Application.Features.Products.Update;

namespace ProductSolution.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;

        }
        [HttpGet]

        public async Task<IActionResult> GetAllProduct()
        {
            var response = await mediator.Send(new GetAllProductRequest());

            return Ok(response);

        }
        [HttpPost]

        public async Task<IActionResult> GetProductById(GetByIdProductRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest("Id mismatch in request body and URL parameter.");
            }

            await mediator.Send(request);

            return Ok();

        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(DeleteProductRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
    }
}
