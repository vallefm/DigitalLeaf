using DigitalLeaf.tests.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DigitalLeaf.tests.TestClasses
{
    [TestClass]
    public class DigitalLeafBaseTest
    {
        public string TestFilesPath;
        protected IWebDriver Driver;

        public TestContext TestContext {get; set; }
        
        public DigitalLeafBaseTest(){}
        public IWebDriver GetWebDriver()
        {
            ChromeOptions options = new();
            options.AddArgument("--start-maximized");
            
            Driver = new ChromeDriver(Environment.CurrentDirectory, options);
            TestFilesPath = Environment.CurrentDirectory + "\\TestDocs\\";
            return Driver;
        }

        /// <summary>
        /// Closes the browser using.Close and .Quit
        /// </summary>
        [TestCleanup]
        public void DigitalLeafTestCleanup()
        {
            Driver.Quit();
            Thread.Sleep(3000); //wait for any browser error to appear(ex. Plugin Container has stopped working)
        }
    }
}