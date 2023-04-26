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
        private static readonly By ProjectsButton = By.XPath("//a[contains(text(), 'Projects')]");

        
        
        /// <summary>
        /// Home Page constructor 
        /// <summary>
        public HomePage(IWebDriver driver) : base(driver)
        {
            Driver.WaitForElement(HomeHeader);
        }

        /// <summary>
        /// Clicks into the user's My Schedule Page.
        /// <summary>
        public CalendarPage ClickMySchedule()
        {
            Driver.FindElement(MyScheduleButton).Click();
            return new CalendarPage(Driver);
        }

        /// <summary>
        /// Clicks into the user's Projects Page.
        /// <summary>
        public ProjectsPage ClickProjects()
        {
            Driver.FindElement(ProjectsButton).Click();
            return new ProjectsPage(Driver);
        }

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage is the home page for Test User
        /// </summary>
        public bool HasFirstName() => Driver.HasWebElement(FirstNameHeader);
    }
}