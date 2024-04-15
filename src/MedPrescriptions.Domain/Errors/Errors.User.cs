namespace Prescriptions.Domain.Common.Errors;

public partial class Errors
{
  public static class User
  {
    private static Errors? _userNotExists;

    public static Errors UserNotExists
      => _userNotExists ??= new
      (
        $"{nameof(User)}.{nameof(UserNotExists)}",
        "The specified user not exists"
      );

    private static Errors? _userAlreadyExists;

    public static Errors UserAlreadyExists
      => _userAlreadyExists ??= new
      (
        $"{nameof(User)}.{nameof(UserAlreadyExists)}",
        "The specified user already exists"
      );
  }
}
