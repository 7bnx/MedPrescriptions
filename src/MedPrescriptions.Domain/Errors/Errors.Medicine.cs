namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class Medicine
  {
    private static Errors? _alreadyContainsDosage;

    public static Errors AlreadyContainsDosage
      => _alreadyContainsDosage ??= new
      (
        $"{nameof(Medicine)}.{nameof(AlreadyContainsDosage)}",
        "The medicine already contains the specified dosage"
      );

    private static Errors? _doesNotContainsDosage;

    public static Errors DoesNotContainsDosage
      => _doesNotContainsDosage ??= new
      (
        $"{nameof(Medicine)}.{nameof(DoesNotContainsDosage)}",
        "The medicine does not contains the specified dosage"
      );

    private static Errors? _medicineAlreadyExists;

    public static Errors MedicineAlreadyExists
      => _medicineAlreadyExists ??= new
      (
        $"{nameof(Medicine)}.{nameof(MedicineAlreadyExists)}",
        "The medicine already exists"
      );

    private static Errors? _medicineNotExists;

    public static Errors MedicineNotExists
      => _medicineNotExists ??= new
      (
        $"{nameof(Medicine)}.{nameof(MedicineNotExists)}",
        "The medicine not exists"
      );

  }
}
