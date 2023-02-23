using Application.Behaviors;
using Application.Features.ProductFeatures.Commands.CreateProduct;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.CreateCategory;

public class ValidateCreateCategoryCommandBehavior : ValidationBehavior<CreateCategoryCommand, Category>
{
	public ValidateCreateCategoryCommandBehavior(IValidator<CreateCategoryCommand> validator) : base(validator, "Category is not valid")
	{

	}
}
