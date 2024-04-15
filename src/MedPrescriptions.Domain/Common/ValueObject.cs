namespace Prescriptions.Domain.Common;

public abstract class ValueObject
{
  protected abstract IEnumerable<object> GetEqualityComponents();

  public override bool Equals(object? obj)
  {
    if (obj is not ValueObject valueObject)
      return false;

    return EqualsCore(valueObject);
  }

  private bool EqualsCore(ValueObject other)
    => GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());

  public override int GetHashCode()
  {
    HashCode hashCode = new();
    foreach (var component in GetEqualityComponents())
      hashCode.Add(component);

    return hashCode.ToHashCode();
  }

  public static bool operator ==(ValueObject a, ValueObject b)
  {
    if (a is null && b is null)
      return true;

    if (a is null || b is null)
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(ValueObject a, ValueObject b)
    => !(a == b);
}
