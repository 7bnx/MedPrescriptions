using Mapster;
using Prescriptions.Application.Prescriptions.Commands;
using Prescriptions.Contracts.Prescriptions;
using Prescriptions.Domain.Entities;

namespace Prescriptions.Application.Prescriptions.Mapping;

internal sealed class PrescriptionMappingConfig 
  : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<Prescription, GetPrescriptionResponse>()
      .Map(dest => dest.UserId, src => src.User.Id)
      .Map(dest => dest.MedicineId, src => src.Medicine.Id)
      .Map(dest => dest.MedicineName, src => src.Medicine.Name.Value)
      .Map(dest => dest.Form, src => src.Properties.DosageAndForm.Form.Value)
      .Map(dest => dest.Unit, src => src.Properties.DosageAndForm.Dosage.Unit.Value)
      .Map(dest => dest.Quantity, src => src.Properties.DosageAndForm.Dosage.Quantity.Value)
      .Map(dest => dest.Amount, src => src.Properties.Amount.Value)
      .Map(dest => dest.MealReference, src => src.Properties.MealReference.Value)
      .Map(dest => dest.Frequency, src => src.Properties.Frequency.Value)
      .Map(dest => dest.StartDate, src => src.Properties.Period.StartDate)
      .Map(dest => dest.EndDate, src => src.Properties.Period.EndDate)
      .Map(dest => dest.DurationInDays, src => src.Properties.Period.DurationInDays)
      .Map(dest => dest.TimesOfTheDay, src => src.Properties.TimesOfTheDay.Select(tod => tod.Value))
      .RequireDestinationMemberSource(true);

    config.NewConfig<IEnumerable<Guid>, DeletedPrescriptionsResponse>()
      .Map(dest => dest.Ids, src => src)
      .RequireDestinationMemberSource(true);

    config.NewConfig<IEnumerable<Guid>, DeletePrescriptionsCommand>()
      .Map(dest => dest.Ids, src => src)
      .RequireDestinationMemberSource(true);

  }
}
