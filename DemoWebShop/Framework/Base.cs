using DemoWebShop.Resources.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace DemoWebShop.Framework
{
    public abstract class Base
    {
        public BrowserFactory bfactory;
        public IWebDriver wd;
        public WebDriverWait wait;
        public Random random;
        public BaseHelper baseHelper;
        protected string baseUrl;
        public string userName;
        public string userPass;

        public abstract void TestEntry();
        public abstract void TestExit();

        [OneTimeSetUp]
        public void GroupSetUp()
        {
            try
            {
                baseUrl = ConfigurationManager.AppSettings["BaseURL"];
                userName = ConfigurationManager.AppSettings["Username"];
                userPass = ConfigurationManager.AppSettings["Password"];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get the configuration values: {ex.Message}");
            }
        }

        [OneTimeTearDown]
        public void GroupTearDown()
        {
            try
            {
                if (wd != null)
                {
                    baseHelper.SleepSeconds(1);
                    wd.Dispose();
                    wd.Quit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Base group tear down failed: {ex.Message}");
            }
        }

        [OneTimeSetUp]
        public void StartTestRun()
        {

        }

        [OneTimeTearDown]
        public void EndTestRun()
        {

        }

        protected Base()
        {
            bfactory = new BrowserFactory();
            baseHelper = new BaseHelper();
        }
    }

    /// <summary>
    /// Base test for a Demo Web Shop web application, which needs to log in.
    /// </summary>
    [TestFixture]
    public class BaseTestLogin : Base
    {
        public LoginHelper loginHelper;

        public BaseTestLogin() 
        {
            loginHelper = new LoginHelper();
        }

        [SetUp]
        public override void TestEntry()
        {
            try
            {
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;

                wd = bfactory.GetBrowser(String.Empty);

                //wait = new WebDriverWait(wd, TimeSpan.FromSeconds(1));
                random = new Random();

                wd.Navigate().GoToUrl(baseUrl);
                loginHelper.NavigateToTheLoginPage(wd);
                loginHelper.LoginIntoApplication(wd, userName, userPass);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Base test failed: {ex.Message}");
            }
        }

        [TearDown]
        public override void TestExit()
        {
            try
            {
                if (wd != null)
                {
                    wd.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Base test exit failed: {ex.Message}");
            }
            finally
            {
                wd.Quit();
            }
        }
    }

    /// <summary>
    /// Base test for a Demo Web Shop web application, which does NOT need to log in.
    /// </summary>
    [TestFixture]
    public class BaseTestNoLogin : Base
    {
        public BaseTestNoLogin() { }

        [SetUp]
        public override void TestEntry()
        {
            try
            {
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;

                wd = bfactory.GetBrowser(String.Empty);

                //wait = new WebDriverWait(wd, TimeSpan.FromSeconds(1));
                random = new Random();
                wd.Navigate().GoToUrl(baseUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Base test failed: {ex.Message}");
            }
        }

        [TearDown]
        public override void TestExit()
        {
            try
            {
                wd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Base test exit failed: {ex.Message}");
            }
            finally
            {
                wd.Quit();
            }
        }
    }
}
