using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<ServiceResponse<Category>>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? ParentCategoryId { get; set; }
}

