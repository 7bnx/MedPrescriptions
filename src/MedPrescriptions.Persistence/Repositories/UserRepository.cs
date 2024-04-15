using Prescriptions.Application.Core.Repositories;
using Prescriptions.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Prescriptions.Persistence.Repositories;

public class UserRepository(MedDBContext context)
  : IUserRepository
{
  public async Task AddAsync(User userToAdd, CancellationToken token = default)
  {
    await context.Users.AddAsync(userToAdd, token);
  }

  public async Task<User?> GetUserAsync(Guid id, CancellationToken token = default)
  {
    return await context.Users.FirstOrDefaultAsync(u => u.Id == id, token);
  }

  public async Task<User?> GetUserAsync(string login, CancellationToken token = default)
  {
    return await context.Users.FirstOrDefaultAsync(u => u.Login.Value == login, token);
  }

  public async Task<bool> IsExistsAsync(Guid id, CancellationToken token = default)
  {
    return await context.Users.AnyAsync(u => u.Id == id, token);
  }

  public async Task<bool> IsExistsAsync(string login, CancellationToken token = default)
  {
    return await context.Users.AnyAsync(u => u.Login.Value == login, token);
  }
}
