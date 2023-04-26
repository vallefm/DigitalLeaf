using DigitalLeaf.tests.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DigitalLeaf.tests.PageObjects
{
    /// <summary>
    /// HomePage and any associated methods required for testing.
    /// </summary>

    public class HomePage : BasePage
    {
        private static readonly By HomeHeader = By.XPath("//h3[contains(text(), 'Home')]");
        private static readonly By FirstNameHeader = By.XPath("//p[contains(text(), 'Test')]");
        private static readonly By MyScheduleButton = By.XPath("//a[contains(text(), 'My Schedule')]");
        
        
        /// <summary>
        /// Home Page constructor 
        /// <summary>
        public HomePage(IWebDriver driver) : base(driver)
        {
            Driver.WaitForElement(HomeHeader);
        }

        /// <summary>
        /// Clicks into the Users My Schedule Page.
        /// <summary>
        public CalendarPage ClickMySchedule()
        {
            Driver.FindElement(MyScheduleButton).Click();
            return new CalendarPage(Driver);
        }

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage is the home page for Test User
        /// </summary>
        public bool HasFirstName() => Driver.HasWebElement(FirstNameHeader);
    }
}