using Application.Behaviors;
using Application.Features.CategoryFeatures.Commands.UpdateCategory;
using Application.Wrappers;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.UpdateCategory;

public class ValidateUpdateCategoryCommandBehavior : ValidationBehavior<UpdateCategoryCommand, Category>
{
    public ValidateUpdateCategoryCommandBehavior(IValidator<UpdateCategoryCommand> validator) : base(validator, "Category is not valid")
    {
    }
}
