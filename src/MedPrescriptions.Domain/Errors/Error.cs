using FluentResults;

namespace Prescriptions.Domain.Common.Errors;

public sealed partial class Errors 
  : IError
{
  public List<IError> Reasons { get; init; }

  public string Message { get; init; }
  public string Code { get;init; }

  public Dictionary<string, object> Metadata { get; init; }

  private Errors
  (
    string code,
    string message,
    IEnumerable<IError> reasons = default!
  )
  {
    Code = code;
    Message = message;
    Metadata = new Dictionary<string, object> { ["Code"] = code };
    Reasons = reasons?.ToList() ?? default!;
  }
}
