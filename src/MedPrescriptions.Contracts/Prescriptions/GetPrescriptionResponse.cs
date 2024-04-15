namespace Prescriptions.Contracts.Prescriptions;

public sealed record GetPrescriptionResponse
(
  Guid Id,
  Guid UserId,
  Guid MedicineId,
  string MedicineName,
  int Form,
  int Unit,
  double Quantity,
  double Amount,
  int MealReference,
  int Frequency,
  DateOnly StartDate,
  DateOnly EndDate,
  int DurationInDays,
  IReadOnlyList<int> TimesOfTheDay
);
