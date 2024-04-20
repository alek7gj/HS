using OpenQA.Selenium;

namespace DemoWebShop.Resources.Helpers
{
    public class LoginHelper
    {
        public BaseHelper baseHelper;

        public LoginHelper()
        {
            baseHelper = new BaseHelper();
        }

        /// <summary>
        /// Navigate To The Login Page
        /// </summary>
        public void NavigateToTheLoginPage(IWebDriver wd)
        {
            IWebElement loginLink = wd.FindElement(By.XPath("//a[@class='ico-login']"));
            loginLink.Click();
        }

        /// <summary>
        /// Login into the application with a valid user credential
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void LoginIntoApplication(IWebDriver wd, string username, string password)
        {
            IWebElement emailInput = wd.FindElement(By.Id("Email"));
            emailInput.SendKeys(username);

            IWebElement passwordInput = wd.FindElement(By.Id("Password"));
            passwordInput.SendKeys(password); 

            IWebElement loginButton = wd.FindElement(By.XPath("//input[@type='submit' and @class='button-1 login-button']"));
            loginButton.Click();

            baseHelper.SleepSeconds(2);
        }
    }
}
