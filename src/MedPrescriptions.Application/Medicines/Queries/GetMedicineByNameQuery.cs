using FluentResults;
using Prescriptions.Contracts.Medicines;
using MediatR;

namespace Prescriptions.Application.Medicines.Queries;

public record GetMedicineByNameQuery
(
  string Name
)
  : IRequest<Result<GetMedicineResponse>>;
