using FluentValidation;
using Prescriptions.Application.Core.Errors;
using Prescriptions.Application.Core.Extensions;

namespace Prescriptions.Application.Prescriptions.Commands;

public class ChangePrescriptionPropertiesCommandValidator
  : AbstractValidator<ChangePrescriptionPropertiesCommand>
{
  public ChangePrescriptionPropertiesCommandValidator()
  {
    RuleLevelCascadeMode = CascadeMode.Stop;

    RuleFor(p => p.PrescriptionId)
      .NotNull().WithError(ValidationErrors.ChangePrescriptionCommand.NullPrescriptionId)
      .Must(id => id != default).WithError(ValidationErrors.ChangePrescriptionCommand.InvalidPrescriptionId);

    Include(new PrescriptionPropertiesDTOValidator());
  }
}
