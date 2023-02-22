using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
		RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name cannot be empty").MinimumLength(3).MaximumLength(100).WithMessage("Name must be between 3 and 100 lengths");
		RuleFor(x => x.Value).NotEmpty().NotNull().GreaterThan(0);
		RuleFor(x => x.Quantity).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
		RuleFor(x => x.CategoryId).NotEmpty().NotNull().GreaterThan(0);
    }
}
