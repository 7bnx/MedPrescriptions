using Prescriptions.Application.Core.Abstractions;
using Prescriptions.Application.Core.Repositories;
using Prescriptions.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Prescriptions.Persistence;
public static class DependencyInjection
{
  public static IServiceCollection AddPersistence
  (
    this IServiceCollection services, 
    Action<DbContextOptionsBuilder> optAction
  )
  {
    services.AddDbContext<MedDBContext>(optAction);
    services.AddScoped<IUnitOfWork>(serv => serv.GetRequiredService<MedDBContext>());
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IMedicineRepository, MedicineRepository>();
    services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

    return services;
  }
}
