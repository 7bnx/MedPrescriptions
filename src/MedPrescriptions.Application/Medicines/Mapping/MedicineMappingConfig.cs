using Mapster;
using Prescriptions.Application.Medicines.Commands;
using Prescriptions.Contracts.Medicines;
using Prescriptions.Domain.Entities;

namespace Prescriptions.Application.Medicines.Mapping;

internal sealed class MedicineMappingConfig
  : IRegister
{
  public void Register(TypeAdapterConfig config)
  {

    config
        .NewConfig<Medicine, GetMedicineResponse>()
        .Map(dest => dest.Name, src => src.Name.Value)
        .Map(dest => dest.Description, src => src.Description.Value)
        .Map(dest => dest.Ingredients, src => src.Ingredients.Value)
        .Map(dest => dest.DosagesAndForms, src => src.DosagesAndForms.Select(daf => 
          new GetMedicineResponseDosageAndForm
          (
            daf.Form,
            daf.Dosage.Quantity,
            daf.Dosage.Unit
          )))
        .RequireDestinationMemberSource(true);

    config
      .NewConfig<Medicine, CreatedMedicineResponse>()
      .Map(dest => dest.Name, src => src.Name.Value)
      .RequireDestinationMemberSource(true);

    config
      .NewConfig<Medicine, UpdatedMedicineResponse>()
      .Map(dest => dest.Name, src => src.Name.Value)
      .RequireDestinationMemberSource(true);

    config
      .NewConfig<CreateMedicineRequest, CreateMedicineCommand>()
      .RequireDestinationMemberSource(true);
  }
}