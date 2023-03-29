using DigitalLeaf.tests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace DigitalLeaf.tests.TestClasses
{
    /// <summary>
    /// Digital Leaf Log In Page Quality Tests 
    /// </summary>
    [TestClass]
    public class LoginPageTests : DigitalLeafBaseTest
    {
        static string baseUrl = "http://localhost:8080/login";

        [TestMethod]
        public void EmailInputBoxTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);

            /// Begin Check
            loginPage.HasEmailInputBox().Should().BeTrue();
        }

        [TestMethod]
        public void PasswordInputBoxTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);

            /// Begin Check
            loginPage.HasPasswordInputBox().Should().BeTrue();
        }

        [TestMethod]
        public void LogInButtonTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);

            /// Begin Check
            loginPage.HasLogInButton().Should().BeTrue();
        }

        [TestMethod]
        public void ForgotPasswordLinkTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);

            /// Begin Check
            loginPage.HasForgotPasswordLink().Should().BeTrue();
        }

        [TestMethod]
        public void SignUpLinkTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);

            /// Begin Check
            loginPage.HasForgotPasswordLink().Should().BeTrue();
        }
    }
}