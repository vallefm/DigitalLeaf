using DigitalLeaf.tests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace DigitalLeaf.tests.TestClasses
{
    /// <summary>
    /// Digital Leaf Sign Up Page Quality Tests 
    /// </summary>
    [TestClass]
    public class SignUpPageTests : DigitalLeafBaseTest
    {
        static string baseUrl = "http://localhost:8080/login";
        
        [TestMethod]
        public void SignUpUrlTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            SignUpPage signUpPage = loginPage.ClickSignUpLink();

            /// Begin Check
            driver.Url.Should().BeEquivalentTo("http://localhost:8080/signup");
        }
        
        [TestMethod]
        public void SignUpHeaderTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            SignUpPage signUpPage = loginPage.ClickSignUpLink();

            /// Begin Check
            signUpPage.HasSignUpHeader().Should().BeTrue();
        }

        [TestMethod]
        public void EmailInputBoxTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            SignUpPage signUpPage = loginPage.ClickSignUpLink();

            /// Begin Check
            signUpPage.HasEmailInputBox().Should().BeTrue();
        }

        [TestMethod]
        public void FirstNameInputBoxTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            SignUpPage signUpPage = loginPage.ClickSignUpLink();

            /// Begin Check
            signUpPage.HasFirstNameInputBox().Should().BeTrue();
        }

        [TestMethod]
        public void LastNameInputBoxTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            SignUpPage signUpPage = loginPage.ClickSignUpLink();

            /// Begin Check
            signUpPage.HasLastNameInputBox().Should().BeTrue();
        }

        [TestMethod]
        public void PasswordInputBoxTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            SignUpPage signUpPage = loginPage.ClickSignUpLink();

            /// Begin Check
            signUpPage.HasPasswordInputBox().Should().BeTrue();
        }

        [TestMethod]
        public void ConfirmPasswordInputBoxTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            SignUpPage signUpPage = loginPage.ClickSignUpLink();

            /// Begin Check
            signUpPage.HasConfirmPasswordInputBox().Should().BeTrue();
        }

        [TestMethod]
        public void CreateAccountButtonTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            SignUpPage signUpPage = loginPage.ClickSignUpLink();

            /// Begin Check
            signUpPage.HasCreateAccountButton().Should().BeTrue();
        }

        [TestMethod]
        public void LoginButtonButtonTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            SignUpPage signUpPage = loginPage.ClickSignUpLink();

            /// Begin Check
            signUpPage.HasLogInButton().Should().BeTrue();
        }
    }
}