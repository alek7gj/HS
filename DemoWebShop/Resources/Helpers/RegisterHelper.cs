using OpenQA.Selenium;
using System;

namespace DemoWebShop.Resources.Helpers
{
    public class RegisterHelper
    {
        public BaseHelper baseHelper;

        public RegisterHelper()
        {
            baseHelper = new BaseHelper();
        }

        /// <summary>
        /// Navigate To The Register Page
        /// </summary>
        public void NavigateToTheRegisterPage(IWebDriver wd)
        {
            IWebElement registerLink = wd.FindElement(By.CssSelector("a.ico-register"));
            registerLink.Click();
        }


        public void RegisterAnAccount(IWebDriver wd, AccountGender gender, string firstName, string lastName, string email, string password)
        {
            IWebElement genderRadioButton;
            if (gender == AccountGender.Male)
            {
                genderRadioButton = wd.FindElement(By.Id("gender-male"));
            }
            else 
            {
                genderRadioButton = wd.FindElement(By.Id("gender-female"));
            }
            genderRadioButton.Click();

            IWebElement firstNameInput = wd.FindElement(By.Id("FirstName"));
            firstNameInput.SendKeys(firstName);

            IWebElement lastNameInput = wd.FindElement(By.Id("LastName"));
            lastNameInput.SendKeys(lastName);

            IWebElement emailInput = wd.FindElement(By.Id("Email"));
            emailInput.SendKeys(email);

            IWebElement passwordInput = wd.FindElement(By.Id("Password"));
            passwordInput.SendKeys(password);

            IWebElement confirmPasswordInput = wd.FindElement(By.Id("ConfirmPassword"));
            confirmPasswordInput.SendKeys(password);

            IWebElement registerButton = wd.FindElement(By.CssSelector("input[value='Register']"));
            registerButton.Click();

            baseHelper.SleepSeconds(2);
        }
    }
}
