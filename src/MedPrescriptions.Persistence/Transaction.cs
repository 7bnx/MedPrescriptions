using Prescriptions.Application.Core.Abstractions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Prescriptions.Persistence;

public class Transaction(IDbContextTransaction transaction)
    : ITransaction
{
  private readonly IDbContextTransaction _transaction = transaction;

  public async Task CommitAsync(CancellationToken token = default)
  {
    await _transaction.CommitAsync(token);
  }

  public async ValueTask DisposeAsync()
  {
    await _transaction.DisposeAsync();
    GC.SuppressFinalize(this);
  }

  public async Task RollbackAsync(CancellationToken token = default)
  {
    await _transaction.RollbackAsync(token);
  }
}
