using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
	public CreateCategoryCommandValidator()
	{
		RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
		RuleFor(x => x.ParentCategoryId).GreaterThan(0);
	}
}

