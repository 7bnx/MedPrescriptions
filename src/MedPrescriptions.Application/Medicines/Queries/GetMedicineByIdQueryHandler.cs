using FluentResults;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Medicines;
using Prescriptions.Domain.Common.Errors;
using MediatR;

namespace Prescriptions.Application.Medicines.Queries;

public class GetMedicineByIdQueryHandler
(
  IMedicineRepository medicineRepository
)
  : IRequestHandler<GetMedicineByIdQuery, Result<GetMedicineResponse>>
{
  public async Task<Result<GetMedicineResponse>> Handle
  (
    GetMedicineByIdQuery request, 
    CancellationToken cancellationToken
  )
  {
    var existedMedicineResponse = await medicineRepository.GetMedicineResponseAsync(request.Id, cancellationToken);
    if (existedMedicineResponse is null)
      return Result.Fail(Errors.Medicine.MedicineNotExists);

    return Result.Ok(existedMedicineResponse);
  }
}
