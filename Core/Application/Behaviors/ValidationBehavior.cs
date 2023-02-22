using Application.Dto;
using Application.Exceptions;
using Application.Features.ProductFeatures.Commands.CreateProduct;
using Application.Wrappers;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, ServiceResponse<TResponse>> where TRequest : IRequest<ServiceResponse<TResponse>>
{
    private readonly IValidator<TRequest>? _validator;
    private readonly string errorMessage = "Validation exception";
    public ValidationBehavior(IValidator<TRequest>? validator)
    {
        _validator = validator;
    }
    public ValidationBehavior(IValidator<TRequest>? validator, string errorMessage) : this(validator)
    {
        this.errorMessage = errorMessage;
    }

    public async Task<ServiceResponse<TResponse>> Handle(TRequest request, RequestHandlerDelegate<ServiceResponse<TResponse>> next, CancellationToken cancellationToken)
    {
        if(_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidateException(errorMessage);
        }

        return await next();
    }
}
