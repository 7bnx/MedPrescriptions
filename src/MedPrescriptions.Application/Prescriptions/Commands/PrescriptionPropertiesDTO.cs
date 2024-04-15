namespace Prescriptions.Application.Prescriptions.Commands;

public record PrescriptionPropertiesDTO
(
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
