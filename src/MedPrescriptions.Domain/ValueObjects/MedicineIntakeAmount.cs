using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.Common.Errors;

namespace Prescriptions.Domain.ValueObjects;

public sealed class MedicineIntakeAmount
  : ValueObject
{
  public double Value { get; }

  private static MedicineIntakeAmount _notSpecified = default!;

  public static MedicineIntakeAmount NotSpecified
    => _notSpecified ??= new MedicineIntakeAmount(0);

  public static Result<MedicineIntakeAmount> Create(double amount)
  {
    if (amount <= 0)
      return Result.Fail(Errors.MedicineIntakeAmount.InvalidAmount);

    return Result.Ok<MedicineIntakeAmount>(new(amount));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }

  private MedicineIntakeAmount(double value)
  {
    Value = value;
  }
  private MedicineIntakeAmount() { }
}
