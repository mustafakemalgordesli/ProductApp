using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.ParentCategoryId).GreaterThan(0);
        }
    }
}
