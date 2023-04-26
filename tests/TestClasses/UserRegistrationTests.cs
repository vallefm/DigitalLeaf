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

        // Filled with sleeps to better demo test functionality
        [TestMethod]
        public void RegisterNewUserTest()
        {
            // Create a user object to be used for account registration
            User user = new User("Test", "User");

            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);
            Thread.Sleep(3000);

            SignUpPage signUpPage = loginPage.ClickSignUpLink();
            Thread.Sleep(3000);
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