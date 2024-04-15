using FluentResults;
using Prescriptions.Contracts.Prescriptions;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Queries;

public record GetUsersPrescriptionsByIdQuery
(
  Guid UserId
)
  : IRequest<Result<IReadOnlyList<GetPrescriptionResponse>>>;
