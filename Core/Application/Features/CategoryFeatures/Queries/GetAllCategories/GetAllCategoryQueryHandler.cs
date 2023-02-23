using Application.Interfaces.Repository;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Queries.GetAllCategories;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, ServiceResponse<List<Category>>>
{
    ICategoryRepository categoryRepository;
    public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }
    public async Task<ServiceResponse<List<Category>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return new ServiceResponse<List<Category>>(await categoryRepository.GetAllAsync());
    }
}
