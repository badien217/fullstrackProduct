using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSolution.Application.Features.Categories.Add;
using ProductSolution.Application.Features.Categories.Delete;
using ProductSolution.Application.Features.Categories.GetAll;
using ProductSolution.Application.Features.Categories.GetBy;
using ProductSolution.Application.Features.Categories.Update;

namespace ProductSolution.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly IMediator mediator;
       
        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
   
        }
        [HttpGet]

        public async Task<IActionResult> GetAllCateGory()
        {
            var response = await mediator.Send(new GetAllCategoryRequest());

            return Ok(response);

        }
        [HttpPost]

        public async Task<IActionResult> GeCategoryById(GetByIdCategoryRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }


        [HttpPost]    
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategory(int id , UpdateCategoryRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest("Id mismatch in request body and URL parameter.");
            }

            await mediator.Send(request);

            return Ok();

        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }

    }
}
