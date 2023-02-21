using Application.Dto;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<ProductViewDto>>
    {
        public string Name { get; set; } 
        public decimal Value { get; set; } 
        public int Quantity { get; set; } 
        public int CategoryId { get; set; }
    }
}
