using OpenQA.Selenium;

namespace DigitalLeaf.tests.WebDriver
{
    /// <summary>
    /// BasePage class to contain the driver and ScreenshotTaker objects that are used by all of the pages
    /// </summary>
    public abstract class BasePage
    {
        /// <summary>
        /// The Driver object to be used across all pages
        /// </summary>
        protected IWebDriver Driver;

        /// <summary>
        /// BasePage constructor that accepts the driver object
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}