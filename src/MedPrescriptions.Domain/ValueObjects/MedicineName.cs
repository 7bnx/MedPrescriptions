using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.Common.Errors;

namespace Prescriptions.Domain.ValueObjects;

public sealed class MedicineName
  : ValueObject
{
  public string Value { get; init; }

  public static Result<MedicineName> Create(string name)
  {
    if (string.IsNullOrEmpty(name))
      return Result.Fail(Errors.MedicineName.InvalidName);

    return Result.Ok<MedicineName>(new(name));
  }

  public static implicit operator string(MedicineName name)
    => name.Value;

  private MedicineName(string value)
  {
    Value = value;
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
