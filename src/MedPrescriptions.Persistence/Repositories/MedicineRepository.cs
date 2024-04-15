using Mapster;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Contracts.Medicines;
using Prescriptions.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Prescriptions.Persistence.Repositories;

public class MedicineRepository(MedDBContext medDBContext)
  : IMedicineRepository
{
  public async Task AddAsync(Medicine medicine, CancellationToken token = default)
  {
    await medDBContext.Medicines.AddAsync(medicine, token);
  }

  public async Task<Medicine?> GetMedicineAsync(Guid id, CancellationToken token = default)
  {
    return await medDBContext.Medicines
      .Where(m => m.Id == id)
      .FirstOrDefaultAsync(token);
  }

  public async Task<GetMedicineResponse?> GetMedicineResponseAsync(Guid id, CancellationToken token = default)
  {
    return await medDBContext.Medicines.AsNoTracking()
      .Where(m => m.Id == id)
      .ProjectToType<GetMedicineResponse>()
      .FirstOrDefaultAsync(token);
  }

  public async Task<GetMedicineResponse?> GetMedicineResponseAsync(string name, CancellationToken token = default)
  {
    return await medDBContext.Medicines.AsNoTracking()
      .Where(m => m.Name.Value == name)
      .ProjectToType<GetMedicineResponse>()
      .FirstOrDefaultAsync(token);
  }

  public async Task<bool> IsExistsAsync(Guid id, CancellationToken token = default)
  {
    return await medDBContext.Medicines.AnyAsync(m => m.Id == id, token);
  }

  public async Task<bool> IsExistsAsync(string name, CancellationToken token = default)
  {
    return await medDBContext.Medicines.AnyAsync(m => m.Name.Value == name, token);
  }
}
