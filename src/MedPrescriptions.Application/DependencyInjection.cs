using System.Reflection;
using EventReminder.Application.Core.Behaviors;
using FluentValidation;
using Mapster;
using MapsterMapper;
using Prescriptions.Application.Core.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Prescriptions.Application;
public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    services.AddMediatR(config =>
    {
      config.AddOpenBehavior(typeof(ValidationBehavior<,>));
      config.AddOpenBehavior(typeof(TransactionBehavior<,>));
      config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
    });

    var config = TypeAdapterConfig.GlobalSettings;
    config.Scan(Assembly.GetExecutingAssembly());
    services.AddSingleton(config);
    services.AddScoped<IMapper, ServiceMapper>();

    return services;
  }
}
