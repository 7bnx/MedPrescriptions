using FluentResults;
using MapsterMapper;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Medicines;
using Prescriptions.Domain.Common.Errors;
using Prescriptions.Domain.Entities;
using Prescriptions.Domain.Enumerations;
using Prescriptions.Domain.ValueObjects;
using MediatR;

namespace Prescriptions.Application.Medicines.Commands;

public sealed class CreateMedicineCommandHandler
(
  IMedicineRepository medicineRepository,
  IMapper mapper
)
  : IRequestHandler<CreateMedicineCommand, Result<CreatedMedicineResponse>>
{
  public async Task<Result<CreatedMedicineResponse>> Handle
  (
    CreateMedicineCommand request,
    CancellationToken cancellationToken
  )
  {
    var isMedicineExists = await medicineRepository.IsExistsAsync(request.Name, cancellationToken);

    if (isMedicineExists)
      return Result.Fail(Errors.Medicine.MedicineAlreadyExists);

    var dosagesAndForms = new List<MedicineDosageAndForm>();
    foreach (var daf in request.DosagesAndForms)
    {
      var dosageResult = ActiveIngredientDosage.Create(daf.Unit, daf.Quantity);
      var formResult = MedicineForm.FromValue(daf.Form);
      if (dosageResult.IsFailed || formResult.IsFailed)
        return Result.Merge(dosageResult, formResult);

      var dosageAndForm = new MedicineDosageAndForm(formResult.Value, dosageResult.Value);
      dosagesAndForms.Add(dosageAndForm);
    }

    var medicineToAddResult = Medicine.Create
    (
      name: request.Name,
      description: request.Description,
      ingredients: request.Ingredients,
      dosagesAndForms: dosagesAndForms.Distinct().ToList()
    );

    if (medicineToAddResult.IsFailed)
      return Result.Fail(medicineToAddResult.Errors);

    await medicineRepository.AddAsync(medicineToAddResult.Value, cancellationToken);

    return Result.Ok(mapper.Map<CreatedMedicineResponse>(medicineToAddResult.Value));
  }
}
