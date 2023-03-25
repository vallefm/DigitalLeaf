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
        private static readonly By createAccountButton = By.XPath("//button[contains(text(), 'Create Account')]");
        private static readonly By emailInputBox = By.XPath("//input[@id = 'email']");
        private static readonly By firstNameInputBox = By.XPath("//input[@id = 'firstName']");
        private static readonly By lastNameInputBox = By.XPath("//input[@id = 'lastName']");
        private static readonly By paswordInputBox = By.XPath("//input[@id = 'password']");
        private static readonly By confirmPasswordInputBox = By.XPath("//input[@id = 'confirmPassword']");

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
        public void RegisterNewUser()
        {
                
        }
    }
}