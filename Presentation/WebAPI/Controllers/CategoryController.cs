using Application.Features.CategoryFeatures.Commands.CreateCategory;
using Application.Features.CategoryFeatures.Queries.GetAllCategories;
using Application.Features.CategoryFeatures.Queries.GetById;
using Application.Features.CategoryFeatures.Commands.DeleteCategory;
using Application.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoryController(IMediator mediator, IProductRepository productRepository)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCategoryQuery();
            var alllist = await mediator.Send(query);
            return Ok(alllist);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateCategoryCommand command)
        {
            var viewModel = await mediator.Send(command);
            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdQuery(id);
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest(new { Success = false, Message = "Id cannot be null or zero" });
            }

            var command = new DeleteCategoryCommand(id);
            var response = await mediator.Send(command);
            return Ok(new { Success = response });
        }

    }
}
