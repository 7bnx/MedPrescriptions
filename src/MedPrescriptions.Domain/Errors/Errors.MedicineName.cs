namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class MedicineName
  {
    private static Errors? _invalidName;

    public static Errors InvalidName
      => _invalidName ??= new
      (
        $"{nameof(MedicineName)}.{nameof(InvalidName)}",
        "The name of medicine could not be null or empty"
      );
  }
}
