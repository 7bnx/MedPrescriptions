using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Prescriptions.Api.Filters;

public sealed class ApiExceptionFilterAttribute 
  : ExceptionFilterAttribute
{
  private static readonly Dictionary<Type, Action<ExceptionContext>> _exceptionHandlers = new()
  { 
    [typeof(ValidationException)] = ValidationExceptionHandler 
  };

  public override Task OnExceptionAsync(ExceptionContext context)
  {
    HandleException(context);
    return base.OnExceptionAsync(context);
  }

  public override void OnException(ExceptionContext context)
  {
    HandleException(context);

    base.OnException(context);
  }

  private static void HandleException(ExceptionContext context)
  {
    Type type = context.Exception.GetType();
    if (_exceptionHandlers.TryGetValue(type, out var handler))
    {
      handler(context);
      return;
    }

    HandleUnhandledException(context);
  }

  private static void ValidationExceptionHandler(ExceptionContext context)
  {
    var exception = (ValidationException)context.Exception;

    var details = new ValidationProblemDetails(exception.Errors.ToDictionary(x => x.ErrorCode, x => new string[] { x.ErrorMessage }))
    {
      Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
    };

    context.Result = new BadRequestObjectResult(details);

    context.ExceptionHandled = true;
  }

  private static void HandleUnhandledException(ExceptionContext context)
  {
    throw new NotImplementedException();
  }
}
