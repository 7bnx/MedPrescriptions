using FluentResults;
using Prescriptions.Contracts.Medicines;
using MediatR;

namespace Prescriptions.Application.Medicines.Queries;

public record GetMedicineByIdQuery
(
  Guid Id
)
  : IRequest<Result<GetMedicineResponse>>;
