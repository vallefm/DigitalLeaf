using DigitalLeaf.tests.PageObjects;
using DigitalLeaf.tests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace DigitalLeaf.tests.TestClasses
{
    /// <summary>
    /// Digital Leaf User Registration Quality Tests 
    /// </summary>
    [TestClass]
    public class UserRegistrationTests : DigitalLeafBaseTest
    {
        static string baseUrl = "http://localhost:8080/login";

        [TestMethod]
        public void RegisterNewUserTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            SignUpPage signUpPage = loginPage.ClickSignUpLink();
            User user = new User("Test", "User");
            loginPage = signUpPage.RegisterNewUser(user);
            HomePage homePage = loginPage.LogIn(user);

            /// Begin check
            homePage.HasFirstName().Should().BeTrue();
        }

        [TestMethod]
        public void RegisterInvalidEmailTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            SignUpPage signUpPage = loginPage.ClickSignUpLink();
            User user = new User("Test", "User", "testuseratgmail.com");
            signUpPage.RegisterInvalidUser(user);

            /// Begin check
            signUpPage.HasSignUpHeader().Should().BeTrue();
        }
    }
}