using Prescriptions.Domain.Common;
using Prescriptions.Domain.ValueObjects;

namespace Prescriptions.Domain.Entities;

public sealed class Prescription
  : Entity
{
  public User User { get; private set; }
  public Medicine Medicine { get; private set; }
  public PrescriptionProperties Properties { get; private set; }

  public Prescription
  (
    User user,
    Medicine medicine,
    PrescriptionProperties properties
  )
  {
    Id = Guid.NewGuid();
    User = user;
    Medicine = medicine;
    Properties = properties;
  }

  public void ChangeMedicine(Medicine newMedicine)
  {
    Medicine = newMedicine;
  }

  public void ChangeProperties(PrescriptionProperties properties)
  {
    Properties = properties;
  }

#pragma warning disable CS8618
  private Prescription() { }
#pragma warning restore CS8618
}
