using Prescriptions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Prescriptions.Persistence.Configurations;

internal class MedicineConfiguration
  : IEntityTypeConfiguration<Medicine>
{
  public void Configure(EntityTypeBuilder<Medicine> builder)
  {

    builder.OwnsMany(medicine => medicine.DosagesAndForms, dosagesAndFormsEntity =>
    {
      dosagesAndFormsEntity.ToTable("MedicinesDosagesAndForms");
      dosagesAndFormsEntity.Property<Guid>("Id");
      dosagesAndFormsEntity.HasKey("Id");
      dosagesAndFormsEntity.WithOwner().HasForeignKey("MedicineId");

      dosagesAndFormsEntity.OwnsOne(dosageEntity => dosageEntity.Dosage, dosage =>
      {
        dosage.OwnsOne(dosage => dosage.Unit, unitEntity =>
        {
          unitEntity.Property(unit => unit.Value).HasColumnName("Unit");
        });

        dosage.OwnsOne(dosage => dosage.Quantity, quantityEntity =>
        {
          quantityEntity.Property(quantity => quantity.Value).HasColumnName("Quantity");
        });
      });

      dosagesAndFormsEntity.OwnsOne(dosageEntity => dosageEntity.Form, formEntity =>
      {
        formEntity.Property(form => form.Value).HasColumnName("Form");
      });
    });

    builder.OwnsOne(medicine => medicine.Description, descriptionEntity =>
      {
        descriptionEntity.Property(description => description.Value).HasColumnName("Description");
      });

    builder.OwnsOne(medicine => medicine.Ingredients, ingredientsEntity =>
      {
        ingredientsEntity.Property(ingredients => ingredients.Value).HasColumnName("Ingredients");
      });

    builder.OwnsOne(medicine => medicine.Name, nameEntity =>
      {
        nameEntity.Property(name => name.Value).HasColumnName("Name");
      });
  }
}
