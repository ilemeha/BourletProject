using BOU2.TestData;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace BOU2.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement LoginPageOpen => _driver.FindElement(By.CssSelector("h1"));
        private IWebElement LoginInput => _driver.FindElement(By.Id("username"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement ClickLogin => _driver.FindElement(By.ClassName("MuiButton-label"));
        private IWebElement CheckTitle => _driver.FindElement(By.Id("pageTitle"));

     


        public string VerifyLoginPage()
        {
            return LoginPageOpen.Text;
        }
        public void FillOutLoginData(LoginData logInfo)
        {
            LoginInput.SendKeys(logInfo.LoginName);
            PasswordInput.SendKeys(logInfo.Password);

        }
        public void ClickLoginButton()
        {
            ClickLogin.Click();
        }
        public string CheckPageTitle()
        {
            return CheckTitle.Text;
        }
    }
}


