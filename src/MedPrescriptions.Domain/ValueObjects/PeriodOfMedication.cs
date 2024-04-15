using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.Common.Errors;

namespace Prescriptions.Domain.ValueObjects;
public sealed class PeriodOfMedication
  : ValueObject
{
  public DateOnly StartDate { get; init; }
  public int DurationInDays { get; init; }
  public DateOnly EndDate { get; init; }
  private bool? _isActive;

  public static Result<PeriodOfMedication> Create(DateOnly startDate, int durationInDays)
  {
    if (durationInDays <= 0)
      return Result.Fail(Errors.PeriodOfMedication.InvalidDuration);

    return Result.Ok<PeriodOfMedication>(new(startDate, durationInDays));
  }

  public bool IsActive()
    => _isActive ??= EndDate >= StartDate;

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return StartDate;
    yield return EndDate;
    yield return DurationInDays;
  }

  private PeriodOfMedication
  (
    DateOnly startDate,
    int durationInDays
  )
  {
    StartDate = startDate;
    DurationInDays = durationInDays;
    EndDate = startDate.AddDays(durationInDays - 1);
  }

  private PeriodOfMedication() { }
}
