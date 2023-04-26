using DigitalLeaf.tests.Entities;
using DigitalLeaf.tests.WebDriver;
using OpenQA.Selenium;

namespace DigitalLeaf.tests.PageObjects
{
    /// <summary>
    /// LoginPage and any associated methods required for testing.
    /// </summary>

    public class ProjectsPage : BasePage
    {
        private static readonly By createProjectButton = By.XPath("/html/body/main/div[2]/div[2]/button");
        private static readonly By projectNameInput = By.XPath("//input[@id = 'projectName']");
        private static readonly By projectDescriptionInput = By.XPath("//textarea[@id = 'description']");
        private static readonly By createButton = By.XPath("//button[contains(text(), 'Create')]");
        private static readonly By demoProject = By.XPath("//a[contains(text(), 'Demo')]");
        private static readonly By tasksButton = By.XPath("//a[contains(text(), 'Tasks')]");
        

        /// <summary>
        /// Projects Page constructor 
        /// <summary>
        public ProjectsPage(IWebDriver driver, string url) : base(driver)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.WaitForElement(createProjectButton);
        }

        /// <summary>
        /// Projects Page constructor (no URL)
        /// <summary>
        public ProjectsPage(IWebDriver driver) : base(driver)
        {
            Driver.WaitForElement(createProjectButton);
        }
        
        /// <summary>
        /// Clicks Create Project, fills out the fields with sample text to demo project creation.
        /// Sleeps added for demo purposes.
        /// <summary>
        public HomePage CreateProject(String projectName)
        {
            Driver.FindElement(createProjectButton).Click();
            Thread.Sleep(600);
            Driver.FindElement(projectNameInput).SendKeys(projectName);
            Thread.Sleep(600);
            Driver.FindElement(projectDescriptionInput).SendKeys("Demo Description For Project");
            Thread.Sleep(3000);
            Driver.FindElement(createButton).Click();

            return new HomePage(Driver);
        }

        /// <summary>
        /// Clicks into the Demo Project.
        /// <summary>
        public void ClickDemoProject()
        {
            Driver.FindElement(demoProject).Click();
        }

        /// <summary>
        /// Clicks into the Tasks page.
        /// <summary>
        public TasksPage ClickTasks()
        {
            Driver.FindElement(tasksButton).Click();
            return new TasksPage(Driver);
        }

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains the Demo Project
        /// </summary>
        public bool HasDemoProject() => Driver.HasWebElement(demoProject);
    }
}