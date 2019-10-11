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
using System.Windows.Forms;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

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
                Thread.Sleep(2000);

                var addUser = new AddUserPage(driver);
                addUser.ClickNavUsers();
                addUser.CheckTitle().ShouldBe("USERS");
                Thread.Sleep(2000);
                addUser.ClickAddUser();
                Thread.Sleep(2000);
                addUser.CheckNewUserTitle().ShouldBe("Create New User");
                Thread.Sleep(2000);
                addUser.FillOutNewUserName(person);
                Thread.Sleep(2000);
                addUser.InputZip("50755");
                // addUser.CreateNewPassword("ira88ira","ira88ira");
                /*IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");*/
                Thread.Sleep(2000);
                //addUser.ClickSubmitButton();
                /*
                var element = driver.FindElement(By.XPath("//button[@type='submit']"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(element);
                actions.Perform();
                actions.Click();
                Thread.Sleep(5000);*/
            }
        }
    }
}
