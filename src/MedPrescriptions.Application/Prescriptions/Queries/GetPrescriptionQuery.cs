using FluentResults;
using Prescriptions.Contracts.Prescriptions;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Queries;

public record GetPrescriptionQuery
(
  Guid PrescriptionId
) 
  : IRequest<Result<GetPrescriptionResponse>>;
