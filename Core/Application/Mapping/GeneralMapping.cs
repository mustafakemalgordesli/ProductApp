using Application.Dto;
using Application.Features.CategoryFeatures.Commands.CreateCategory;
using Application.Features.ProductFeatures.Commands.CreateProduct;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {  

            CreateMap<Product, ProductViewDto>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<CreateCategoryCommand, Category>();
        }
    }
}
