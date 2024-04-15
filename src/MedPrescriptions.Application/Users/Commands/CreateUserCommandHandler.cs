using FluentResults;
using MapsterMapper;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Users;
using Prescriptions.Domain.Common.Errors;
using Prescriptions.Domain.Entities;
using MediatR;

namespace Prescriptions.Application.Users.Commands;

public class CreateUserCommandHandler
(
  IUserRepository userRepository,
  IMapper mapper
)
  : IRequestHandler<CreateUserCommand, Result<CreatedUserResponse>>
{
  public async Task<Result<CreatedUserResponse>> Handle
  (
    CreateUserCommand request, 
    CancellationToken cancellationToken
  )
  {
    var isUserExists = await userRepository.IsExistsAsync(request.Login, cancellationToken);
    if (isUserExists)
      return Result.Fail(Errors.User.UserAlreadyExists);

    var userToAddResult = User.Create(request.Login);
    if (userToAddResult.IsFailed)
      return Result.Fail(userToAddResult.Errors);

    await userRepository.AddAsync(userToAddResult.Value, cancellationToken);

    return Result.Ok(mapper.Map<CreatedUserResponse>(userToAddResult.Value));
  }
}