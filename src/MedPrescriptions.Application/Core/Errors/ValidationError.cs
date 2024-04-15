namespace Prescriptions.Application.Core.Errors;

public sealed partial class ValidationErrors
{
  public string Code { get; init; }
  public string Message { get; init; }
  private ValidationErrors(string code, string message)
  {
    Code = code;
    Message = message;
  }

  public static class DeletePrescriptionsCommand
  {
    private static ValidationErrors? _nullIds;

    public static ValidationErrors NullIds
      => _nullIds ??= new
      (
        $"{nameof(DeletePrescriptionsCommand)}.{nameof(NullIds)}",
        "Ids is required"
      );
  }

  public static class CreatePrescriptionCommand
  {
    private static ValidationErrors? _nullUserId;

    public static ValidationErrors NullUserId
      => _nullUserId ??= new
      (
        $"{nameof(CreatePrescriptionCommand)}.{nameof(NullUserId)}",
        "User Id is required"
      );

    private static ValidationErrors? _invalidUserId;

    public static ValidationErrors InvalidUserId
      => _invalidUserId ??= new
      (
        $"{nameof(CreatePrescriptionCommand)}.{nameof(InvalidUserId)}",
        "Invalid User Id"
      );

    private static ValidationErrors? _nullMedicineId;

    public static ValidationErrors NullMedicineId
      => _nullMedicineId ??= new
      (
        $"{nameof(CreatePrescriptionCommand)}.{nameof(NullMedicineId)}",
        "Medicine Id is required"
      );

    private static ValidationErrors? _invalidMedicineId;

    public static ValidationErrors InvalidMedicineId
      => _invalidMedicineId ??= new
      (
        $"{nameof(CreatePrescriptionCommand)}.{nameof(InvalidMedicineId)}",
        "Invalid Medicine Id"
      );
  }

  public static class PrescriptionProperties
  {
    private static ValidationErrors? _nullDosageUnit;

    public static ValidationErrors NullDosageUnit
      => _nullDosageUnit ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(NullDosageUnit)}", 
        "Dosage unit is required"
      );

    private static ValidationErrors? _nullDosageQuantity;

    public static ValidationErrors NullDosageQuantity
      => _nullDosageQuantity ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(NullDosageQuantity)}",
        "Dosage unit is required"
      );

    private static ValidationErrors? _nullForm;

    public static ValidationErrors NullForm
      => _nullForm ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(NullForm)}",
        "Form of medication is required"
      );

    private static ValidationErrors? _nullMealReference;

    public static ValidationErrors NullMealReference
      => _nullMealReference ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(NullMealReference)}",
        "Meal reference is required"
      );

    private static ValidationErrors? _nullFrequency;

    public static ValidationErrors NullFrequency
      => _nullFrequency ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(NullFrequency)}",
        "Frequency of medication is required"
      );

    private static ValidationErrors? _nullStartDate;

    public static ValidationErrors NullStartDate
      => _nullStartDate ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(NullStartDate)}",
        "Start date of medication is required"
      );

    private static ValidationErrors? _earlyStartDate;

    public static ValidationErrors EarlyStartDate
      => _earlyStartDate ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(EarlyStartDate)}",
        "Start year of medication should be greater than 2020"
      );

    private static ValidationErrors? _lateStartDate;

    public static ValidationErrors LateStartDate
      => _lateStartDate ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(LateStartDate)}",
        "Start year of medication should be less than 2030"
      );

    private static ValidationErrors? _nullDuration;

    public static ValidationErrors NullDuration
      => _nullDuration ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(NullDuration)}",
        "Duration of medication is required"
      );

    private static ValidationErrors? _invalidDuration;

    public static ValidationErrors InvalidDuration
      => _invalidDuration ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(InvalidDuration)}",
        "Duration of medication should be greater than 0"
      );

    private static ValidationErrors? _nullAmount;

    public static ValidationErrors NullAmount
      => _nullAmount ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(NullAmount)}",
        "Amount of medication is required"
      );

    private static ValidationErrors? _nullTimesOfTheDay;

    public static ValidationErrors NullTimesOfTheDay
      => _nullTimesOfTheDay ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(NullTimesOfTheDay)}",
        "Times of the day is required"
      );

    private static ValidationErrors? _emptyTimesOfTheDay;

    public static ValidationErrors EmptyTimesOfTheDay
      => _emptyTimesOfTheDay ??= new
      (
        $"{nameof(PrescriptionProperties)}.{nameof(EmptyTimesOfTheDay)}",
        "Times of the day is required"
      );
  }

  public static class ChangePrescriptionCommand
  {
    private static ValidationErrors? _nullPrescriptionId;

    public static ValidationErrors NullPrescriptionId
      => _nullPrescriptionId ??= new
      (
        $"{nameof(ChangePrescriptionCommand)}.{nameof(NullPrescriptionId)}",
        "Prescription Id is required"
      );

    private static ValidationErrors? _invalidPrescriptionId;

    public static ValidationErrors InvalidPrescriptionId
      => _invalidPrescriptionId ??= new
      (
        $"{nameof(ChangePrescriptionCommand)}.{nameof(InvalidPrescriptionId)}",
        "Invalid Prescription Id"
      );
  }

  public static class MedicineProperties
  {
    private static ValidationErrors? _nullMedicineName;

    public static ValidationErrors NullMedicineName
      => _nullMedicineName ??= new
      (
        $"{nameof(MedicineProperties)}.{nameof(NullMedicineName)}",
        "Medicine name is required"
      );

    private static ValidationErrors? _emptyMedicineName;

    public static ValidationErrors EmptyMedicineName
      => _emptyMedicineName ??= new
      (
        $"{nameof(ChangePrescriptionCommand)}.{nameof(EmptyMedicineName)}",
        "Medicine name should not be empty"
      );

    private static ValidationErrors? _nullDosagesAndForms;

    public static ValidationErrors NullDosagesAndForms
      => _nullDosagesAndForms ??= new
      (
        $"{nameof(MedicineProperties)}.{nameof(NullDosagesAndForms)}",
        "Dosages and Forms of medicine is required"
      );
  }

  public static class UpdateMedicineCommand
  {
    private static ValidationErrors? _nullMedicineId;

    public static ValidationErrors NullMedicineId
      => _nullMedicineId ??= new
      (
        $"{nameof(UpdateMedicineCommand)}.{nameof(NullMedicineId)}",
        "Medicine Id is required"
      );

    private static ValidationErrors? _invalidMedicineId;

    public static ValidationErrors InvalidPrescriptionId
      => _invalidMedicineId ??= new
      (
        $"{nameof(UpdateMedicineCommand)}.{nameof(InvalidPrescriptionId)}",
        "Invalid Medicine Id"
      );
  }

}
