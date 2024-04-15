using FluentResults;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Prescriptions;
using Prescriptions.Domain.Common.Errors;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Queries;

public class GetUsersPrescriptionsByLoginQueryHandler
(
  IUserRepository userRepository,
  IPrescriptionRepository prescriptionRepository
)
  : IRequestHandler<GetUsersPrescriptionsByLoginQuery, Result<IReadOnlyList<GetPrescriptionResponse>>>
{
  public async Task<Result<IReadOnlyList<GetPrescriptionResponse>>> Handle
  (
    GetUsersPrescriptionsByLoginQuery request, 
    CancellationToken cancellationToken
  )
  {
    var isUserExists = await userRepository.IsExistsAsync(request.Login, cancellationToken);

    if (!isUserExists)
      return Result.Fail(Errors.User.UserNotExists);

    var existedPrescriptions = await prescriptionRepository.GetUsersPrescriptionsByLoginAsync(
      request.Login, cancellationToken);

    return Result.Ok(existedPrescriptions);
  }
}
