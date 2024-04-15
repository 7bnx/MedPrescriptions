using FluentResults;
using MapsterMapper;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Users;
using Prescriptions.Domain.Common.Errors;
using MediatR;

namespace Prescriptions.Application.Users.Queries;

public class GetUserByLoginQueryHandler
(
  IUserRepository userRepository,
  IMapper mapper
)
  : IRequestHandler<GetUserByLoginQuery, Result<GetUserResponse>>
{
  public async Task<Result<GetUserResponse>> Handle
  (
    GetUserByLoginQuery request, 
    CancellationToken cancellationToken
  )
  {
    var existedUser = await userRepository.GetUserAsync(request.Login, cancellationToken);
    if (existedUser is null)
      return Result.Fail(Errors.User.UserNotExists);

    return Result.Ok(mapper.Map<GetUserResponse>(existedUser));
  }
}