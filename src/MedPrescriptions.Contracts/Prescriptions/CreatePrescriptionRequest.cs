namespace Prescriptions.Contracts.Prescriptions;

public sealed record CreatePrescriptionRequest
(
  Guid UserId,
  Guid MedicineId,
  int DosageUnit,
  double DosageQuantity,
  int Form,
  int MealReference,
  int Frequency,
  DateOnly StartDate,
  int Duration,
  double Amount,
  IReadOnlyList<int> TimesOfTheDay
);
