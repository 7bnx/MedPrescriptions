using Prescriptions.Contracts.Prescriptions;
using Prescriptions.Domain.Entities;

namespace Prescriptions.Application.Core.Repositories;

public interface IPrescriptionRepository
{
  Task<GetPrescriptionResponse?> GetPrescriptionResponseAsync(Guid userId, CancellationToken token = default);
  Task<Prescription?> GetAsync(Guid id, CancellationToken token = default);
  Task AddAsync(Prescription prescriptionToAdd, CancellationToken token = default);
  Task<IReadOnlyList<GetPrescriptionResponse>> GetUsersPrescriptionsByIdAsync(Guid userId, CancellationToken token = default);
  Task<IReadOnlyList<GetPrescriptionResponse>> GetUsersPrescriptionsByLoginAsync(string userLogin, CancellationToken token = default);
  Task DeleteAsync(IEnumerable<Guid> ids, CancellationToken token = default);
  Task<IReadOnlyList<Guid>> GetExistedAsync(IEnumerable<Guid> ids, CancellationToken token = default);
}
