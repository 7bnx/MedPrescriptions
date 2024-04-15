using FluentValidation;

namespace Prescriptions.Application.Medicines.Commands;

public class CreateMedicineCommandValidator
  : AbstractValidator<CreateMedicineCommand>
{
  public CreateMedicineCommandValidator()
  {
    RuleLevelCascadeMode = CascadeMode.Stop;

    Include(new MedicinePropertiesDTOValidation());
  }
}
