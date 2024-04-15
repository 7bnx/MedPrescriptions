using FluentResults;
using Prescriptions.Domain.Common;

namespace Prescriptions.Domain.ValueObjects;

public sealed class UserLogin
  : ValueObject
{
  public string Value { get; init; }

  public static Result<UserLogin> Create(string login)
    => Result.Ok<UserLogin>(new(login));

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }

  private UserLogin(string value)
    => Value = value;
}
