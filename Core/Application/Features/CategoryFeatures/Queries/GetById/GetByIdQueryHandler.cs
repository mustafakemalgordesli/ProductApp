using Application.Interfaces.Repository;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Queries.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ServiceResponse<Category>>
{
    ICategoryRepository categoryRepository;
    public GetByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }
    public async Task<ServiceResponse<Category>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return new ServiceResponse<Category>(await categoryRepository.GetByIdAsync(request.Id));
    }
}
