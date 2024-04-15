namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class MealReference
  {
    private static Errors? _invalidValue;

    public static Errors InvalidValue
      => _invalidValue ??= new
      (
        $"{nameof(MealReference)}.{nameof(InvalidValue)}",
        "The specified value of meal reference is not valid"
      );
  }
}
