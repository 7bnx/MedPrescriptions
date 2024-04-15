using System.Runtime.CompilerServices;
using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.Common.Errors;

namespace Prescriptions.Domain.Enumerations;
public sealed class MealReference
  : Enumeration<MealReference>, IEnumerationInvalid<MealReference>
{
  public static readonly MealReference Unspecified = new(0);
  public static readonly MealReference NotMatter = new(1);
  public static readonly MealReference Before = new(2);
  public static readonly MealReference During = new(3);
  public static readonly MealReference After = new(4);

  static IError IEnumerationInvalid<MealReference>.InvalidFromValueError
    => Errors.MealReference.InvalidValue;

  private MealReference() { }

  private MealReference(int value, [CallerMemberName] string name = default!)
    : base(value, name) { }
}
