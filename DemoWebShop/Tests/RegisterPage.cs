using System;
using DemoWebShop.Framework;
using DemoWebShop.Resources.Helpers;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace DemoWebShop.Tests
{
    public class RegisterPage : BaseTestNoLogin
    {
        public RegisterHelper registerHelper;

        public RegisterPage()
        {
            registerHelper = new RegisterHelper();
        }

        /// <summary>
        /// TestCaseId: #0110
        /// Title: The customer can successfully register an account on the web application
        /// </summary>
        [Category("RegisterPage")]
        [Test]
        public void TheCustomerCanSuccessfullyRegisterAnAccountOnTheWebApplication()
        {
            string email = string.Concat(random.Next(0, 100000).ToString(), "test@example.com");
            string password = "Test123!";
            try
            {
                registerHelper.NavigateToTheRegisterPage(wd);
                registerHelper.RegisterAnAccount(wd,
                    Resources.AccountGender.Male,
                    random.Next(10).ToString(),
                    random.Next(12).ToString(),
                    email,
                    password
                    );

                baseHelper.SleepSeconds(1);

                IWebElement emailElement = wd.FindElement(By.CssSelector(".account"));
                ClassicAssert.IsTrue(emailElement.Displayed);
                ClassicAssert.AreEqual(emailElement.Text.Trim(), email);

                IWebElement contentTitle = wd.FindElement(By.XPath("//div[@class='page-title']/h1"));
                ClassicAssert.AreEqual(contentTitle.Text.Trim(), "Register");

                IWebElement contentMessage = wd.FindElement(By.XPath("//div[@class='page-body']/div[@class='result']"));
                ClassicAssert.AreEqual(contentMessage.Text.Trim(), "Your registration completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'TheCustomerCanSuccessfullyRegisterAnAccountOnTheWebApplication'. Error: {ex.Message}");
                Assert.Fail();
            }
        }
    }
}
