using Mapster;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Prescriptions;
using Prescriptions.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Prescriptions.Persistence.Repositories;

public class PrescriptionRepository
(
  MedDBContext context
)
  : IPrescriptionRepository
{
  public async Task AddAsync(Prescription prescriptionToAdd, CancellationToken token = default)
  {
    await context.Prescriptions
      .AddAsync(prescriptionToAdd, token);
  }

  public async Task<GetPrescriptionResponse?> GetPrescriptionResponseAsync
  (
    Guid userId, 
    CancellationToken token = default
  )
  {
    return await context.Prescriptions
      .AsNoTracking()
      .Where(p => p.Id == userId)
      .ProjectToType<GetPrescriptionResponse>()
      .FirstOrDefaultAsync(token);

  }

  public async Task<Prescription?> GetAsync(Guid id, CancellationToken token = default)
  {
    return await context.Prescriptions
      .Where(p => p.Id == id)
      .FirstOrDefaultAsync(token);
  }

  public async Task<IReadOnlyList<GetPrescriptionResponse>> GetUsersPrescriptionsByIdAsync
  (
    Guid userId,
    CancellationToken token = default
  )
  {
    return await context.Prescriptions
      .AsNoTracking()
      .Where(p => p.User.Id == userId)
      .ProjectToType<GetPrescriptionResponse>()
      .ToListAsync(token);
  }
  
  public async Task<IReadOnlyList<GetPrescriptionResponse>> GetUsersPrescriptionsByLoginAsync
  (
    string userLogin,
    CancellationToken token = default
  )
  {
    return await context.Prescriptions
      .AsNoTracking()
      .Where(p => p.User.Login.Value == userLogin)
      .ProjectToType<GetPrescriptionResponse>()
      .ToListAsync(token);
  }

  public async Task DeleteAsync(IEnumerable<Guid> ids, CancellationToken token = default)
  {
    await context.Prescriptions
      .Where(p => ids.Contains(p.Id))
      .ExecuteDeleteAsync(token);
  }

  public async Task<IReadOnlyList<Guid>> GetExistedAsync(IEnumerable<Guid> ids, CancellationToken token = default)
  {
    return await context.Prescriptions
      .Where(p => ids.Contains(p.Id))
      .Select(p => p.Id)
      .ToListAsync(token);
  }
}
