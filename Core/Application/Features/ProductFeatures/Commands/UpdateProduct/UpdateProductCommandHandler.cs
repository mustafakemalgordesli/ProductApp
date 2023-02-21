using Application.Dto;
using Application.Exceptions;
using Application.Interfaces.Repository;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<ProductViewDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<ProductViewDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await productRepository.GetByIdAsync(request.Id);
            if(product == null)
            {
                throw new NotFoundException("Product not found!");
            }

            product.UpdatedAt= DateTime.Now;
            product.CategoryId = request?.CategoryId ?? product.CategoryId;
            product.Value = request?.Value ?? product.Value;
            product.Quantity = request?.Quantity ?? product.Quantity;
            product.Name = request?.Name ?? product.Name;

            productRepository.Update(product);

            ProductViewDto dto = mapper.Map<ProductViewDto>(product);

            return new ServiceResponse<ProductViewDto>(dto);
        }
    }
}
