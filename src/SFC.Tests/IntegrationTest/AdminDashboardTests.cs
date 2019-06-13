using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using RestEase;
using SFC.Tests.IntegrationTest.Mocks;
using SFC.Tests.IntegrationTest.UserApi;
using Xunit;

namespace SFC.Tests.IntegrationTest
{
  public class AdminDashboardTests
  {
    private const string _url = "http://localhost:5000";

    [Fact]
    public async void ShowAdminDashboard()
    {
      // Setup
      Bootstrap.Run(new string[0], builder =>
      {
        builder.RegisterType<TestSmtpClient>().AsImplementedInterfaces();
      });

      await CreateUser("ala.makotowska");

      // Act
      GetDashboardResult result2 = await RestClient.For<IAdminApi>(_url).GetDashboard(0,10);

      // Assert
      Assert.Single(result2.Results);
      Assert.Equal("ala.makotowska", result2.Results.First().LoginName);
      Assert.Equal(2, result2.Results.First().EmailsSentCount);
    }

    [Fact]
    public async void ShowAdminSearchableDashboard()
    {
      // Setup
      Bootstrap.Run(new string[0], builder =>
      {
        builder.RegisterType<TestSmtpClient>().AsImplementedInterfaces();
      });

      await CreateUser("ala.makotowska");
      await AddAlert("ala.makotowska");

      // Act
      var result2 = await RestClient.For<IAdminApi>(_url).GetSearchableDashboard(0, 10, 1);

      // Assert
      Assert.Single(result2.Results);
      Assert.Equal("ala.makotowska", result2.Results.First().LoginName);
      Assert.Equal(2, result2.Results.First().AlertsCount);
    }

    private async Task AddAlert(string loginName)
    {
      PostAlertModel postAlert = new PostAlertModel()
      {
        Id = Guid.NewGuid().ToString(),
        AdresLine1 = "ul Szkolna 12",
        AdresLine2 = "Gniezno",
        ZipCode = "12-345",
        LoginName = loginName
      };

      await RestClient.For<IAlertsApi>(_url).PostAlert(postAlert);
    }

    private async Task CreateUser(string loginName)
    {
      PostAccountModel postAccountModel = new PostAccountModel()
      {
        LoginName = loginName,
        Password = Guid.NewGuid().ToString(),
        ZipCode = "12-234",
        Email = "ala.ma.kotowska@gmail.com"
      };

      string confirmationId = await RestClient.For<IAccountsApi>(_url).PostAccount(postAccountModel);
      await RestClient.For<IAccountsApi>(_url).PutAccountConfirmation(confirmationId, new PutConfirmationModel(true));
    }
  }
}