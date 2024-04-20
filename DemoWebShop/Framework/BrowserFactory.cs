using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DemoWebShop.Framework
{
    public class BrowserFactory
    {
        private IWebDriver driver;

        public IWebDriver GetBrowser(string type)
        {
            //
            // test runner has to place the relevant <browser>driver.exe
            // into the programdata/Autotest folder
            // for chrome this is chromedriver.exe from http://chromedriver.storage.googleapis.com/
            // for IE this is IEDriverServer.exe from http://www.seleniumhq.org/download/
            //
            if (type.StartsWith("chrome"))
            {
                //
                // Chrome
                //
                ChromeOptions opts = new ChromeOptions();
                opts.BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
                opts.AddArgument("--disable-extensions");
                opts.AddArgument("--allow-file-access-from-files");
                opts.AddArguments("download.prompt_for_download", "false");
                opts.AddArguments("download.directory_upgrade", "true");

                driver = new ChromeDriver(opts);
            }
            else
            {
                //Firefox by default
                driver = new FirefoxDriver();
            }
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
