using Prescriptions.Application.Core.Abstractions;
using MediatR;

namespace Prescriptions.Application.Core.Behaviors;

internal sealed class TransactionBehavior<TRequest, TResponse>
(
  IUnitOfWork unitOfWork
)
  : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class
{
  public async Task<TResponse> Handle
  (
    TRequest request,
    RequestHandlerDelegate<TResponse> next,
    CancellationToken cancellationToken
  )
  {
    if (request is not ISavable)
      return await next();

    await using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
    try
    {
      var response = await next();
      await unitOfWork.SaveAsync(cancellationToken);
      await transaction.CommitAsync(cancellationToken);
      return response;
    }
    catch
    {
      await transaction.RollbackAsync(cancellationToken);
      throw;
    }
  }
}
