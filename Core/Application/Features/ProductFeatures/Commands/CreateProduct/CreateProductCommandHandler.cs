using Application.Dto;
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

namespace Application.Features.ProductFeatures.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<ProductViewDto>>
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;
    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<ProductViewDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = mapper.Map<Product>(request);
        await productRepository.AddAsync(product);
        ProductViewDto viewModel = mapper.Map<ProductViewDto>(product);
        return new ServiceResponse<ProductViewDto>(viewModel);
    }
}
