using MapsterMapper;
using Prescriptions.Application.Prescriptions.Commands;
using Prescriptions.Application.Prescriptions.Queries;
using Prescriptions.Contracts.Prescriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Prescriptions.Api.Controllers;

public sealed class PrescriptionsController
(
  IMediator mediator, 
  IMapper mapper
)
  : ApiController(mediator, mapper)
{

  [HttpGet(ApiRoutes.Prescriptions.GetById)]
  [ProducesResponseType(typeof(GetPrescriptionRequest), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetById(Guid prescriptionId)
  {
    var result = await Mediator.Send(new GetPrescriptionQuery(prescriptionId));

    return result.IsSuccess
      ? Ok(result.Value)
      : NotFound(result.Errors);
  }

  [HttpGet(ApiRoutes.Prescriptions.GetByUserId)]
  [ProducesResponseType(typeof(IReadOnlyList<GetPrescriptionResponse>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetByUserId(Guid userId)
  {
    var result = await Mediator.Send(new GetUsersPrescriptionsByIdQuery(userId));
    
    return result.IsSuccess
      ? Ok(result.Value)
      : NotFound(result.Errors);
  }

  [HttpGet(ApiRoutes.Prescriptions.GetByUserLogin)]
  [ProducesResponseType(typeof(IReadOnlyList<GetPrescriptionResponse>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetByUserLogin(string userLogin)
  {
    var result = await Mediator.Send(new GetUsersPrescriptionsByLoginQuery(userLogin));

    return result.IsSuccess
      ? Ok(result.Value)
      : NotFound(result.Errors);
  }

  [HttpPost(ApiRoutes.Prescriptions.Create)]
  [ProducesResponseType(typeof(CreatedPrescriptionResponse), StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Create([FromBody]CreatePrescriptionRequest request)
  {
    var result = await Mediator.Send(Mapper.Map<CreatePrescriptionCommand>(request));

    return result.IsSuccess
      ? Created(result.Value)
      : BadRequest(result.Errors);
  }

  [HttpPut(ApiRoutes.Prescriptions.Update)]
  [ProducesResponseType(typeof(ChangedPrescriptionPropertiesResponse), StatusCodes.Status202Accepted)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Update([FromBody] ChangePrescriptionPropertiesRequest request)
  {
    var result = await Mediator.Send(Mapper.Map<ChangePrescriptionPropertiesCommand>(request));

    return result.IsSuccess
      ? Accepted(result.Value)
      : BadRequest(result.Errors);
  }

  [HttpDelete(ApiRoutes.Prescriptions.Delete)]
  [ProducesResponseType(typeof(ChangedPrescriptionPropertiesResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Delete(IEnumerable<Guid> request)
  {
    var result = await Mediator.Send(Mapper.Map<DeletePrescriptionsCommand>(request));

    return result.IsSuccess
      ? Ok(result.Value)
      : BadRequest(result.Errors);
  }
}
