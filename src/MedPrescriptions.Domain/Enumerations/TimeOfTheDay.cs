using System.Runtime.CompilerServices;
using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.Common.Errors;

namespace Prescriptions.Domain.Enumerations;

public sealed class TimeOfTheDay
  : Enumeration<TimeOfTheDay>, IEnumerationInvalid<TimeOfTheDay>
{
  public static readonly TimeOfTheDay Unspecified = new(0);
  public static readonly TimeOfTheDay NotMatter = new(1);
  public static readonly TimeOfTheDay Morning = new(2);
  public static readonly TimeOfTheDay Afternoon = new(3);
  public static readonly TimeOfTheDay Evening = new(4);
  public static readonly TimeOfTheDay Night = new(5);

  private TimeOfTheDay() { }

  private TimeOfTheDay(int value, [CallerMemberName] string name = default!)
    : base(value, name) { }

  static IError IEnumerationInvalid<TimeOfTheDay>.InvalidFromValueError
    => Errors.TimeOfTheDay.InvalidValue;
}
