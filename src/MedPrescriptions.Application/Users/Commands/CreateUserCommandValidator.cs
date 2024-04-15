using FluentValidation;
using Prescriptions.Application.Core.Extensions;
using Prescriptions.Application.Core.Errors;

namespace Prescriptions.Application.Users.Commands;
public class CreateUserCommandValidator
  : AbstractValidator<CreateUserCommand>
{
  public CreateUserCommandValidator()
  {
    RuleLevelCascadeMode = CascadeMode.Stop;

    RuleFor(u => u.Login)
      .NotNull().WithError(ValidationErrors.CreateUserCommand.NullLogin)
      .NotEmpty().WithError(ValidationErrors.CreateUserCommand.EmptyLogin);
    ;
  }
}
