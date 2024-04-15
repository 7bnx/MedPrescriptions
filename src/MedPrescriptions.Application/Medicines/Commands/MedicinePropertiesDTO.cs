namespace Prescriptions.Application.Medicines.Commands;

public record MedicinePropertiesDTO
(
  string Name,
  string? Description,
  string? Ingredients,
  IReadOnlyList<MedicinePropertiesDosageAndFormDTO> DosagesAndForms
);

public sealed record MedicinePropertiesDosageAndFormDTO
(
  int Form,
  int Unit,
  double Quantity
);