using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.ValueObjects;

namespace Prescriptions.Domain.Entities;

public sealed class User
  : Entity
{
  public UserLogin Login { get; private set; }
  public static Result<User> Create(string login)
  {
    var resultLogin = UserLogin.Create(login);
    if (resultLogin.IsFailed)
      return Result.Fail(resultLogin.Errors);

    return Result.Ok<User>(new(resultLogin.Value));
  }
  private User(UserLogin login)
  {
    Id = Guid.NewGuid();
    Login = login;
  }

#pragma warning disable CS8618
  private User() { }
#pragma warning restore CS8618
}
