using BOU2.Configuration;
using BOU2.Pages;
using BOU2.TestData;
using BOU2.WebDriver;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BOU2.Test
{
    [TestFixture]
    public class AddUserTest
    {
        [Test]
        public void AddUser()
        {
            var loginInfo = new LoginData();
            var person = new Person();
            using (var driver = DriverUtils.CreateWebDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                driver.Navigate().GoToUrl(Config.GetURL());

                var loginAccess = new LoginPage(driver);
                loginAccess.VerifyLoginPage().ShouldBe("Bourlet Jobs Login");
                loginAccess.FillOutLoginData(loginInfo);
                loginAccess.ClickLoginButton();
                Thread.Sleep(5000);
                loginAccess.CheckPageTitle().ShouldBe("CUSTOMER JOBS");
                Thread.Sleep(5000);

                var addUser = new AddUserPage(driver);
                addUser.ClickNavUsers();
                addUser.CheckTitle().ShouldBe("USERS");
                Thread.Sleep(5000);
                addUser.ClickAddUser();
                Thread.Sleep(5000);
                addUser.CheckNewUserTitle().ShouldBe("Create New User");
                Thread.Sleep(5000);
            }
        }
    }
}
