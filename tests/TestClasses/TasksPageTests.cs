using DigitalLeaf.tests.PageObjects;
using DigitalLeaf.tests.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace DigitalLeaf.tests.TestClasses
{
    /// <summary>
    /// Digital Leaf Tasks Page Quality Tests 
    /// </summary>
    [TestClass]
    public class TasksPageTests : DigitalLeafBaseTest
    {
        static string baseUrl = "http://localhost:8080/login";

        // Filled with sleeps to better demo test functionality
        [TestMethod]
        public void CreateNewTaskTest()
        {
            // Create a user object to be used for account registration
            User user = new User("Test", "User");

            /// Test set up 
            using var driver = GetWebDriver();
            LoginPage loginPage = new LoginPage(driver, baseUrl);

            SignUpPage signUpPage = loginPage.ClickSignUpLink();
            loginPage = signUpPage.RegisterNewUser(user);

            HomePage homePage = loginPage.LogIn(user);

            ProjectsPage projectsPage = homePage.ClickProjects();
            homePage = projectsPage.CreateProject("Demo Project");

            projectsPage = homePage.ClickProjects();

            Thread.Sleep(5000);

            projectsPage.ClickDemoProject();
            
            TasksPage tasksPage = projectsPage.ClickTasks();

            tasksPage.createTask("Demo Task");

            Thread.Sleep(5000);

            /// Begin check
            tasksPage.HasDemoTask().Should().BeTrue();
        }
    }
}