using FluentResults;
using MapsterMapper;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Prescriptions;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Commands;

public class DeletePrescriptionsCommandHandler
(
  IPrescriptionRepository prescriptionRepository,
  IMapper mapper
)
  : IRequestHandler<DeletePrescriptionsCommand, Result<DeletedPrescriptionsResponse>>
{
  public async Task<Result<DeletedPrescriptionsResponse>> Handle
  (
    DeletePrescriptionsCommand request, 
    CancellationToken cancellationToken
  )
  {
    var existedIds = await prescriptionRepository.GetExistedAsync(request.Ids, cancellationToken);
    await prescriptionRepository.DeleteAsync(existedIds, cancellationToken);

    return Result.Ok(mapper.Map<DeletedPrescriptionsResponse>(existedIds));
  }
}