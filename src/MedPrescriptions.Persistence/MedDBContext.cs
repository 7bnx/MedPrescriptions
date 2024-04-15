using System.Reflection;
using Prescriptions.Application.Core.Abstractions;
using Prescriptions.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Prescriptions.Persistence;

public class MedDBContext : DbContext, IUnitOfWork
{
  public DbSet<Prescription> Prescriptions { get; set; }
  public DbSet<Medicine> Medicines { get; set; }
  public DbSet<User> Users { get; set; }

  public MedDBContext(DbContextOptions<MedDBContext> options) 
    : base(options) { }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    base.OnModelCreating(modelBuilder);
  }

  public async Task SaveAsync(CancellationToken token = default)
  {
    await SaveChangesAsync(token);
  }

  public async Task<ITransaction> BeginTransactionAsync(CancellationToken token = default)
  {
    var transaction = await this.Database.BeginTransactionAsync(token);
    return new Transaction(transaction);
  }
}
