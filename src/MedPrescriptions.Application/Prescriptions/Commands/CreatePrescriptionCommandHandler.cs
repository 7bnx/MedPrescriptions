using FluentResults;
using MapsterMapper;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Prescriptions;
using Prescriptions.Domain.Common.Errors;
using Prescriptions.Domain.Entities;
using Prescriptions.Domain.ValueObjects;
using MediatR;

namespace Prescriptions.Application.Prescriptions.Commands;

public class CreatePrescriptionCommandHandler
(
  IUserRepository userRepository,
  IMedicineRepository medicineRepository,
  IPrescriptionRepository prescriptionRepository,
  IMapper mapper
)
  : IRequestHandler<CreatePrescriptionCommand, Result<CreatedPrescriptionResponse>>
{
  public async Task<Result<CreatedPrescriptionResponse>> Handle
  (
    CreatePrescriptionCommand request, 
    CancellationToken cancellationToken
  )
  {
    var existedUser = await userRepository.GetUserAsync(request.UserId, cancellationToken);

    if (existedUser is null)
      return Result.Fail(Errors.User.UserNotExists);

    var existedMedicine = await medicineRepository.GetMedicineAsync(request.MedicineId, cancellationToken);
    if (existedMedicine is null)
      return Result.Fail(Errors.Medicine.MedicineNotExists);

    var propertiesResult = PrescriptionProperties.Create(
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

    if (propertiesResult.IsFailed)
      return Result.Fail(propertiesResult.Errors);

    var prescriptionToAdd = new Prescription
    (
      user: existedUser,
      medicine: existedMedicine,
      properties: propertiesResult.Value
    );

    await prescriptionRepository.AddAsync(prescriptionToAdd, cancellationToken);

    return Result.Ok(mapper.Map<CreatedPrescriptionResponse>(prescriptionToAdd.Id));
  }
}