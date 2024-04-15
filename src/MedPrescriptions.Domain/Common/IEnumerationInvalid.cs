using FluentResults;

namespace Prescriptions.Domain.Common;

public interface IEnumerationInvalid<T> where T : IEnumerationInvalid<T>
{
  protected static abstract IError InvalidFromValueError { get; }
}
