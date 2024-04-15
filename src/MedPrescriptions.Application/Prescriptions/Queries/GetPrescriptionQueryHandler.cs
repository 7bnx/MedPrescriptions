using FluentResults;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Prescriptions;
using Prescriptions.Domain.Common.Errors;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Queries;

public class GetPrescriptionQueryHandler
(
  IPrescriptionRepository prescriptionRepository
)
  : IRequestHandler<GetPrescriptionQuery, Result<GetPrescriptionResponse>>
{
  public async Task<Result<GetPrescriptionResponse>> Handle
  (
    GetPrescriptionQuery request, 
    CancellationToken cancellationToken
  )
  {
    var existedPrescription = await prescriptionRepository.GetPrescriptionResponseAsync(
      request.PrescriptionId, cancellationToken);

    if (existedPrescription is null)
      return Result.Fail(Errors.Prescription.PrescriptionNotExists);

    return Result.Ok(existedPrescription);
  }
}
