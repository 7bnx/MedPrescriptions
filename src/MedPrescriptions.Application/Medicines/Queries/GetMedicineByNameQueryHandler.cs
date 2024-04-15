using FluentResults;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Medicines;
using Prescriptions.Domain.Common.Errors;
using MediatR;

namespace Prescriptions.Application.Medicines.Queries;

public class GetMedicineByNameQueryHandler
(
  IMedicineRepository medicineRepository
)
  : IRequestHandler<GetMedicineByNameQuery, Result<GetMedicineResponse>>
{
  public async Task<Result<GetMedicineResponse>> Handle
  (
    GetMedicineByNameQuery request, 
    CancellationToken cancellationToken
  )
  {
    var existedMedicineResponse = await medicineRepository.GetMedicineResponseAsync(
      request.Name, cancellationToken);

    if (existedMedicineResponse is null)
      return Result.Fail(Errors.Medicine.MedicineNotExists);

    return Result.Ok(existedMedicineResponse);
  }
}
