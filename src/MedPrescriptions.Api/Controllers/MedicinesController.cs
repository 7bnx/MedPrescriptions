using MapsterMapper;
using Prescriptions.Application.Medicines.Commands;
using Prescriptions.Application.Medicines.Queries;
using Prescriptions.Contracts.Medicines;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prescriptions.Api.Controllers;

public sealed class MedicinesController
(
  IMediator mediator, 
  IMapper mapper
)
  : ApiController(mediator, mapper)
{

  [HttpGet(ApiRoutes.Medicines.GetById)]
  [ProducesResponseType(typeof(GetMedicineResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetById(Guid medicineId)
  {
    var result = await Mediator.Send(new GetMedicineByIdQuery(medicineId));
    
    return result.IsSuccess
      ? Ok(result.Value)
      : NotFound(result.Errors);
  }

  [AllowAnonymous]
  [HttpGet(ApiRoutes.Medicines.GetByName)]
  [ProducesResponseType(typeof(GetMedicineResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetByName(string medicineName)
  {
    var result = await Mediator.Send(new GetMedicineByNameQuery(medicineName));

    return result.IsSuccess
      ? Ok(result.Value)
      : NotFound(result.Errors);
  }

  [HttpPost(ApiRoutes.Medicines.Create)]
  [ProducesResponseType(typeof(CreatedMedicineResponse), StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Create([FromBody] CreateMedicineRequest request)
  {
    var result = await Mediator.Send(Mapper.Map<CreateMedicineCommand>(request));

    return result.IsSuccess
      ? Created(result.Value)
      : BadRequest(result.Errors);
  }

  [HttpPut(ApiRoutes.Medicines.Update)]
  [ProducesResponseType(typeof(UpdatedMedicineResponse), StatusCodes.Status202Accepted)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Update([FromBody] UpdateMedicineRequest request)
  {
    var result = await Mediator.Send(Mapper.Map<UpdateMedicineCommand>(request));

    return result.IsSuccess
      ? Accepted(result.Value)
      : BadRequest(result.Errors);
  }
}