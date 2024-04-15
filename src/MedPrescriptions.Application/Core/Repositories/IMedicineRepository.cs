using Prescriptions.Contracts.Medicines;
using Prescriptions.Domain.Entities;

namespace Prescriptions.Application.Core.Repositories;

public interface IMedicineRepository
{
  Task<GetMedicineResponse?> GetMedicineResponseAsync(Guid id, CancellationToken token = default);
  Task<GetMedicineResponse?> GetMedicineResponseAsync(string name, CancellationToken token = default);
  Task<Medicine?> GetMedicineAsync(Guid id, CancellationToken token = default);
  Task<bool> IsExistsAsync(Guid id, CancellationToken token = default);
  Task<bool> IsExistsAsync(string name, CancellationToken token = default);
  Task AddAsync(Medicine medicine, CancellationToken token = default);
}
