using Application.Behaviors;
using Application.Dto;
using Application.Features.ProductFeatures.Commands.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.UpdateProduct;

public class ValidateUpdateProductCommandBehavior : ValidationBehavior<UpdateProductCommand, ProductViewDto>
{
	public ValidateUpdateProductCommandBehavior(IValidator<UpdateProductCommand> validator) : base(validator, "Product is not valid")
    {

	}
}
