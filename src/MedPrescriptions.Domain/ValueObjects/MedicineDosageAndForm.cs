using Prescriptions.Domain.Common;
using Prescriptions.Domain.Enumerations;

namespace Prescriptions.Domain.ValueObjects;
public sealed class MedicineDosageAndForm
    : ValueObject
{
  public MedicineForm Form { get; private set; }
  public ActiveIngredientDosage Dosage { get; private set; }

  public MedicineDosageAndForm(MedicineForm form, ActiveIngredientDosage? dosage = default)
  {
    Form = form;

    Dosage = dosage ?? ActiveIngredientDosage.Unspecified;
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Form;
    yield return Dosage!;
  }

#pragma warning disable CS8618
  private MedicineDosageAndForm() { }
#pragma warning restore CS8618
}
