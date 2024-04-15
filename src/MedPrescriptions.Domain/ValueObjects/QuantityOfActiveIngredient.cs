using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.Common.Errors;

namespace Prescriptions.Domain.ValueObjects;

public sealed class QuantityOfActiveIngredient
  : ValueObject
{
  public double Value { get; init; }

  public static implicit operator double(QuantityOfActiveIngredient quantity)
    => quantity.Value;

  public static QuantityOfActiveIngredient Unspecified => _unspecified ??= new(0);

  private static QuantityOfActiveIngredient? _unspecified;

  public static Result<QuantityOfActiveIngredient> Create(double value)
  {
    if (value <= 0)
      return Result.Fail(Errors.QuantityOfActiveIngredient.InvalidValue);

    return Result.Ok<QuantityOfActiveIngredient>(new(value));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }

  private QuantityOfActiveIngredient(double value)
    => Value = value;
}
