namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class Prescription
  {
    private static Errors? _prescriptionNotExists;

    public static Errors PrescriptionNotExists
      => _prescriptionNotExists ??= new
      (
        $"{nameof(Prescription)}.{nameof(PrescriptionNotExists)}",
        "The specified prescription not exists"
      );
  }
}
