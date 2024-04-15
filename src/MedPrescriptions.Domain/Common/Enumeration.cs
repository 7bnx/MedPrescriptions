using System.Reflection;
using FluentResults;

namespace Prescriptions.Domain.Common;

public abstract class Enumeration<TEnum>
  : IComparable<Enumeration<TEnum>>, IEnumerationInvalid<Enumeration<TEnum>>
    where TEnum : Enumeration<TEnum>, IEnumerationInvalid<TEnum>
{
  private static readonly Lazy<Dictionary<int, TEnum>> _enumerationsDictionary =
    new(() => GetAllEnumerationOptions().ToDictionary(item => item.Value));

  public string Name { get; }
  public int Value { get; }

  protected Enumeration(int value, string name)
  {
    Name = name;
    Value = value;
  }

  public static Result<TEnum> FromValue(int value)
  {
    if (!_enumerationsDictionary.Value.TryGetValue(value, out var enumValue))
      return Result.Fail(TEnum.InvalidFromValueError);

    return Result.Ok(enumValue);
  }

  public static IReadOnlyList<TEnum> Values
    => _enumerationsDictionary.Value.Values.ToList();

  static IError IEnumerationInvalid<Enumeration<TEnum>>.InvalidFromValueError
    => TEnum.InvalidFromValueError;

  public override string ToString()
    => Name;

  public override bool Equals(object? obj)
  {
    if (obj is not Enumeration<TEnum> otherValue)
      return false;

    var typeMatches = GetType() == obj.GetType();
    var valueMatches = Value.Equals(otherValue.Value);

    return typeMatches && valueMatches;
  }

  public static bool operator ==(Enumeration<TEnum> a, Enumeration<TEnum> b)
  {
    if (a is null && b is null)
      return true;

    if (a is null || b is null)
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(Enumeration<TEnum> a, Enumeration<TEnum> b)
    => !(a == b);

  public override int GetHashCode()
    => Value.GetHashCode();

  public int CompareTo(Enumeration<TEnum>? other)
    => other is null ? 1 : Value.CompareTo(other.Value);

  public static bool ContainsValue(int value)
    => _enumerationsDictionary.Value.ContainsKey(value);

  private static List<TEnum> GetAllEnumerationOptions()
  {
    Type enumType = typeof(TEnum);

    IEnumerable<Type> enumerationTypes = Assembly
        .GetAssembly(enumType)!
        .GetTypes()
        .Where(type => enumType.IsAssignableFrom(type));

    var enumerations = new List<TEnum>();

    foreach (Type enumerationType in enumerationTypes)
    {
      List<TEnum> enumerationTypeOptions = GetFieldsOfType<TEnum>(enumerationType);

      enumerations.AddRange(enumerationTypeOptions);
    }

    return enumerations;
  }

  public static implicit operator string(Enumeration<TEnum> enumeration)
    => enumeration.Name;

  public static implicit operator int(Enumeration<TEnum> enumeration)
    => enumeration.Value;

  private static List<TFieldType> GetFieldsOfType<TFieldType>(Type type)
    => type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
        .Where(fieldInfo => type.IsAssignableFrom(fieldInfo.FieldType))
        .Select(fieldInfo => (TFieldType)fieldInfo.GetValue(null)!)
        .ToList();

#pragma warning disable CS8618
  protected Enumeration() { }
#pragma warning restore CS8618
}
