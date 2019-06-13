using Autofac;
using RestEase;
using SFC.Infrastructure;
using SFC.Tests.IntegrationTest.Mocks;
using SFC.Tests.IntegrationTest.UserApi;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;
using PostAlertModel = SFC.Tests.IntegrationTest.UserApi.PostAlertModel;

namespace SFC.Tests.IntegrationTest
{
    public class AlertsTests
    {
        private const string _url = "http://localhost:5000";

        [Fact]
        public async void Post_on_alert_resource_should_create_alert_when_not_exists()
        {
            // Setup
            Bootstrap.Run(new string[0], builder =>
            {
                builder.RegisterType<TestSmtpClient>().AsImplementedInterfaces();
            });

            // Act

            var client = RestClient.For<IAlertsApi>(_url);
            var postAlertModel = new PostAlertModel
            {
                Id = "1",
                AdresLine1 = "Goleszów",
                AdresLine2 = "Nowalijek 10",
                LoginName = "egzekutor",
                ZipCode = "43-440"
            };

            using (var response = await client.PostAlert(postAlertModel))
            {
                // Assert
                Assert.Equal(postAlertModel.Id, response.GetContent());
                Assert.Equal(HttpStatusCode.Created, response.ResponseMessage.StatusCode);
            }

        }

        [Fact]
        public async void Post_on_alert_resource_should_return_validation_exception()
        {
            // Setup
            Bootstrap.Run(new string[0], builder => { });

            PostAlertModel postAlert = new PostAlertModel()
            {
                Id = Guid.NewGuid().ToString(),
                AdresLine1 = "ul Szkolna 12",
                AdresLine2 = "Gniezno"
            };

            // Act, Assert
            ApiException exception = await Assert.ThrowsAsync<ApiException>(async () => await RestClient.For<IAlertsApi>(_url).PostAlert(postAlert));
            Assert.True(exception.StatusCode == HttpStatusCode.BadRequest);
        }
    }

    public class TestEventBus : IEventBus
    {
        public List<object> PublishedEvents = new List<object>();
        public void Publish<T>(T @event)
        {
            PublishedEvents.Add(@event);
        }
    }
}