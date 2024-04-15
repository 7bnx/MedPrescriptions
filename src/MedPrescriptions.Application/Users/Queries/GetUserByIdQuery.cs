using FluentResults;
using Prescriptions.Contracts.Users;
using MediatR;

namespace Prescriptions.Application.Users.Queries;
public record GetUserByIdQuery
(
  Guid Id
)
  : IRequest<Result<GetUserResponse>>;
