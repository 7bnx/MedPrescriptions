using System.Runtime.CompilerServices;
using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.Common.Errors;

namespace Prescriptions.Domain.Enumerations;

public sealed class UnitOfActiveIngredient
  : Enumeration<UnitOfActiveIngredient>, IEnumerationInvalid<UnitOfActiveIngredient>
{
  public static readonly UnitOfActiveIngredient Unspecified = new(0);
  public static readonly UnitOfActiveIngredient Ml = new(1);
  public static readonly UnitOfActiveIngredient L = new(2);
  public static readonly UnitOfActiveIngredient Mg = new(3);
  public static readonly UnitOfActiveIngredient G = new(4);
  public static readonly UnitOfActiveIngredient Piece = new(5);

  public bool IsUnspecified
    => this == Unspecified;

  private UnitOfActiveIngredient(int value, [CallerMemberName] string name = default!)
    : base(value, name) { }

  static IError IEnumerationInvalid<UnitOfActiveIngredient>.InvalidFromValueError
    => Errors.UnitOfActiveIngredient.InvalidUnit;

  private UnitOfActiveIngredient() { }
}
