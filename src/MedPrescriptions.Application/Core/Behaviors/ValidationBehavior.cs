using FluentValidation;
using FluentValidation.Results;
using Prescriptions.Application.Core.Abstractions;
using MediatR;

namespace EventReminder.Application.Core.Behaviors;

internal sealed class ValidationBehavior<TRequest, TResponse>
(
  IEnumerable<IValidator<TRequest>> validators
)
  : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    where TResponse : class
{
  private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

  public async Task<TResponse> Handle
  (
    TRequest request, 
    RequestHandlerDelegate<TResponse> next, 
    CancellationToken cancellationToken
  )
  {
    if (request is not IValidatable)
      return await next();

    var context = new ValidationContext<TRequest>(request);

    List<ValidationFailure> failures = _validators
        .Select(v => v.Validate(context))
        .SelectMany(result => result.Errors)
        .Where(f => f != null)
        .ToList();

    if (failures.Count != 0)
    {
      throw new ValidationException(failures);
    }

    return await next();
  }
}
