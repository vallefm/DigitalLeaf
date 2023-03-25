using DigitalLeaf.tests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace DigitalLeaf.tests.TestClasses
{
    /// <summary>
    /// Digital Leaf Login Page Quality Tests 
    /// </summary>
    [TestClass]
    public class SignUpPageTests : DigitalLeafBaseTest
    {
        [TestMethod]
        public void EmailInputBoxTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, "http://127.0.0.1:5500/public/views/login.html");

            /// Begin Check
            loginPage.HasEmailInputBox().Should().BeTrue();
        }

        [TestMethod]
        public void PasswordInputBoxTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, "http://127.0.0.1:5500/public/views/login.html");

            /// Begin Check
            loginPage.HasPasswordInputBox().Should().BeTrue();
        }

        [TestMethod]
        public void LogInButtonTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, "http://127.0.0.1:5500/public/views/login.html");

            /// Begin Check
            loginPage.HasLogInButton().Should().BeTrue();
        }

        [TestMethod]
        public void ForgotPasswordLinkTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, "http://127.0.0.1:5500/public/views/login.html");

            /// Begin Check
            loginPage.HasForgotPasswordLink().Should().BeTrue();
        }

        [TestMethod]
        public void SignUpLinkTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, "http://127.0.0.1:5500/public/views/login.html");

            /// Begin Check
            loginPage.HasForgotPasswordLink().Should().BeTrue();
        }
    }
}