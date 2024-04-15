using FluentResults;
using Prescriptions.Application.Core.Abstractions;
using Prescriptions.Contracts.Users;
using MediatR;

namespace Prescriptions.Application.Users.Commands;

public record CreateUserCommand
(
  string Login
)
  : IRequest<Result<CreatedUserResponse>>, ISavable, IValidatable;
