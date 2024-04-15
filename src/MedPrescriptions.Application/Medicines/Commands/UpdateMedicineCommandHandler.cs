using FluentResults;
using MapsterMapper;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Medicines;
using Prescriptions.Domain.Common.Errors;
using Prescriptions.Domain.Enumerations;
using Prescriptions.Domain.ValueObjects;
using MediatR;

namespace Prescriptions.Application.Medicines.Commands;

public class UpdateMedicineCommandHandler
(
  IMedicineRepository medicineRepository,
  IMapper mapper
)
  : IRequestHandler<UpdateMedicineCommand, Result<UpdatedMedicineResponse>>
{
  public async Task<Result<UpdatedMedicineResponse>> Handle
  (
    UpdateMedicineCommand request,
    CancellationToken cancellationToken
  )
  {
    var existedMedicine = await medicineRepository.GetMedicineAsync(request.MedicineId, cancellationToken);
    if (existedMedicine is null)
      return Result.Fail(Errors.Medicine.MedicineNotExists);

    if (!request.Name.Equals(existedMedicine.Name, StringComparison.OrdinalIgnoreCase)
      && await medicineRepository.IsExistsAsync(request.Name, cancellationToken))
      return Result.Fail(Errors.Medicine.MedicineAlreadyExists);

    var dosagesAndForms = new List<MedicineDosageAndForm>();
    foreach (var dafRequest in request.DosagesAndForms)
    {
      var dosageResult = ActiveIngredientDosage.Create(dafRequest.Unit, dafRequest.Quantity);
      var formResult = MedicineForm.FromValue(dafRequest.Form);
      if (dosageResult.IsFailed || formResult.IsFailed)
        return Result.Merge(dosageResult, formResult);

      dosagesAndForms.Add(new(formResult.Value, dosageResult.Value));
    }

    var updateResult = existedMedicine.UpdateProperties
    (
      request.Name,
      request.Description,
      request.Ingredients,
      dosagesAndForms
    );

    if (updateResult.IsFailed)
      return Result.Fail(updateResult.Errors);

    return Result.Ok(mapper.Map<UpdatedMedicineResponse>(existedMedicine));
  }
}
