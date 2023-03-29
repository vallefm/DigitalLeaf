using DigitalLeaf.tests.WebDriver;
using DigitalLeaf.tests.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DigitalLeaf.tests.PageObjects
{
    /// <summary>
    /// SignUpPage and any associated methods required for testing.
    /// </summary>

    public class SignUpPage : BasePage 
    {
        private static readonly By SignUpHeader = By.XPath("//strong[contains(text(), 'Sign Up')]");
        private static readonly By createAccountButton = By.XPath("//button[contains(text(), 'Create Account')]");
        private static readonly By emailInputBox = By.XPath("//input[@id = 'email']");
        private static readonly By firstNameInputBox = By.XPath("//input[@id = 'firstName']");
        private static readonly By lastNameInputBox = By.XPath("//input[@id = 'lastName']");
        private static readonly By passwordInputBox = By.XPath("//input[@id = 'password']");
        private static readonly By confirmPasswordInputBox = By.XPath("//input[@id = 'confirmPassword']");
        private static readonly By LogInLink = By.XPath("//a[contains(text(), 'Log in')]");

        /// <summary>
        /// Sign Up Page constructor 
        /// <summary>
        public SignUpPage(IWebDriver driver) : base(driver)
        {
            Driver.WaitForElement(createAccountButton);
        }

        /// <summary>
        /// Completes Registration for a new user. 
        /// <summary>
        public LoginPage RegisterNewUser(User user)
        {
            Driver.FindElement(emailInputBox).SendKeys(user.Email);
            Driver.FindElement(firstNameInputBox).SendKeys(user.FirstName);
            Driver.FindElement(lastNameInputBox).SendKeys(user.LastName);
            Driver.FindElement(passwordInputBox).SendKeys(user.Password);
            Driver.FindElement(confirmPasswordInputBox).SendKeys(user.Password);
            Driver.FindElement(createAccountButton).Click();
            return new LoginPage(Driver);
        }

        /// <summary>
        /// Completes Registration for an invalid user. 
        /// <summary>
        public void RegisterInvalidUser(User user)
        {
            Driver.FindElement(emailInputBox).SendKeys(user.Email);
            Driver.FindElement(firstNameInputBox).SendKeys(user.FirstName);
            Driver.FindElement(lastNameInputBox).SendKeys(user.LastName);
            Driver.FindElement(passwordInputBox).SendKeys(user.Password);
            Driver.FindElement(confirmPasswordInputBox).SendKeys(user.Password);
            Driver.FindElement(createAccountButton).Click();
        }

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage validated the invalid user registration
        /// </summary>
        public bool HasSignUpHeader() => Driver.HasWebElement(SignUpHeader);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage has the email input box
        /// </summary>
        public bool HasEmailInputBox() => Driver.HasWebElement(emailInputBox);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage has the first name input box
        /// </summary>
        public bool HasFirstNameInputBox() => Driver.HasWebElement(firstNameInputBox);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage has the last name input box
        /// </summary>
        public bool HasLastNameInputBox() => Driver.HasWebElement(lastNameInputBox);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage has the password input box
        /// </summary>
        public bool HasPasswordInputBox() => Driver.HasWebElement(passwordInputBox);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage has the confirm password input box
        /// </summary>
        public bool HasConfirmPasswordInputBox() => Driver.HasWebElement(confirmPasswordInputBox);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage has the Create Account button
        /// </summary>
        public bool HasCreateAccountButton() => Driver.HasWebElement(createAccountButton);

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage has the Log In Link
        /// </summary>
        public bool HasLogInLink() => Driver.HasWebElement(LogInLink);
    }
}