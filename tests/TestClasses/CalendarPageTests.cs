using DigitalLeaf.tests.PageObjects;
using DigitalLeaf.tests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace DigitalLeaf.tests.TestClasses
{
    /// <summary>
    /// Digital Leaf Calendar Page Quality Tests 
    /// </summary>
    [TestClass]
    public class CalendarPageTests : DigitalLeafBaseTest
    {
        static string baseUrl = "http://localhost:8080/login";

        [TestMethod]
        public void WeekdaysTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);

            SignUpPage signUpPage = loginPage.ClickSignUpLink();

            User user = new User("Test", "User");
            loginPage = signUpPage.RegisterNewUser(user);

            HomePage homePage = loginPage.LogIn(user);

            CalendarPage calendarPage = homePage.ClickMySchedule();

            /// Begin Check
            calendarPage.HasAllWeekdays().Should().BeTrue();
        }

        [TestMethod]
        public void SearchBarTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);

            SignUpPage signUpPage = loginPage.ClickSignUpLink();

            User user = new User("Test", "User");
            loginPage = signUpPage.RegisterNewUser(user);

            HomePage homePage = loginPage.LogIn(user);

            CalendarPage calendarPage = homePage.ClickMySchedule();

            /// Begin Check
            calendarPage.HasSearchBar().Should().BeTrue();  
        }
    }
}