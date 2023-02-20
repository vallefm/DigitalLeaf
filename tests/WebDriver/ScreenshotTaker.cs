using System;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace DigitalLeaf.tests.WebDriver
{
    /// <summary>
    /// Singleton class to be use to take screenshots
    /// </summary>
    public class ScreenshotTaker
    {
        /// <summary>
        /// the private ScreenshotTaker instance to be used by the public getter
        /// </summary>
        private static ScreenshotTaker? _instance;

        /// <summary>
        /// private constructor - so we can't create an instance elsewhere
        /// </summary>
        private ScreenshotTaker() { }

        /// <summary>
        /// private reference to TestContext - needed so we can add a result file
        /// </summary>
        private TestContext TestContext { get; set; }

        /// <summary>
        /// private reference to the IWebDriver object - needed to take the screenshot
        /// </summary>
        private IWebDriver Driver { get; set; }

        /// <summary>
        /// The getter for the ScreenshotTaker instance - throws an exception if we haven't called
        /// the initialize method first
        /// </summary>
        public static ScreenshotTaker Instance
        {
            get
            {
                if (_instance == null || _instance.TestContext == null || _instance.Driver == null)
                {
                    throw new Exception(
                        "You must call ScreenShotTaker.Initalize(TestContext, Driver) before calling ScreenshotTaker.Instance");
                }
                return _instance;
            }
        }

        /// <summary>
        /// Initalize method will setup the private instance variable and then set the testcontext and driver properties
        /// </summary>
        /// <param name="testContext">TestContext object</param>
        /// <param name="driver">IWebDriver object</param>
        /// <returns>the instance of ScreenshotTaker</returns>
        public static ScreenshotTaker Initalize(TestContext testContext, IWebDriver driver)
        {
            return _instance ?? (_instance = new ScreenshotTaker { TestContext = testContext, Driver = driver });
        }


        /// <summary>
        /// Takes a screenshot using the Driver object and adds the file to the result files in the TestContext object
        /// Has a limit of 25 screenshots per testmethod 
        /// </summary>
        public void TakeScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();

            // create the jpeg filename path
            string filepath = TestContext.TestRunDirectory  + "\\Out\\"+ TestContext.TestName + ".jpg";

            // make sure we don't already have that file created - keep incrementing the file name if we do have it already
            int x = 1;
            while (File.Exists(filepath))
            {
                filepath = TestContext.TestRunDirectory + "\\Out\\" + TestContext.TestName + "_" + x + ".jpg";
                x++;

            }

            if (x > 25) // if someone doesn't know what they're doing they could put this in an infinite loop
            {
                return;
            }

            // save the file and add it to the result files - so there's a reference in the trx file
            ss.SaveAsFile(filepath, ScreenshotImageFormat.Jpeg);
            TestContext.AddResultFile(filepath);
        }

        /// <summary>
        /// Reset the instance of ScreenshotTaker
        /// </summary>
        public static void Reset()
        {
            _instance = null;
        }
    }
}
