using FluentResults;
using Prescriptions.Contracts.Users;
using MediatR;

namespace Prescriptions.Application.Users.Queries;
public record GetUserByLoginQuery
(
  string Login
)
  : IRequest<Result<GetUserResponse>>;
