using Mapster;
using Prescriptions.Contracts.Users;
using Prescriptions.Domain.Entities;

namespace Prescriptions.Application.Users.Mapping;

internal sealed class UserMappingConfig 
  : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<User, CreatedUserResponse>()
      .Map(dest => dest.Login, src => src.Login.Value)
      .RequireDestinationMemberSource(true);

    config.NewConfig<User, GetUserResponse>()
      .Map(dest => dest.Login, src => src.Login.Value)
      .RequireDestinationMemberSource(true);
  }
}
