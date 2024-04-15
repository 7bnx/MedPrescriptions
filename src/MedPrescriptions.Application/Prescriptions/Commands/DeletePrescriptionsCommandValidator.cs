using FluentValidation;
using Prescriptions.Application.Core.Errors;
using Prescriptions.Application.Core.Extensions;

namespace Prescriptions.Application.Prescriptions.Commands;

public class DeletePrescriptionsCommandValidator
  : AbstractValidator<DeletePrescriptionsCommand>
{
  public DeletePrescriptionsCommandValidator()
  {
    RuleLevelCascadeMode = CascadeMode.Stop;

    RuleFor(p => p.Ids)
      .NotNull().WithError(ValidationErrors.DeletePrescriptionsCommand.NullIds);
  }
}
