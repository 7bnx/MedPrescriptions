using FluentResults;
using Prescriptions.Application.Core.Abstractions;
using Prescriptions.Contracts.Medicines;
using MediatR;


namespace Prescriptions.Application.Medicines.Commands;

public sealed record CreateMedicineCommand
  : MedicinePropertiesDTO, IRequest<Result<CreatedMedicineResponse>>, ISavable, IValidatable
{
  public CreateMedicineCommand
  (
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
  { }
}
