using DigitalLeaf.tests.WebDriver;
using OpenQA.Selenium;

namespace DigitalLeaf.tests.PageObjects
{
    /// <summary>
    /// LoginPage and any associated methods required for testing.
    /// </summary>

    public class LoginPage : BasePage
    {
        private static readonly By emailInputBox = By.XPath("//input[@id = 'email']");
        private static readonly By passwordInputBox = By.XPath("//input[@id = 'password']");
        private static readonly By forgotYourPasswordLink = By.XPath("//a[contains(text(), 'Forgot your password')]");
        private static readonly By signUpLink = By.XPath("//a[contains(text(),'Sign up')]");
        private static readonly By logInButton = By.XPath("//button[contains(text(),'Log In')]");

        /// <summary>
        /// Login Page constructor 
        /// <summary>
        public LoginPage(IWebDriver driver, string url) : base(driver)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.WaitForElement(emailInputBox);
        }

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains an email input box
        /// </summary>
        public bool HasEmailInputBox() => Driver.HasWebElement(emailInputBox);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains a password input box
        /// </summary>
        public bool HasPasswordInputBox() => Driver.HasWebElement(passwordInputBox);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains a forgot your password link
        /// </summary>
        public bool HasForgotPasswordLink() => Driver.HasWebElement(forgotYourPasswordLink);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains a sign up link
        /// </summary>
        public bool HasSignUpLink() => Driver.HasWebElement(signUpLink);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains a log in button
        /// </summary>
        public bool HasLogInButton() => Driver.HasWebElement(logInButton);
    }
}