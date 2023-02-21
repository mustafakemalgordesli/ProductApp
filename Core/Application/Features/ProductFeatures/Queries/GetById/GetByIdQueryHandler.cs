using Application.Dto;
using Application.Interfaces.Repository;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ServiceResponse<ProductViewDto>>
    {
        IProductRepository productRepository;
        IMapper _mapper;
        public GetByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ProductViewDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.id);
            var dto = _mapper.Map<ProductViewDto>(product);
            return new ServiceResponse<ProductViewDto>(dto);
        }
    }
}
