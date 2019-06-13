using System;
using System.Net;
using Autofac;
using RestEase;
using SFC.Tests.IntegrationTest.Mocks;
using SFC.Tests.IntegrationTest.UserApi;
using Xunit;

namespace SFC.Tests.IntegrationTest
{
  public class UserRegistrationTests 
  {
    private const string _url = "http://localhost:5000";

    [Fact]
    public async void UserCreationProcessTests()
    {
      // Setup
      Bootstrap.Run(new string[0], builder =>
      {
        builder.RegisterType<TestSmtpClient>().AsImplementedInterfaces();
      });


      PostAccountModel postAccountModel = new PostAccountModel()
      {
        LoginName = Guid.NewGuid().ToString(),
        Password = Guid.NewGuid().ToString(),
        ZipCode = "12-234",
        Email = "ala.ma.kotowska@gmail.com"
      };

      // Act
      string confirmationId = await RestClient.For<IAccountsApi>(_url).PostAccount(postAccountModel);
      await RestClient.For<IAccountsApi>(_url).PutAccountConfirmation(confirmationId, new PutConfirmationModel(true));

      // Assert
      GetAccountModel getAccountModel = await RestClient.For<IAccountsApi>(_url).Get(postAccountModel.LoginName);

      Assert.Equal(postAccountModel.Email, getAccountModel.Email);
      Assert.Equal(postAccountModel.LoginName, getAccountModel.LoginName);
    }  
  }
}