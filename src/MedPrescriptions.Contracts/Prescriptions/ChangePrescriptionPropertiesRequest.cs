namespace Prescriptions.Contracts.Prescriptions;

public sealed record ChangePrescriptionPropertiesRequest
(
  Guid PrescriptionId,
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