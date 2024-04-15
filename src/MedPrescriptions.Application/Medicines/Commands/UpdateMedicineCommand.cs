using FluentResults;
using Prescriptions.Application.Core.Abstractions;
using Prescriptions.Contracts.Medicines;
using MediatR;

namespace Prescriptions.Application.Medicines.Commands;

public sealed record UpdateMedicineCommand
  : MedicinePropertiesDTO, IRequest<Result<UpdatedMedicineResponse>>, ISavable, IValidatable
{

  public Guid MedicineId { get; set; }

  public UpdateMedicineCommand
  (
    Guid medicineId,
    string name,
    string? description,
    string? ingredients,
    IReadOnlyList<MedicinePropertiesDosageAndFormDTO> dosagesAndForms
  )
    : base
    (
      name,
      description,
      ingredients,
      dosagesAndForms
    )
  {
    MedicineId = medicineId;
  }
}

public sealed record UpdateMedicineCommandDosageAndForms
(
  int Unit,
  double Quantity,
  int Form
);
