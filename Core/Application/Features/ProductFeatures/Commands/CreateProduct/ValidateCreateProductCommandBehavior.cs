using Application.Behaviors;
using Application.Dto;
using Application.Exceptions;
using Application.Wrappers;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.CreateProduct;
public class ValidateCreateProductCommandBehavior : ValidationBehavior<CreateProductCommand, ProductViewDto>
{
	public ValidateCreateProductCommandBehavior(IValidator<CreateProductCommand> validator) : base(validator, "Product is not valid")
	{

	}
}
