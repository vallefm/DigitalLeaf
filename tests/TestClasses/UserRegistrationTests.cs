using DigitalLeaf.tests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace DigitalLeaf.tests.TestClasses
{
    /// <summary>
    /// Digital Leaf Login Page Quality Tests 
    /// </summary>
    [TestClass]
    public class UserRegistrationTests : DigitalLeafBaseTest
    {
        [TestMethod]
        public void EmailInputBoxTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, "http://127.0.0.1:5500/public/views/login.html");
            loginPage.ClickSignUpLink();

            /// Begin Check
            loginPage.HasEmailInputBox().Should().BeTrue();
        }
    }
}