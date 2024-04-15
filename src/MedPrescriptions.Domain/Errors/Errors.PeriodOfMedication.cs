namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class PeriodOfMedication
  {
    private static Errors? _invalidDuration;

    public static Errors InvalidDuration
      => _invalidDuration ??= new
      (
        $"{nameof(PeriodOfMedication)}.{nameof(InvalidDuration)}",
        "The specified duration of medication is less or equal zero"
      );
  }
}
