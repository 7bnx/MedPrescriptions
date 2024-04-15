using FluentValidation;
using Prescriptions.Application.Core.Errors;
using Prescriptions.Application.Core.Extensions;

namespace Prescriptions.Application.Prescriptions.Commands;
public class PrescriptionPropertiesDTOValidator
  : AbstractValidator<PrescriptionPropertiesDTO>
{
  public PrescriptionPropertiesDTOValidator()
  {
    RuleLevelCascadeMode = CascadeMode.Stop;

    RuleFor(p => p.DosageUnit)
      .NotNull().WithError(ValidationErrors.PrescriptionProperties.NullDosageUnit);

    RuleFor(p => p.DosageQuantity)
      .NotNull().WithError(ValidationErrors.PrescriptionProperties.NullDosageQuantity);

    RuleFor(p => p.Form)
      .NotNull().WithError(ValidationErrors.PrescriptionProperties.NullForm);

    RuleFor(p => p.MealReference)
      .NotNull().WithError(ValidationErrors.PrescriptionProperties.NullMealReference);

    RuleFor(p => p.Frequency)
      .NotNull().WithError(ValidationErrors.PrescriptionProperties.NullFrequency);

    RuleFor(p => p.StartDate)
      .NotNull().WithError(ValidationErrors.PrescriptionProperties.NullStartDate)
      .Must(sd => sd > new DateOnly(2020, 1, 1)).WithError(ValidationErrors.PrescriptionProperties.EarlyStartDate)
      .Must(sd => sd < new DateOnly(2030, 1, 1)).WithError(ValidationErrors.PrescriptionProperties.LateStartDate);

    RuleFor(p => p.Duration)
      .NotNull().WithError(ValidationErrors.PrescriptionProperties.NullDuration)
      .GreaterThan(0).WithError(ValidationErrors.PrescriptionProperties.InvalidDuration);

    RuleFor(p => p.Amount)
      .NotNull().WithError(ValidationErrors.PrescriptionProperties.NullAmount);

    RuleFor(p => p.TimesOfTheDay)
      .NotNull().WithError(ValidationErrors.PrescriptionProperties.NullTimesOfTheDay)
      .NotEmpty().WithError(ValidationErrors.PrescriptionProperties.EmptyTimesOfTheDay);
  }
}
