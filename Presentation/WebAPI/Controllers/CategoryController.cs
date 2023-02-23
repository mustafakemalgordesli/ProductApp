using Application.Features.CategoryFeatures.Commands.CreateCategory;
using Application.Features.CategoryFeatures.Queries.GetAllCategories;
using Application.Features.CategoryFeatures.Queries.GetById;
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

    }
}
