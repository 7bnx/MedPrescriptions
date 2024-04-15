using System.Runtime.CompilerServices;
using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.Common.Errors;

namespace Prescriptions.Domain.Enumerations;

public sealed class FrequencyOfMedication
  : Enumeration<FrequencyOfMedication>, IEnumerationInvalid<FrequencyOfMedication>
{
  public static readonly FrequencyOfMedication EveryDay = new(0);
  public static readonly FrequencyOfMedication EveryTwoDays = new(1);
  public static readonly FrequencyOfMedication EveryThreeDays = new(2);
  public static readonly FrequencyOfMedication OnceAWeek = new(3);

  static IError IEnumerationInvalid<FrequencyOfMedication>.InvalidFromValueError
    => Errors.FrequencyOfMedication.InvalidValue;

  private FrequencyOfMedication(int value, [CallerMemberName] string name = default!)
    : base(value, name) { }

  private FrequencyOfMedication() { }
}
