using Application.Dto;
using Application.Interfaces.Repository;
using Application.Mapping;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries.GetById
{
    public class GetByIdQuery : IRequest<ServiceResponse<ProductViewDto>>
    {
        public GetByIdQuery(int id)
        {
            this.id = id;
        }
        public int id { get; set; }
    }
}
