using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<ServiceResponse<Category>>
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
