using FluentValidation;
using Prescriptions.Application.Core.Errors;
using Prescriptions.Application.Core.Extensions;

namespace Prescriptions.Application.Prescriptions.Commands;

public class CreatePrescriptionCommandValidator
  : AbstractValidator<CreatePrescriptionCommand>
{
  public CreatePrescriptionCommandValidator()
  {
    RuleLevelCascadeMode = CascadeMode.Stop;

    RuleFor(p => p.UserId)
      .NotNull().WithError(ValidationErrors.CreatePrescriptionCommand.NullUserId)
      .Must(id => id != default).WithError(ValidationErrors.CreatePrescriptionCommand.InvalidUserId);

    RuleFor(p => p.MedicineId)
      .NotNull().WithError(ValidationErrors.CreatePrescriptionCommand.NullMedicineId)
      .Must(id => id != default).WithError(ValidationErrors.CreatePrescriptionCommand.InvalidMedicineId);

    Include(new PrescriptionPropertiesDTOValidator());
  }
}
