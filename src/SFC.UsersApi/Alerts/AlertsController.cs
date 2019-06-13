using Microsoft.AspNetCore.Mvc;
using SFC.Alerts.Features.GetAlert;
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
        private readonly IAlertRepository _alertRepository;

        public AlertsController(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAlert([FromBody]PostAlertModel alert)
        {
            var alert1 = new Alert(alert.Id, alert.AdresLine1, alert.AdresLine2, alert.ZipCode, alert.LoginName);
            _alertRepository.Add(alert1);

            return Created(new Uri($"{BaseUrl.Current}/api/v1.0/confirmations/{alert1.Id}"), alert1.Id);
        }

        [HttpGet("api/alerts/{alertId}")]
        async Task<IActionResult> GetAlert(string alertId, [FromQuery] string loginName)
        {
            var alert = _alertRepository.Get(alertId, loginName);
            return Json(alert);
        }
    }
}