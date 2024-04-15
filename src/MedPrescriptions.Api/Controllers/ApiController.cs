using FluentResults;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prescriptions.Api.Filters;

namespace Prescriptions.Api.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiController
(
  IMediator mediator,
  IMapper mapper
)
  : ControllerBase
{

  protected IMapper Mapper { get; } = mapper;
  protected IMediator Mediator { get; } = mediator;
  protected IActionResult BadRequest(Error error)
    => BadRequest(new ApiErrorResponse(new[] { error }));
  protected IActionResult Created(object value)
    => base.Created(string.Empty, value);
  protected new IActionResult Ok(object value)
    => base.Ok(value);
  protected new IActionResult Accepted(object value)
    => base.Accepted(value);
  protected new IActionResult NotFound(object value)
    => base.NotFound(value);
}
