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
    public class ProductCategoryPage : BaseTestNoLogin
    {
        public BaseHelper baseHelper;

        public ProductCategoryPage()
        {
            baseHelper = new BaseHelper();
        }

        /// <summary>
        /// Verify The 'Books' Product Category Page
        /// </summary>
        [Category("ProductCategoryPage")]
        [Test]
        public void VerifyTheBooksProductCategoryPage()
        {
            try
            {
                string productCategory = "Books";
                string pageTitle = "Demo Web Shop. Books";

                IWebElement BooksMenuElement = wd.FindElement(By.XPath("//ul[@class='top-menu']/li/a[@href='/books']"));
                ClassicAssert.IsTrue(BooksMenuElement.Displayed);
                BooksMenuElement.Click();

                baseHelper.SleepSeconds(2);

                string productCategoryPageTitle = wd.Title.ToString().Trim();
                ClassicAssert.AreEqual(productCategoryPageTitle, pageTitle);

                IWebElement booksPageTitle = wd.FindElement(By.XPath("//div[@class='page-title']/h1"));
                ClassicAssert.AreEqual(productCategory, booksPageTitle.Text.Trim());

                try
                {
                    List<IWebElement> products = wd.FindElements(By.XPath("//div[@class='product-grid']/div[@class='item-box']")).ToList();
                    ClassicAssert.IsTrue(products.Count > 0);
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Missing the products on the Books Products Category Page!");
                    Assert.Fail();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'VerifyTheBooksProductCategoryPage'. Error: {ex.Message}");
                Assert.Fail();
            }
        }
    }
}
