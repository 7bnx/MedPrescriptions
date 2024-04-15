using Prescriptions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Prescriptions.Persistence.Configurations;

internal class UserConfiguration 
  : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.OwnsOne(user => user.Login, loginEntity =>
    loginEntity.Property(login => login.Value).HasColumnName("Login"));
  }
}
