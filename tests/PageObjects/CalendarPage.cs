using DigitalLeaf.tests.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DigitalLeaf.tests.PageObjects
{
    /// <summary>
    /// HomePage and any associated methods required for testing.
    /// </summary>

    public class CalendarPage : BasePage
    {
        private static readonly By Sunday = By.XPath("//div[contains(text(), 'Sun')]");
        private static readonly By Monday = By.XPath("//div[contains(text(), 'Mon')]");
        private static readonly By Tuesday = By.XPath("//div[contains(text(), 'Tue')]");
        private static readonly By Wednesday = By.XPath("//div[contains(text(), 'Wed')]");
        private static readonly By Thursday = By.XPath("//div[contains(text(), 'Thu')]");
        private static readonly By Friday = By.XPath("//div[contains(text(), 'Fri')]");
        private static readonly By Saturday = By.XPath("//div[contains(text(), 'Sat')]");
        private static readonly By SearchBar = By.XPath("//input[@class = 'date-input']");

        
        /// <summary>
        /// Home Page constructor 
        /// <summary>
        public CalendarPage(IWebDriver driver) : base(driver)
        {
            Driver.WaitForElement(Monday);
        }

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains all weekdays (Sun, Mon, Tue, Wed, Thu, Fri, Sat)
        /// </summary>
        public bool HasAllWeekdays() => Driver.HasWebElement(Sunday) && Driver.HasWebElement(Monday) && Driver.HasWebElement(Tuesday) && Driver.HasWebElement(Wednesday) && Driver.HasWebElement(Thursday) && Driver.HasWebElement(Friday) && Driver.HasWebElement(Saturday);
        
        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains the date search bar  
        /// </summary>
        public bool HasSearchBar() => Driver.HasWebElement(SearchBar);
    }
}