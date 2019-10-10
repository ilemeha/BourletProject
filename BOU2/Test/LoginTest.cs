using BOU2.Configuration;
using BOU2.TestData;
using BOU2.Pages;
using BOU2.WebDriver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Shouldly;

namespace BOU2.Pages
{

    [TestFixture]
    public class LoginTest
    {

        [Test]
        public void Login()
        {
            var loginInfo = new LoginData();


            using (var driver = DriverUtils.CreateWebDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Navigate().GoToUrl(Config.GetURL());

                var loginAccess = new LoginPage(driver);
                loginAccess.VerifyLoginPage().ShouldBe("Bourlet Jobs Login");
                loginAccess.FillOutLoginData(loginInfo);
                loginAccess.ClickLoginButton();
                Thread.Sleep(5000);

            }
        }
    }

}
