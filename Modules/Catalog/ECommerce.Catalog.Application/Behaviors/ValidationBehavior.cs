using Azure.Core;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Behaviors
{
    public class ValidationBehavior<IRequest, IResponse> : IPipelineBehavior<IRequest, IResponse> where IRequest : notnull
    {
        private readonly IEnumerable<IValidator<IRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<IRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<IResponse> Handle(IRequest request, RequestHandlerDelegate<IResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<IRequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken))
                );

                var failures = validationResults.SelectMany(r => r.Errors)
                                                .Where(f => f != null)
                                                .ToList();

                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }
            // I want to do response style
            return await next();
        }
    }
}
