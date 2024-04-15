namespace Prescriptions.Application.Core.Abstractions;

public interface ITransaction
  : IAsyncDisposable
{
  Task CommitAsync(CancellationToken token = default);
  Task RollbackAsync(CancellationToken token = default);
}
