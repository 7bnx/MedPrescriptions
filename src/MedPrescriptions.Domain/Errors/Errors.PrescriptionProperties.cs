namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class PrescriptionProperties
  {
    private static Errors? _similarValuesTimesOfTheDay;

    public static Errors SimilarValuesTimesOfTheDay
      => _similarValuesTimesOfTheDay ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(SimilarValuesTimesOfTheDay)}",
        "Times of the day contains similar values"
      );
  }
}