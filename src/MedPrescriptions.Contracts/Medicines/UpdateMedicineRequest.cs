namespace Prescriptions.Contracts.Medicines;

public sealed record UpdateMedicineRequest
(
  Guid MedicineId,
  string Name,
  string? Description,
  string? Ingredients,
  IReadOnlyList<UpdateMedicineRequestDosageAndForms> DosagesAndForms
);

public sealed record UpdateMedicineRequestDosageAndForms
(
  int Unit,
  double Quantity,
  int Form
);