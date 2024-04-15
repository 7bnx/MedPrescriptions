using FluentValidation;
using Prescriptions.Application.Core.Errors;

namespace Prescriptions.Application.Core.Extensions;

public static class FluentValidationExtensions
{
  public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
      this IRuleBuilderOptions<T, TProperty> rule, ValidationErrors error)
  {
    if (error is null)
      throw new ArgumentNullException(nameof(error), "Error is required");

    return rule.WithErrorCode(error.Code).WithMessage(error.Message);
  }
}
