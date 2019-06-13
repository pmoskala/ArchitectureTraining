using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SFC.Infrastructure;
using SFC.Processes.UserRegistration.Contract;

namespace SFC.UserApi.Accounts
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  public class ConfirmationsController : Controller
  {
    private readonly ICommandBus _commandBus;

    public ConfirmationsController(ICommandBus commandBus)
    {
      _commandBus = commandBus;
    }

    [HttpPut("{id}")]
    public IActionResult PutConfirmation([FromRoute]string id, ConfirmationModel model)
    {
      try
      {
        _commandBus.Send(new ConfirmUserCommand()
        {
          ConfirmationId = id,
          Confirmed = model.Confirmed
        });
      }
      catch (InvalidOperationException)
      {
        return BadRequest();
      }

      return Ok();
    }
  }
}
