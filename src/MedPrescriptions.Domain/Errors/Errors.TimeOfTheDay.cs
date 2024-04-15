namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class TimeOfTheDay
  {
    private static Errors? _invalidValue;

    public static Errors InvalidValue
      => _invalidValue ??= new
      (
        $"{nameof(TimeOfTheDay)}.{nameof(InvalidValue)}",
        "The specified value of Time of the day is not valid"
      );
  }
}
