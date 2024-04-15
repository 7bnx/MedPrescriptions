namespace Prescriptions.Contracts.Users;

public sealed record GetUserResponse
(
  Guid Id,
  string Login
);
