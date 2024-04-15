namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class QuantityOfActiveIngredient
  {
    private static Errors? _invalidValue;

    public static Errors InvalidValue
      => _invalidValue ??= new
      (
        $"{nameof(QuantityOfActiveIngredient)}.{nameof(InvalidValue)}",
        "The specified value of Active ingredient is not valid"
      );
  }
}
