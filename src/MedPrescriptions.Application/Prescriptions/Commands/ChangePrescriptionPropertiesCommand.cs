using FluentResults;
using Prescriptions.Application.Core.Abstractions;
using Prescriptions.Contracts.Prescriptions;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Commands;

public record ChangePrescriptionPropertiesCommand
  : PrescriptionPropertiesDTO, IRequest<Result<ChangedPrescriptionPropertiesResponse>>, ISavable, IValidatable
{
  public Guid PrescriptionId { get; init; }
  public ChangePrescriptionPropertiesCommand(
    Guid prescriptionId,
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
    PrescriptionId = prescriptionId;
  }
}
