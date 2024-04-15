using Prescriptions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Prescriptions.Persistence.Configurations;

internal class PrescriptionConfiguration 
  : IEntityTypeConfiguration<Prescription>
{
  public void Configure(EntityTypeBuilder<Prescription> builder)
  {
    builder.OwnsOne(prescription => prescription.Properties, propertiesEntity =>
    {
      propertiesEntity.OwnsOne(properties => properties.MealReference, mealReferenceEntity =>
      {
        mealReferenceEntity.Property(mealReference => mealReference.Value).HasColumnName("MealReference");
      });

      propertiesEntity.OwnsOne(properties => properties.Frequency, frequencyEntity =>
      {
        frequencyEntity.Property(frequency => frequency.Value).HasColumnName("Frequency");
      });

      propertiesEntity.OwnsOne(properties => properties.Period, periodEntity =>
      {
        periodEntity.Property(period => period.StartDate).HasColumnName("StartDate");
        periodEntity.Property(period => period.EndDate).HasColumnName("EndDate");
        periodEntity.Property(period => period.DurationInDays).HasColumnName("DurationInDays");
      });

      propertiesEntity.OwnsOne(properties => properties.DosageAndForm, dosageAndFormEntity =>
      {
        dosageAndFormEntity.OwnsOne(dosageEntity => dosageEntity.Dosage, dosage =>
        {
          dosage.OwnsOne(dosage => dosage.Unit, unitEntity =>
          {
            unitEntity.Property(unit => unit.Value).HasColumnName("MedicineUnit");
          });

          dosage.OwnsOne(dosage => dosage.Quantity, quantityEntity =>
          {
            quantityEntity.Property(quantity => quantity.Value).HasColumnName("ActiveIngredientQuantity");
          });
        });

        dosageAndFormEntity.OwnsOne(dosageEntity => dosageEntity.Form, formEntity =>
        {
          formEntity.Property(form => form.Value).HasColumnName("MedicineForm");
        });
      });

      propertiesEntity.OwnsOne(properties => properties.Amount, amountEntity =>
      {
        amountEntity.Property(amount => amount.Value).HasColumnName("Amount");
      });

      propertiesEntity.OwnsMany(properties => properties.TimesOfTheDay, timesOfTheDayEntity =>
      {
        timesOfTheDayEntity.ToTable("TimesOfTheDay");
        timesOfTheDayEntity.Property<Guid>("Id");
        timesOfTheDayEntity.HasKey("Id");
        timesOfTheDayEntity.WithOwner().HasForeignKey("PrescriptionId");
      });
    });
  }
}
