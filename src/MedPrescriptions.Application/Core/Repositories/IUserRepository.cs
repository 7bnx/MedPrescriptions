using Prescriptions.Domain.Entities;

namespace Prescriptions.Application.Core.Repositories;

public interface IUserRepository
{
  Task<bool> IsExistsAsync(Guid id, CancellationToken token = default);
  Task<bool> IsExistsAsync(string login, CancellationToken token = default);
  Task<User?> GetUserAsync(Guid id, CancellationToken token = default);
  Task<User?> GetUserAsync(string login, CancellationToken token = default);
  Task AddAsync(User userToAdd, CancellationToken token = default);
}
