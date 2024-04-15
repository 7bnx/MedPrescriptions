using System.Runtime.CompilerServices;
using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.Common.Errors;

namespace Prescriptions.Domain.Enumerations;

public sealed class MedicineForm
  : Enumeration<MedicineForm>, IEnumerationInvalid<MedicineForm>
{
  public static readonly MedicineForm Unspecified = new(0);
  public static readonly MedicineForm Pill = new(1);
  public static readonly MedicineForm Capsule = new(2);
  public static readonly MedicineForm Ointment = new(3);
  public static readonly MedicineForm Drops = new(4);

  private MedicineForm(int value, [CallerMemberName] string name = default!)
    : base(value, name) { }

  static IError IEnumerationInvalid<MedicineForm>.InvalidFromValueError
    => Errors.MedicineForm.InvalidValue;

  private MedicineForm() { }
}
