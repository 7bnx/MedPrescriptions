using FluentResults;
using Prescriptions.Application.Core.Abstractions;
using Prescriptions.Contracts.Prescriptions;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Commands;
public record CreatePrescriptionCommand
  : PrescriptionPropertiesDTO, IRequest<Result<CreatedPrescriptionResponse>>, ISavable, IValidatable
{

  public Guid UserId { get; init; }
  public Guid MedicineId { get; init; }

  public CreatePrescriptionCommand
  (
    Guid userId,
    Guid medicineId,
    int dosageUnit,
    double dosageQuantity,
    int form,
    int mealReference,
    int frequency,
    DateOnly startDate,
    int duration,
    double amount,
    IReadOnlyList<int> timesOfTheDay
  )
    : base
    (
      dosageUnit,
      dosageQuantity,
      form,
      mealReference,
      frequency,
      startDate,
      duration,
      amount,
      timesOfTheDay
    )
  {
    UserId = userId;
    MedicineId = medicineId;
  }
}
