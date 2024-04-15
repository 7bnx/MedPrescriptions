using FluentValidation;
using Prescriptions.Application.Core.Errors;
using Prescriptions.Application.Core.Extensions;

namespace Prescriptions.Application.Medicines.Commands;
internal class MedicinePropertiesDTOValidation
  : AbstractValidator<MedicinePropertiesDTO>
{
  public MedicinePropertiesDTOValidation()
  {
    RuleLevelCascadeMode = CascadeMode.Stop;

    RuleFor(m => m.Name)
      .NotNull().WithError(ValidationErrors.MedicineProperties.NullMedicineName)
      .NotEmpty().WithError(ValidationErrors.MedicineProperties.EmptyMedicineName);

    RuleFor(m => m.DosagesAndForms)
      .NotNull().WithError(ValidationErrors.MedicineProperties.NullDosagesAndForms);
  }
}