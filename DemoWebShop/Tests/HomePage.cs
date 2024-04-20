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
    public class HomePageLogin : BaseTestLogin
    {
        public BaseHelper baseHelper;

        public HomePageLogin()
        {
            baseHelper = new BaseHelper();
        }

        /// <summary>
        /// TestCaseId: #0111
        /// Title: The customer can successfully log into the web application
        /// </summary>
        [Category("HomePage")]
        [Test]
        public void LoginIntoApplication()
        {
            try
            {
                IWebElement logoutLink = wd.FindElement(By.CssSelector("a.ico-logout"));
                ClassicAssert.IsTrue(logoutLink.Displayed);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'LoginIntoApplication'. Error: {ex.Message}");
                Assert.Fail();
            }
        }

        /// <summary>
        /// TestCaseId: #0112
        /// Title: The customer can successfully log off from the web application
        /// </summary>
        [Category("HomePage")]
        [Test]
        public void LogOffFromTheWebApplication()
        {
            baseHelper.SleepSeconds(1);

            try
            {
                IWebElement logoutLink = wd.FindElement(By.CssSelector("a.ico-logout"));
                ClassicAssert.IsTrue(logoutLink.Displayed);
                logoutLink.Click();

                baseHelper.SleepSeconds(2);

                IWebElement loginLink = wd.FindElement(By.CssSelector("a.ico-login"));
                ClassicAssert.IsTrue(loginLink.Displayed);

                IWebElement registerLink = wd.FindElement(By.CssSelector("a.ico-register"));
                ClassicAssert.IsTrue(registerLink.Displayed);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'LogOffFromTheWebApplication'. Error: {ex.Message}");
                Assert.Fail();
            }
        }
    }

    public class HomePageNoLogin : BaseTestNoLogin
    {
        public BaseHelper baseHelper;

        public HomePageNoLogin()
        {
            baseHelper = new BaseHelper();  
        }

        /// <summary>
        /// TestCaseId: #0101
        /// Verify that the customer can access the Demo Web Shop web application
        /// </summary>
        [Category("HomePage")]
        [Test]
        public void VerifyThatTheUserCanAccessTheDemoWebShopWebApplication()
        {
            try
            {
                string PageTitle = "Demo Web Shop";
                ClassicAssert.AreEqual(wd.Title, PageTitle);

                IWebElement logoElement = wd.FindElement(By.CssSelector(".header-logo img"));
                ClassicAssert.IsTrue(logoElement.Displayed);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'VerifyThatTheUserCanAccessTheDemoWebShopWebApplication'. Error: {ex.Message}");
                Assert.Fail();
            }
        }

        /// <summary>
        /// TestCaseId: #0102
        /// Title: Verify that the Home Page contains the following sections
        /// </summary>
        [Category("HomePage")]
        [Test]
        public void VerifyThatTheHomePageContainsTheFollowingSections()
        {
            try
            {
                IWebElement logoElement = wd.FindElement(By.CssSelector(".header-logo img"));
                ClassicAssert.IsTrue(logoElement.Displayed);

                IWebElement topRightMenuElement = wd.FindElement(By.CssSelector(".header-links"));
                ClassicAssert.IsTrue(topRightMenuElement.Displayed);

                IWebElement mainMenuElement = wd.FindElement(By.CssSelector(".header-menu"));
                ClassicAssert.IsTrue(mainMenuElement.Displayed);

                IWebElement popularTagsElement = wd.FindElement(By.CssSelector(".block-popular-tags"));
                ClassicAssert.IsTrue(popularTagsElement.Displayed);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'VerifyThatTheHomePageContainsTheFollowingSections'. Error: {ex.Message}");
                Assert.Fail();
            }
        }

        /// <summary>
        /// TestCaseId: #0103
        /// Title: Verify that the footer links are displayed in the Footer section
        /// </summary>
        [Category("HomePage")]
        [Test]
        public void VerifyThatTheFooterLinksAreDisplayedInTheFooterSection()
        {
            try
            {
                IWebElement linkSiteMap = wd.FindElement(By.XPath("//div[@class='footer']//a[text()='Sitemap']"));
                ClassicAssert.IsTrue(linkSiteMap.Displayed);

                IWebElement linkSearch = wd.FindElement(By.XPath("//div[@class='footer']//a[text()='Search']"));
                ClassicAssert.IsTrue(linkSearch.Displayed);

                IWebElement linkMyAccount = wd.FindElement(By.XPath("//div[@class='footer']//a[text()='My account']"));
                ClassicAssert.IsTrue(linkMyAccount.Displayed);

                IWebElement linkFacebook = wd.FindElement(By.XPath("//div[@class='footer']//a[text()='Facebook']"));
                ClassicAssert.IsTrue(linkFacebook.Displayed);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'VerifyThatTheFooterLinksAreDisplayedInTheFooterSection'. Error: {ex.Message}");
                Assert.Fail();
            }
        }

        /// <summary>
        /// TestCaseId: #0107
        /// Title: Search existing products
        /// </summary>
        [Category("HomePage")]
        [Test]
        public void SearchExistingProducts()
        {
            try
            {
                string productName = "Laptop";
                string pageTitle = "Demo Web Shop. Search";

                IWebElement searchInput = wd.FindElement(By.Id("small-searchterms"));
                searchInput.SendKeys(productName);

                IWebElement searchButton = wd.FindElement(By.XPath("//input[@type='submit' and @value='Search']"));
                searchButton.Click();

                baseHelper.SleepSeconds(2);    

                string searchResultsPageTitle = wd.Title.ToString().Trim();
                ClassicAssert.AreEqual(searchResultsPageTitle, pageTitle);

                List<IWebElement> products = wd.FindElements(By.XPath("//div[@class='product-grid']/div[@class='item-box']")).ToList();
                Assert.That(products.Count > 0, Is.True);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'Search existing products'. Error: {ex.Message}");
                Assert.Fail();
            }
        }

        /// <summary>
        /// TestCaseId: #0108
        /// Title: Search for non-existing products
        /// </summary>
        [Category("HomePage")]
        [Test]
        public void SearchForNonExistingProducts()
        {
            try
            {
                string productName = "blabla";
                string pageTitle = "Demo Web Shop. Search";
                string noProductsMessage = "No products were found that matched your criteria.";

                IWebElement searchInput = wd.FindElement(By.Id("small-searchterms"));
                searchInput.SendKeys(productName);

                IWebElement searchButton = wd.FindElement(By.XPath("//input[@type='submit' and @value='Search']"));
                searchButton.Click();

                baseHelper.SleepSeconds(2);

                string searchResultsPageTitle = wd.Title.ToString().Trim();
                ClassicAssert.AreEqual(searchResultsPageTitle, pageTitle);

                IWebElement message = wd.FindElement(By.XPath("//div[@class='search-results']/strong[@class='result']"));
                ClassicAssert.AreEqual(message.Text.Trim(), noProductsMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'SearchForNonExistingProducts'. Error: {ex.Message}");
                Assert.Fail();
            }
        }

        /// <summary>
        /// TestCaseId: #0109
        /// Title: The customer can filter the products by popular tag
        /// </summary>
        [Category("HomePage")]
        [Test]
        public void TheCustomerCanFilterTheProductsByPopularTag()
        {
            try
            {
                string pageTitle = "Products tagged with";
                int index = 1;

                IWebElement popularTagLink = wd.FindElement(By.XPath(String.Format("//div[@class='tags']//a[{0}]", index)));
                popularTagLink.Click();

                baseHelper.SleepSeconds(2);

                try
                {
                    ClassicAssert.IsTrue(wd.Title.Contains(pageTitle));

                    List<IWebElement> products = wd.FindElements(By.XPath("//div[@class='product-grid']/div[@class='item-box']")).ToList();
                    ClassicAssert.IsTrue(products.Count > 0);
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"There are no products for the selected popular tag!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'TheCustomerCanFilterTheProductsByPopularTag'. Error: {ex.Message}");
                Assert.Fail();
            }
        }

        /// <summary>
        /// TestCaseId: #0104
        /// Title: Verify that the customer can successfully sign up for the newsletters
        /// </summary>
        [Category("HomePage")]
        [Test]
        public void VerifyThatTheCustomerCanSuccessfullySignUpForTheNewsletters()
        {
            try
            {
                string emailAddress = string.Concat(random.Next(0, 100000).ToString(), "test@example.com");
                string confirmation = "Thank you for signing up! A verification email has been sent. We appreciate your interest.";

                IWebElement emailInput = wd.FindElement(By.Id("newsletter-email"));
                emailInput.SendKeys(emailAddress);

                IWebElement subscribeButton = wd.FindElement(By.Id("newsletter-subscribe-button"));
                subscribeButton.Click();

                baseHelper.SleepSeconds(2);

                try
                {
                    IWebElement confirmationMessage = wd.FindElement(By.Id("newsletter-result-block"));
                    ClassicAssert.AreEqual(confirmation, confirmationMessage.Text.Trim());
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Products Filtered by Popular Tag Validation Failed!");
                    Assert.Fail();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'VerifyThatTheCustomerCanSuccessfullySignUpForTheNewsletters'. Error: {ex.Message}");
                Assert.Fail();
            }
        }

        /// <summary>
        /// TestCaseId: #0105
        /// Title: Verify that only the logged customers can vote at the Community Poll
        /// </summary>
        [Category("HomePage")]
        [Test]
        public void VerifyThatOnlyTheLoggedCustomersCanVoteAtTheCommunityPoll()
        {
            try
            {
                string warningMessage = "Only registered users can vote.";
                IWebElement communityPoll = wd.FindElement(By.Id("pollanswers-1"));
                communityPoll.Click();

                IWebElement voteButton = wd.FindElement(By.Id("vote-poll-1"));
                voteButton.Click();

                baseHelper.SleepSeconds(1);

                try
                {
                    IWebElement polMessage = wd.FindElement(By.Id("block-poll-vote-error-1"));
                    ClassicAssert.IsTrue(polMessage.Displayed);
                    ClassicAssert.AreEqual(polMessage.Text.Trim(), warningMessage);
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Products Filtered by Popular Tag Validation Failed!");
                    Assert.Fail();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to validate the following test 'VerifyThatOnlyTheLoggedCustomersCanVoteAtTheCommunityPoll'. Error: {ex.Message}");
                Assert.Fail();
            }
        }
    }
}
