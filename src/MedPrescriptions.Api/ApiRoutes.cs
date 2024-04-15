namespace Prescriptions.Api;

public static class ApiRoutes
{
  public static class Users
  {
    public const string GetById = "{userId:guid}";
    public const string GetByName = "{userLogin}";
    public const string Create = "";
  }

  public static class Medicines
  {
    public const string GetById = "{medicineId:guid}";
    public const string GetByName = "{medicineName}";
    public const string Create = "";
    public const string Update = "";
  }

  public static class Prescriptions
  {
    public const string GetByUserId = "user/{userId:guid}";
    public const string GetByUserLogin = "user/{userLogin}";
    public const string GetById = "{prescriptionId:guid}";
    public const string Create = "";
    public const string Update = "";
    public const string Delete = "";
  }
}
