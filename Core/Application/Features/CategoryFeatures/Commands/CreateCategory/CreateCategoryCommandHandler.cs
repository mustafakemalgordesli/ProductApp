using Application.Interfaces.Repository;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ServiceResponse<Category>>
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }
        public async Task<ServiceResponse<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            await categoryRepository.AddAsync(category);
            return new ServiceResponse<Category>(category);
        }
    }
}
