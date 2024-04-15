using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.Enumerations;

namespace Prescriptions.Domain.ValueObjects;

public sealed class ActiveIngredientDosage
  : ValueObject
{
  public UnitOfActiveIngredient Unit { get; init; }
  public QuantityOfActiveIngredient Quantity { get; init; }

  private static ActiveIngredientDosage? _unspecified;
  public static ActiveIngredientDosage Unspecified
    => _unspecified ??= new(UnitOfActiveIngredient.Unspecified, QuantityOfActiveIngredient.Unspecified);

  public static Result<ActiveIngredientDosage> Create(int unit, double quantity)
  {
    var resultUnit = UnitOfActiveIngredient.FromValue(unit);
    Result<QuantityOfActiveIngredient>? resultQuantity;
    if (resultUnit.IsSuccess && resultUnit.Value.IsUnspecified)
      resultQuantity = Result.Ok(QuantityOfActiveIngredient.Unspecified);
    else
      resultQuantity = QuantityOfActiveIngredient.Create(quantity);

    if (resultUnit.IsFailed || resultQuantity.IsFailed)
      return Result.Merge(resultUnit, resultQuantity);

    return Result.Ok<ActiveIngredientDosage>(new(resultUnit.Value, resultQuantity.Value));
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Unit;
    yield return Quantity;
  }

  private ActiveIngredientDosage(UnitOfActiveIngredient unit, QuantityOfActiveIngredient quantity)
  {
    Unit = unit;
    Quantity = quantity;
  }

#pragma warning disable CS8618
  private ActiveIngredientDosage() { }
#pragma warning restore CS8618
}
