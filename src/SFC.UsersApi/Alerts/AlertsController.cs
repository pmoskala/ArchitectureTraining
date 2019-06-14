using Microsoft.AspNetCore.Mvc;
using SFC.Alerts.Features.CreateAlert;
using SFC.Infrastructure;
using System;
using System.Threading.Tasks;

namespace SFC.UserApi.Alerts
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AlertsController : Controller
    {
        private readonly ICommandBus _commandBus;

        public AlertsController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        public async Task<IActionResult> PostAlert([FromBody]PostAlertModel alert)
        {
            var createAlertCommand = new CreateAlertCommand(alert.Id, alert.AdresLine1, alert.AdresLine2, alert.ZipCode, alert.LoginName);
            _commandBus.Send(createAlertCommand);
            return Created(new Uri($"{BaseUrl.Current}/api/v1.0/confirmations/{alert.Id}"), alert.Id);
        }

        [HttpGet("api/alerts/{alertId}")]
        async Task<IActionResult> GetAlert(string alertId, [FromQuery] string loginName)
        {
            //var alert = _alertRepository.Get(alertId, loginName);
            //return Json(alert);
            return Ok();
        }
    }
}