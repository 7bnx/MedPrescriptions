namespace Prescriptions.Contracts.Medicines;

public sealed record GetMedicineResponse
(
  Guid Id,
  string Name,
  string? Description,
  string? Ingredients,
  IReadOnlyList<GetMedicineResponseDosageAndForm> DosagesAndForms
);

public sealed record GetMedicineResponseDosageAndForm
(
  int Form,
  double DosageQuantity,
  int DosageUnit
);