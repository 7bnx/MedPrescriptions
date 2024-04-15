using FluentResults;
using Prescriptions.Domain.Common;

namespace Prescriptions.Domain.ValueObjects;

public sealed class MedicineIngredients
  : ValueObject
{
  public string Value { get; init; }

  public static Result<MedicineIngredients> Create(string? ingredients)
  {
    return Result.Ok<MedicineIngredients>(new(ingredients));
  }

  public static implicit operator string(MedicineIngredients ingredients)
    => ingredients.Value;

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }

  private MedicineIngredients(string? ingredients) 
    => Value = ingredients ?? string.Empty;

#pragma warning disable CS8618
  private MedicineIngredients() { }
#pragma warning restore CS8618
}
