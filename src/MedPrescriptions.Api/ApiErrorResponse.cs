using FluentResults;

namespace Prescriptions.Api;

public class ApiErrorResponse(IEnumerable<Error> errors)
{
  public IReadOnlyCollection<Error> Errors { get; } = errors.ToList();
}
