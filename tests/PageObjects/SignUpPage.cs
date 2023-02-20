using DigitalLeaf.tests.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DigitalLeaf.tests.PageObjects
{
    /// <summary>
    /// SignUpPage and any associated methods required for testing.
    /// </summary>

    public class SignUpPage : BasePage 
    {
        private static readonly By someVariable = By.XPath("//*[contains(text(), 'KEYWORD')]");
        
        /// <summary>
        /// Sign Up Page constructor 
        /// <summary>
        public SignUpPage(IWebDriver driver, string url) : base(driver)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.WaitForElement(someVariable);
        }
    }
}