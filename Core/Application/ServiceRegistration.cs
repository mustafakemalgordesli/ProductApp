using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Reflection;
using Application.Features.ProductFeatures.Commands.CreateProduct;
using Application.Wrappers;
using Application.Dto;
using FluentValidation;
using Application.Behaviors;
using Application.Features.ProductFeatures.Commands.UpdateProduct;
using Application.Features.CategoryFeatures.Commands.CreateCategory;
using Domain.Entities;
using Application.Features.CategoryFeatures.Commands.UpdateCategory;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IPipelineBehavior<CreateProductCommand, ServiceResponse<ProductViewDto>>, ValidateCreateProductCommandBehavior>();
            services.AddScoped<IPipelineBehavior<UpdateProductCommand, ServiceResponse<ProductViewDto>>, ValidateUpdateProductCommandBehavior>();
            services.AddScoped<IPipelineBehavior<CreateCategoryCommand, ServiceResponse<Category>>, ValidateCreateCategoryCommandBehavior>();
            services.AddScoped<IPipelineBehavior<UpdateCategoryCommand, ServiceResponse<Category>>, ValidateUpdateCategoryCommandBehavior>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
