using BOU2.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;
using System.Threading;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

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
        private IWebElement FirstNameInput => _driver.FindElement(By.Id("firstName"));
        private IWebElement LastNameInput => _driver.FindElement(By.Id("lastName"));
        private IWebElement EmailNum => _driver.FindElement(By.XPath("//input[@type='Email']"));

        //private IWebElement CreatePassword => _driver.FindElement(By.XPath("//div[1]/div/div/input"));
        //private IWebElement ConfirmPassword => _driver.FindElement(By.XPath("//div[2]/div/div/input"));
        private IWebElement ZipCodeType => _driver.FindElement(By.XPath("//input[@autocomplete='new-zipcode']"));
        private IWebElement SubmitButton => _driver.FindElement(By.XPath("//button[@type='submit']"));
       



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
        public void FillOutNewUserName(Person person)
        {
            FirstNameInput.SendKeys(person.FirstName);
            LastNameInput.SendKeys(person.LastName);
            EmailNum.SendKeys(person.Email);
           
        }
        public void InputZip(string zip)
        {
            ZipCodeType.SendKeys(zip);
            SendKeys.SendWait(@"{ENTER}");
        }

        /* public void CreateNewPassword(string password, string confirmpassword)
         {
             CreatePassword.Clear();
             CreatePassword.SendKeys(password);
             CreatePassword.Clear();
             ConfirmPassword.SendKeys(confirmpassword);

         }*/

         
        public void ClickSubmitButton()
        {

            SendKeys.SendWait(@"{TAB}");
            Thread.Sleep(1000);
            SendKeys.SendWait(@"{ENTER}");
            SubmitButton.Click();
        }
    }

}
