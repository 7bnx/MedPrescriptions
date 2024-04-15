using FluentResults;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Prescriptions;
using Prescriptions.Domain.Common.Errors;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Queries;

public class GetUsersPrescriptionsByIdQueryHandler
(
  IUserRepository userRepository,
  IPrescriptionRepository prescriptionRepository
)
  : IRequestHandler<GetUsersPrescriptionsByIdQuery, Result<IReadOnlyList<GetPrescriptionResponse>>>
{
  public async Task<Result<IReadOnlyList<GetPrescriptionResponse>>> Handle
  (
    GetUsersPrescriptionsByIdQuery request, 
    CancellationToken cancellationToken
  )
  {
    var isUserExisted = await userRepository.IsExistsAsync(request.UserId, cancellationToken);
    if (!isUserExisted)
      return Result.Fail(Errors.User.UserNotExists);

    var usersPrescriptions = await prescriptionRepository.GetUsersPrescriptionsByIdAsync(
      request.UserId, cancellationToken);

    return Result.Ok(usersPrescriptions);
  }
}
