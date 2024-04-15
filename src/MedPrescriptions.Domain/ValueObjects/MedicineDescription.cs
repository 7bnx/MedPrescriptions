using FluentResults;
using Prescriptions.Domain.Common;

namespace Prescriptions.Domain.ValueObjects;

public sealed class MedicineDescription
  : ValueObject
{
  public string Value { get; init; }

  public static Result<MedicineDescription> Create(string? description)
    => Result.Ok<MedicineDescription>(new(description));

  public static implicit operator string(MedicineDescription description)
    => description.Value;

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }

  private MedicineDescription(string? value)
    => Value = value ?? string.Empty;

#pragma warning disable CS8618
  private MedicineDescription() { }
#pragma warning restore CS8618
}
