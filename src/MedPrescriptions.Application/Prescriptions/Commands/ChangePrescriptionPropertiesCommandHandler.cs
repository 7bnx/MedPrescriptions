using FluentResults;
using MapsterMapper;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Prescriptions;
using Prescriptions.Domain.Common.Errors;
using Prescriptions.Domain.ValueObjects;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Commands;

public class ChangePrescriptionPropertiesCommandHandler
(
  IPrescriptionRepository prescriptionRepository,
  IMapper mapper
)
  : IRequestHandler<ChangePrescriptionPropertiesCommand, Result<ChangedPrescriptionPropertiesResponse>>
{
  public async Task<Result<ChangedPrescriptionPropertiesResponse>> Handle
  (
    ChangePrescriptionPropertiesCommand request, 
    CancellationToken cancellationToken
  )
  {
    var existedPrescription = await prescriptionRepository.GetAsync(request.PrescriptionId, cancellationToken);
    if (existedPrescription is null)
      return Result.Fail(Errors.Prescription.PrescriptionNotExists);

    var newPropertiesResult = PrescriptionProperties.Create(
      dosageUnit: request.DosageUnit,
      dosageQuantity: request.DosageQuantity,
      form: request.Form,
      mealReference: request.MealReference,
      frequency: request.Frequency,
      startDate: request.StartDate,
      duration: request.Duration,
      amount: request.Amount,
      timesOfTheDay: request.TimesOfTheDay
    );

    if (newPropertiesResult.IsFailed)
      return Result.Fail(newPropertiesResult.Errors);

    existedPrescription.ChangeProperties(newPropertiesResult.Value);

    return Result.Ok(mapper.Map<ChangedPrescriptionPropertiesResponse>(existedPrescription));
  }
}