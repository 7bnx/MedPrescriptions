namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class FrequencyOfMedication
  {
    private static Errors? _invalidValue;

    public static Errors InvalidValue
      => _invalidValue ??= new
      (
        $"{nameof(FrequencyOfMedication)}.{nameof(InvalidValue)}",
        "The specified value of frequency of the medication is not valid"
      );
  }
}
