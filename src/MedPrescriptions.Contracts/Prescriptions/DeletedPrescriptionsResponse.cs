namespace Prescriptions.Contracts.Prescriptions;

public sealed record DeletedPrescriptionsResponse
(
  IEnumerable<Guid> Ids
);
