using System;
using System.Collections.Generic;
using System.Linq;
using DemoWebShop.Framework;
using DemoWebShop.Resources.Helpers;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace DemoWebShop.Tests
{
    public class ProductDetailsPage : BaseTestNoLogin
    {
        public BaseHelper baseHelper;

        public ProductDetailsPage()
        {
            baseHelper = new BaseHelper();
        }

        /// <summary>
        /// Verify The 'Books' Product Category Page
        /// </summary>
        [Category("ProductCategoryPage")]
        [Test]
        public void VerifyTheLaptopProductDetailsPage()
        {
            try
            {
                string productName = "14.1-inch Laptop";
                string productUrl = "141-inch-laptop";
                string pageTitle = "Demo Web Shop. 14.1-inch Laptop";

                IWebElement laptopProductElement = wd.FindElement(
                    By.XPath(String.Format("//div[@class='product-item']//a[text()='{0}']", productName)));
                ClassicAssert.IsTrue(laptopProductElement.Displayed);
                laptopProductElement.Click();

                baseHelper.SleepSeconds(2);

                string productDetailsPageTitle = wd.Title.ToString().Trim();
                ClassicAssert.AreEqual(productDetailsPageTitle, pageTitle);

                ClassicAssert.IsTrue(wd.Url.EndsWith(productUrl));

                IWebElement productNameElement = wd.FindElement(By.XPath("//div[@class='product-name']/h1"));
                ClassicAssert.AreEqual(productName, productNameElement.Text.Trim());

                IWebElement btnAddToCart = wd.FindElement(By.XPath("//div[@class='add-to-cart']//input[@type='button']"));
                ClassicAssert.IsTrue(btnAddToCart.Displayed);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'VerifyTheLaptopProductDetailsPage'. Error: {ex.Message}");
                Assert.Fail();
            }
        }
    }
}
