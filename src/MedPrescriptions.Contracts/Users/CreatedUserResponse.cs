namespace Prescriptions.Contracts.Users;

public sealed record CreatedUserResponse
(
  Guid Id,
  string Login
);