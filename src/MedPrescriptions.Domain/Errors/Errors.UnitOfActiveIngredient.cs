namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class UnitOfActiveIngredient
  {
    private static Errors? _invalidUnit;

    public static Errors InvalidUnit
      => _invalidUnit ??= new
      (
        $"{nameof(UnitOfActiveIngredient)}.{nameof(InvalidUnit)}",
        "The specified unit of Active ingredient is not valid"
      );
  }
}
