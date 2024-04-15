using FluentResults;
using Prescriptions.Domain.Common;
using Prescriptions.Domain.ValueObjects;

namespace Prescriptions.Domain.Entities;

public sealed class Medicine
  : Entity
{
  public MedicineName Name { get; private set; }
  public IReadOnlyList<MedicineDosageAndForm> DosagesAndForms => _dosagesAndForms;
  public MedicineDescription Description { get; private set; }
  public MedicineIngredients Ingredients { get; private set; }

  private readonly List<MedicineDosageAndForm> _dosagesAndForms = [];

  public static Result<Medicine> Create
  (
    string name,
    IEnumerable<MedicineDosageAndForm> dosagesAndForms,
    string? description,
    string? ingredients
  )
  {
    var propertiesResult = Properties.Create
    (
      name,
      description,
      ingredients,
      dosagesAndForms
    );

    if (propertiesResult.IsFailed)
      return Result.Fail(propertiesResult.Errors);

    return Result.Ok<Medicine>(new
    (
      name: propertiesResult.Value.Name,
      description: propertiesResult.Value.Description,
      ingredients: propertiesResult.Value.Ingredients,
      dosagesAndForms: dosagesAndForms
    ));
  }

  public Result UpdateProperties
  (
    string name,
    string? description,
    string? ingredients,
    IEnumerable<MedicineDosageAndForm> dosagesAndForms
  )
  {
    var propertiesResult = Properties.Create
    (
      name,
      description,
      ingredients,
      dosagesAndForms
    );

    if (propertiesResult.IsFailed)
      return Result.Fail(propertiesResult.Errors);

    Name = propertiesResult.Value.Name;
    Description = propertiesResult.Value.Description;
    Ingredients = propertiesResult.Value.Ingredients;
    _dosagesAndForms.Clear();
    _dosagesAndForms.AddRange(dosagesAndForms);

    return Result.Ok();
  }

  private Medicine
  (
    MedicineName name,
    MedicineDescription description,
    MedicineIngredients ingredients,
    IEnumerable<MedicineDosageAndForm> dosagesAndForms
  )
  {
    Id = Guid.NewGuid();
    Name = name;
    Description = description;
    Ingredients = ingredients;
    _dosagesAndForms = dosagesAndForms.ToList();
  }

  record Properties
  (
    MedicineName Name,
    MedicineDescription Description,
    MedicineIngredients Ingredients,
    IReadOnlyList<MedicineDosageAndForm> DosagesAndForms)
  {
    public static Result<Properties> Create
    (
      string name,
      string? description,
      string? ingredients,
      IEnumerable<MedicineDosageAndForm> dosagesAndForms
    )
    {
      var resultName = MedicineName.Create(name);
      var resultDescription = MedicineDescription.Create(description!);
      var resultIngredients = MedicineIngredients.Create(ingredients!);

      if (resultName.IsFailed || resultDescription.IsFailed || resultIngredients.IsFailed)
        return Result.Merge(resultName, resultDescription, resultIngredients);

      return Result.Ok(new Properties
      (
        resultName.Value,
        resultDescription.Value,
        resultIngredients.Value,
        dosagesAndForms.ToList()
      ));
    }
  }

#pragma warning disable CS8618
  private Medicine() { }
#pragma warning restore CS8618
}
