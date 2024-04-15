﻿namespace Prescriptions.Domain.Common;

public abstract class Entity
{
  public virtual Guid Id { get; protected set; }

  public override bool Equals(object? obj)
  {
    if (obj is not Entity other)
      return false;

    if (ReferenceEquals(this, other))
      return true;

    if (Id == default || other.Id == default)
      return false;

    return Id == other.Id;
  }

  public static bool operator ==(Entity a, Entity b)
  {
    if (a is null && b is null)
      return true;

    if (a is null || b is null)
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(Entity a, Entity b)
    => !(a == b);

  public override int GetHashCode()
    => (GetType().ToString() + Id).GetHashCode();
}