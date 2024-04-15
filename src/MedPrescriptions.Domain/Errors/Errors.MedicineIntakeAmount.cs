namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class MedicineIntakeAmount
  {
    private static Errors? _invalidAmount;

    public static Errors InvalidAmount
      => _invalidAmount ??= new
      (
        $"{nameof(MedicineIntakeAmount)}.{nameof(InvalidAmount)}",
        "Invalid intake amount of medicine"
      );
  }
}
