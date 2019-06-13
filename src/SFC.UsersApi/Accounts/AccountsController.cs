using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Net.Http.Headers;
using SFC.Accounts.Features.AccountQuery.Contract;
using SFC.Infrastructure;
using SFC.Notifications.Features.GetNotificationEmail.Contract;
using SFC.Processes.UserRegistration.Contract;

namespace SFC.UserApi.Accounts
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  public class AccountsController : Controller
  {
    private readonly ICommandBus _commandBus;
    private readonly IQuery _query;

    public AccountsController(ICommandBus commandBus, IQuery query)
    {
      _commandBus = commandBus;
      _query = query;
    }

    [HttpPost]
    public IActionResult PostAccount([FromBody]PostAccountModel model)
    {
      string id = Guid.NewGuid().ToString().Replace("-","");

      try
      {
        _commandBus.Send(new RegisterUserCommand()
        {
          Id = id,
          BaseUrl = BaseUrl.Current,
          LoginName = model.LoginName,
          ZipCode = model.ZipCode,
          Email = model.Email,
          Password = model.Password
        });
      }
      catch (LoginNameAlreadyUsedException)
      {
        var mds = new ModelStateDictionary();
        mds.AddModelError("loginName", "Already exists");
        return BadRequest(mds);
      }

      return Created(new Uri($"{BaseUrl.Current}/api/v1.0/confirmations/{id}"),id);
    }

    [HttpGet("{loginName}")]
    public ActionResult<GetAccountModel> GetAccount([FromRoute]string loginName)
    {
      AccountReadModel account = _query.Query<AccountReadModel, string>(loginName);
      GetEmailResponse response = _query.Query<GetEmailResponse, string>(account.LoginName);
      return Json(new GetAccountModel(account.LoginName, response.Email));
    }
  }
}