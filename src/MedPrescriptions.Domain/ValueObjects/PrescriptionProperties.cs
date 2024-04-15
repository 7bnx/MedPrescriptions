using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.Common.Errors;
using Prescriptions.Domain.Enumerations;

namespace Prescriptions.Domain.ValueObjects;

public sealed class PrescriptionProperties
  : ValueObject
{
  public MedicineDosageAndForm DosageAndForm { get; private set; }
  public MealReference MealReference { get; private set; }
  public FrequencyOfMedication Frequency { get; private set; }
  public IReadOnlyList<TimeOfTheDay> TimesOfTheDay => _timesOfTheDay;
  public PeriodOfMedication Period { get; private set; }
  public MedicineIntakeAmount Amount { get; private set; }

  private readonly List<TimeOfTheDay> _timesOfTheDay;

  public static Result<PrescriptionProperties> Create
  (
    int dosageUnit,
    double dosageQuantity,
    int form,
    int mealReference,
    int frequency,
    DateOnly startDate,
    int duration,
    double amount,
    IEnumerable<int> timesOfTheDay
  )
  {
    var dosageAndFormResult = ActiveIngredientDosage.Create(dosageUnit, dosageQuantity);
    if (dosageAndFormResult.IsFailed)
      return Result.Fail(dosageAndFormResult.Errors);

    var formResult = MedicineForm.FromValue(form);
    if (formResult.IsFailed)
      return Result.Fail(formResult.Errors);

    var mealReferenceResult = MealReference.FromValue(mealReference);
    if (mealReferenceResult.IsFailed)
      return Result.Fail(mealReferenceResult.Errors);

    var frequencyResult = FrequencyOfMedication.FromValue(frequency);
    if (frequencyResult.IsFailed)
      return Result.Fail(frequencyResult.Errors);

    var periodResult = PeriodOfMedication.Create(startDate, duration);
    if (periodResult.IsFailed)
      return Result.Fail(periodResult.Errors);

    var amountResult = MedicineIntakeAmount.Create(amount);
    if (amountResult.IsFailed)
      return Result.Fail(amountResult.Errors);

    HashSet<TimeOfTheDay> timeOfTheDays = [];
    foreach (var tod in timesOfTheDay)
    {
      var timeOfTheDayResult = TimeOfTheDay.FromValue(tod);
      if (timeOfTheDayResult.IsFailed)
        return Result.Fail(timeOfTheDayResult.Errors);

      if (!timeOfTheDays.Add(timeOfTheDayResult.Value))
        return Result.Fail(Errors.PrescriptionProperties.SimilarValuesTimesOfTheDay);
    }

    var properties = new PrescriptionProperties
    (
      dosageAndForm: new MedicineDosageAndForm(formResult.Value, dosageAndFormResult.Value),
      mealReference: mealReferenceResult.Value,
      frequency: frequencyResult.Value,
      period: periodResult.Value,
      amount: amountResult.Value,
      timesOfTheDay: timeOfTheDays.Order()
    );

    return Result.Ok(properties);
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return DosageAndForm;
    yield return MealReference;
    yield return Period;
    yield return Frequency;
    yield return Amount;
    foreach (var tod in _timesOfTheDay)
      yield return tod;
  }

  private PrescriptionProperties
  (
    MedicineDosageAndForm dosageAndForm,
    MealReference mealReference,
    FrequencyOfMedication frequency,
    PeriodOfMedication period,
    MedicineIntakeAmount amount,
    IEnumerable<TimeOfTheDay> timesOfTheDay
  )
  {
    DosageAndForm = dosageAndForm;
    MealReference = mealReference;
    Frequency = frequency;
    Period = period;
    Amount = amount;
    _timesOfTheDay = timesOfTheDay.ToList();
  }

#pragma warning disable CS8618
  private PrescriptionProperties() { }
#pragma warning restore CS8618
}
