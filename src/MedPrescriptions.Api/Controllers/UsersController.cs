using MapsterMapper;
using Prescriptions.Application.Users.Commands;
using Prescriptions.Application.Users.Queries;
using Prescriptions.Contracts.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Prescriptions.Api.Controllers;

public sealed class UsersController
(
  IMediator mediator,
  IMapper mapper
)
  : ApiController(mediator, mapper)
{

  [HttpGet(ApiRoutes.Users.GetById)]
  [ProducesResponseType(typeof(CreatedUserResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetById(Guid userId)
  {
    var result = await Mediator.Send(new GetUserByIdQuery(userId));
    return result.IsSuccess
      ? Ok(result.Value)
      : NotFound(result.Errors);
  }

  [HttpGet(ApiRoutes.Users.GetByName)]
  [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetByLogin(string userLogin)
  {
    var result = await Mediator.Send(new GetUserByLoginQuery(userLogin));
    
    return result.IsSuccess
      ? Ok(result.Value)
      : NotFound(result.Errors);
  }

  [HttpPost(ApiRoutes.Users.Create)]
  [ProducesResponseType(typeof(CreatedUserResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
  {
    var result = await Mediator.Send(Mapper.Map<CreateUserCommand>(request));

    return result.IsSuccess
      ? Created(result.Value)
      : BadRequest(result.Errors);
  }
}
