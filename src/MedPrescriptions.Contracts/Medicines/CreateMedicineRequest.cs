namespace Prescriptions.Contracts.Medicines;

public sealed record CreateMedicineRequest
(
  string Name,
  string? Description,
  string? Ingredients,
  IReadOnlyList<CreateMedicineRequestDosageAndForms> DosagesAndForms
);

public sealed record CreateMedicineRequestDosageAndForms
(
  int Unit,
  double Quantity,
  int Form
);
