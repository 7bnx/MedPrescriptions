using FluentResults;
using Prescriptions.Application.Core.Abstractions;
using Prescriptions.Contracts.Prescriptions;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Commands;

public record DeletePrescriptionsCommand
(
  IReadOnlyList<Guid> Ids
)
  : IRequest<Result<DeletedPrescriptionsResponse>>, ISavable, IValidatable;
