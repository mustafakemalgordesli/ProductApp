using Application.Exceptions;
using Application.Interfaces.Repository;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ServiceResponse<Category>>
{
    ICategoryRepository categoryRepository;
    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        this.categoryRepository= categoryRepository;
    }

    public async Task<ServiceResponse<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await categoryRepository.GetByIdAsync(request.Id);
        if(category == null)
        {
            throw new NotFoundException("Category not found!");
        }

        category.UpdatedAt = DateTime.Now;
        category.Name = request?.Name ?? category.Name;
        category.ParentCategoryId = request?.ParentCategoryId ?? category.ParentCategoryId;

        categoryRepository.Update(category);

        return new ServiceResponse<Category>(category);
    }
}
