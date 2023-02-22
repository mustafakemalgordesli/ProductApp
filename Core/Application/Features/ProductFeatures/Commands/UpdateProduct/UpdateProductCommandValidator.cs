using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
	public UpdateProductCommandValidator()
	{
        RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(x => x.Name).MinimumLength(3).MaximumLength(100).WithMessage("Name must be between 3 and 100 lengths");
        RuleFor(x => x.Value).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CategoryId).GreaterThan(0);
    }
}
