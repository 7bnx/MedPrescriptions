namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class MedicineForm
  {
    private static Errors? _invalidValue;

    public static Errors InvalidValue
      => _invalidValue ??= new
      (
        $"{nameof(MedicineForm)}.{nameof(InvalidValue)}",
        "The specified value of medicine form is not valid"
      );
  }
}
