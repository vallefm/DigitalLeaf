using DigitalLeaf.tests.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DigitalLeaf.tests.PageObjects
{
    /// <summary>
    /// UnauthenticatedHomePage and any associated methods required for testing.
    /// </summary>

    public class UnauthenticatedHomePage : BasePage
    {
        private static readonly By someVariable = By.XPath("//*[contains(text(), 'KEYWORD')]");
        
        /// <summary>
        /// Unauthenticated Home Page constructor 
        /// <summary>
        public UnauthenticatedHomePage(IWebDriver driver, string url) : base(driver)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.WaitForElement(someVariable);
        }
    }
}