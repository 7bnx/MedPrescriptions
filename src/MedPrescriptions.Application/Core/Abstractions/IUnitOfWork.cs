namespace Prescriptions.Application.Core.Abstractions;

public interface IUnitOfWork
{
  Task SaveAsync(CancellationToken token = default);
  Task<ITransaction> BeginTransactionAsync(CancellationToken token = default);
}
