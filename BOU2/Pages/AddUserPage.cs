using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOU2.Pages
{
    public class AddUserPage
    {
        private IWebDriver _driver;
        public AddUserPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement ClickUserNavButton => _driver.FindElement(By.XPath("//*[@id='sideBar']/li[3]/a"));
        private IWebElement CheckPageTitle => _driver.FindElement(By.Id("pageTitle"));
        private IWebElement ClickAddUserButton => _driver.FindElement(By.ClassName("MuiButton-label"));
        private IWebElement CheckUserTitle => _driver.FindElement(By.ClassName("MuiDialogTitle-root"));

        public void ClickNavUsers()
        {
            ClickUserNavButton.Click();
        }
        public string CheckTitle()
        {
            return CheckPageTitle.Text;
        }
        public void ClickAddUser()
        {
            ClickAddUserButton.Click();
        }
        public string CheckNewUserTitle()
        {
            return CheckUserTitle.Text;
        }
    }
}
