namespace Prescriptions.Application.Core.Errors;

public partial class ValidationErrors
{
  public static class CreateUserCommand
  {
    private static ValidationErrors? _nullLogin;

    public static ValidationErrors NullLogin
      => _nullLogin ??= new
      (
        $"{nameof(CreateUserCommand)}.{nameof(NullLogin)}",
        "Login is required"
      );

    private static ValidationErrors? _emptyLogin;

    public static ValidationErrors EmptyLogin
      => _emptyLogin ??= new
      (
        $"{nameof(CreateUserCommand)}.{nameof(EmptyLogin)}",
        "Login is required"
      );
  }
}
