using FluentValidation;
using Prescriptions.Application.Core.Errors;
using Prescriptions.Application.Core.Extensions;

namespace Prescriptions.Application.Medicines.Commands;

public class UpdateMedicineCommandValidator
  : AbstractValidator<UpdateMedicineCommand>
{
  public UpdateMedicineCommandValidator()
  {
    RuleLevelCascadeMode = CascadeMode.Stop;

    RuleFor(m => m.MedicineId)
      .NotNull().WithError(ValidationErrors.UpdateMedicineCommand.NullMedicineId)
      .Must(id => id != default).WithError(ValidationErrors.UpdateMedicineCommand.InvalidPrescriptionId);

    Include(new MedicinePropertiesDTOValidation());
  }
}
