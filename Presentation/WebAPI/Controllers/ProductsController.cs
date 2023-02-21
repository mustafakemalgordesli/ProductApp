using Application.Dto;
using Application.Features.ProductFeatures.Commands.CreateProduct;
using Application.Features.ProductFeatures.Commands.DeleteProduct;
using Application.Features.ProductFeatures.Commands.UpdateProduct;
using Application.Features.ProductFeatures.Queries.GetAllProducts;
using Application.Features.ProductFeatures.Queries.GetById;
using Application.Interfaces.Repository;
using AutoMapper;
using Azure.Core;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator mediator, IProductRepository productRepository)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductQuery();
            var alllist = await mediator.Send(query);
            return Ok(alllist);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]CreateProductCommand command)
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateProductCommand command)
        {
            if(command?.Id == null)
            {
                return BadRequest(new { Success = false, Message = "Id cannot be null"});
            }
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest(new { Success = false, Message = "Id cannot be null or zero" });
            }

            var command = new DeleteProductCommand(id);
            var response = await mediator.Send(command);
            return Ok(new { Success = response });
        }
    }
}
