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
        private static readonly By digitalLeafLogo = By.XPath("//img[@alt = 'Leaf Logo']");
        private static readonly By welcomeHeader = By.XPath("//h1[contains(text(), 'Welcome')]");
        private static readonly By logInButton = By.XPath("//button[contains(text(), 'Log In')]");

        /// <summary>
        /// Unauthenticated Home Page constructor 
        /// <summary>
        public UnauthenticatedHomePage(IWebDriver driver, string url) : base(driver)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.WaitForElement(welcomeHeader);
        }

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains the "Welcome" header
        /// </summary>
        public bool HasWelcomeHeader() => Driver.HasWebElement(welcomeHeader);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains the Login button
        /// </summary>
        public bool HasLoginButton() => Driver.HasWebElement(logInButton);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains the DigitalLeaf logo
        /// </summary>
        public bool HasDigitalLeafLogo() => Driver.HasWebElement(digitalLeafLogo);
    }
}