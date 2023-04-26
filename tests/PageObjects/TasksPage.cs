using DigitalLeaf.tests.WebDriver;
using OpenQA.Selenium;

namespace DigitalLeaf.tests.PageObjects
{
    /// <summary>
    /// Tasks Page and any associated methods required for testing.
    /// </summary>

    public class TasksPage : BasePage
    {
        private static readonly By createTaskButton = By.XPath("//*[@id='tasks']/div[2]/button");
        private static readonly By taskTitleInput = By.XPath("//input[@id = 'title']");
        private static readonly By demoTask = By.XPath("//summary[contains(text(), 'Demo Task')]");
        private static readonly By createButton = By.XPath("//button[contains(text(), 'Create')]");



        /// <summary>
        /// Tasks Page constructor 
        /// <summary>
        public TasksPage(IWebDriver driver, string url) : base(driver)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.WaitForElement(createTaskButton);
        }

        /// <summary>
        /// Tasks Page constructor (no URL)
        /// <summary>
        public TasksPage(IWebDriver driver) : base(driver)
        {
            Driver.WaitForElement(createTaskButton);
        }
        
        /// <summary>
        /// Navigates to the Create Task page from the project page.
        /// <summary>
        public void createTask(String taskName)
        {
            Driver.FindElement(createTaskButton).Click();
            Thread.Sleep(1000);
            Driver.FindElement(taskTitleInput).SendKeys(taskName);
            Thread.Sleep(3000);
            Driver.FindElement(createButton).Click();
        }

        /// <summary>
        /// Returns a boolean result depending on whether or not the current webpage contains the Demo Task
        /// </summary>
        public bool HasDemoTask() => Driver.HasWebElement(demoTask);
    }
}