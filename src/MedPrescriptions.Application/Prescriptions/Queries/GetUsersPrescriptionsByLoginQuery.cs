using FluentResults;
using Prescriptions.Contracts.Prescriptions;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Queries;

public record GetUsersPrescriptionsByLoginQuery
(
  string Login
)
  : IRequest<Result<IReadOnlyList<GetPrescriptionResponse>>>;
