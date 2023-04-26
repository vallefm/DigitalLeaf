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
    public class HomePageTests : DigitalLeafBaseTest
    {
        static string baseUrl = "http://localhost:8080/login";

        // Filled with sleeps to better demo test functionality
        [TestMethod]
        public void HomePageUrlTest()
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
            driver.Url.Should().BeEquivalentTo("http://localhost:8080/Test/home");
        }
    }
}