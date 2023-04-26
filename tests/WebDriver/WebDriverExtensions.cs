using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DigitalLeaf.tests.WebDriver
{
    /// <summary>
    /// WebDriverExtensions has methods to enhance existing WebDriver functionality
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// WaitForElement will wait the specified number of seconds (default is 20) for an element to be found via the driver
        /// </summary>
        /// <param name="driver">the IWebDriver object</param>
        /// <param name="by">how to find the element</param>
        /// <param name="timeoutInSeconds">the length of time to wait</param>
        /// <returns>the WebElement if found</returns>
        /// <exception cref="NoSuchElementException">if the element is not found</exception>
        public static IWebElement WaitForElement(this IWebDriver driver, By by, int timeoutInSeconds = 60)
        {
            //Original WaitForElement:
            if (timeoutInSeconds > 0)
                return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(d => d.FindElement(by));
            return driver.FindElement(by);
        }

        /// <summary>
        /// Waits for the specified element to no longer in the html of the page
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        /// <param name="by">how to find the element</param>
        /// <param name="timeoutInSeconds">length of time to wait</param>
        public static void WaitForElementNotExist(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            new WebDriverWait(driver, new TimeSpan(0, 0, timeoutInSeconds)).Until(d => !d.HasWebElement(by, timeoutInSeconds));
        }

        public static IWebElement WaitForElementToBeClickable(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            return new WebDriverWait(driver, new TimeSpan(0, 0, timeoutInSeconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        public static IWebElement WaitForElementToNotBeClickable(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            return new WebDriverWait(driver, new TimeSpan(0, 0, timeoutInSeconds)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        /// <summary>
        /// Waits for an element to be displayed on the page. Typically used for Ajax elements
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        /// <param name="by">By locator to use</param>
        /// <param name="timeoutInSeconds">Time in seconds to wait before timeout</param>
        /// <returns>IWebElement</returns>
        public static IWebElement WaitForElementDisplayed(this IWebDriver driver, By by, int timeoutInSeconds = 60)
        {
            if (timeoutInSeconds > 0)
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, timeoutInSeconds)).Until(
                    d => d.FindElement(by).Displayed);
            }

            return driver.FindElement(by);
        }

        /// <summary>
        /// Waits for an element to no longer be displayed on the page. Typically used for Ajax elements
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        /// <param name="by">By locator to use</param>
        /// <param name="timeoutInSeconds">Time in seconds to wait before timeout</param>
        /// <returns>IWebElement</returns>
        public static void WaitForElementNotDisplayed(this IWebDriver driver, By by, int timeoutInSeconds = 60)
        {
            if (timeoutInSeconds > 0)
            {
                if (!driver.HasWebElement(by)) return;
                new WebDriverWait(driver, new TimeSpan(0, 0, timeoutInSeconds)).Until(
                    d => d.FindElement(by).Displayed == false);
            }
        }

        /// <summary>
        /// Checks to see the element is present on page
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        /// <param name="by">how to find the element</param>
        /// <param name="timeoutInSeconds">How long we want to wait for an element</param>
        /// <returns>true if element is found</returns>
        public static bool HasWebElement(this IWebDriver driver, By by, int timeoutInSeconds = 30)
        {
            try
            {
                driver.WaitForElement(by, timeoutInSeconds);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Waits until the page contains the specified search string
        /// </summary>
        /// <param name="driver">IWebDriver object to be used</param>
        /// <param name="text">String to search for</param>
        /// <param name="timeoutInSeconds">Length of time to search</param>
        public static bool HasTextOnPage(this IWebDriver driver, string text, int timeoutInSeconds = 30)
        {
            try
            {
                if (timeoutInSeconds == 0)
                {
                    return driver.PageSource.Contains(text);
                }

                new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(
                    drv => drv.PageSource.Contains(text));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Waits until the page contains the specified element with the specified search string.
        /// </summary>
        /// <param name="driver">IWebDriver object to be used</param>
        /// <param name="by">By parameter used to search for the element</param>
        /// <param name="text">String to search for</param>
        /// <param name="timeoutInSeconds">Length of time to search</param>
        public static bool HasTextInElement(this IWebDriver driver, By by, string text, int timeoutInSeconds = 30)
        {
            // wait for element to contain text
            try
            {
                if (timeoutInSeconds == 0)
                    return driver.FindElement(by).Text.Contains(text);
                new WebDriverWait(driver, new TimeSpan(0, 0, timeoutInSeconds)).Until(d => d.FindElement(by).Text.Contains(text));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Right click on an element to display the context menu
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        /// <param name="element">Element to perform the right click on</param>
        public static void RightClickElement(this IWebDriver driver, IWebElement element)
        {
            new Actions(driver).ContextClick(element).Build().Perform();
        }

        /// <summary>
        /// Right click on an element to display the context menu
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        /// <param name="by">how to find the element</param>
        public static void RightClickElement(this IWebDriver driver, By by)
        {
            new Actions(driver).ContextClick(driver.WaitForElement(by)).Build().Perform();
        }

        /// <summary>
        /// Double click an element
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        /// <param name="by">element locator</param>
        public static void DoubleClick(this IWebDriver driver, By by)
        {
            new Actions(driver).DoubleClick(driver.WaitForElement(by)).Build().Perform();
        }

        /// <summary>
        /// Clears a text field and then enters the provided value
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        /// <param name="by">text field locator</param>
        /// <param name="textValue">value to enter into the text field</param>
        public static void setTextField(this IWebDriver driver, By by, string textValue)
        {
            driver.WaitForElement(by).Clear();
            driver.WaitForElement(by).SendKeys(textValue);
        }

        /// <summary>
        /// Gets a list of the options for a given select list
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        /// <param name="by">select list locator</param>
        /// <returns>list of text values for each option of the select list</returns>
        public static List<string> getSelectListOptions(this IWebDriver driver, By by)
        {
            return new SelectElement(driver.WaitForElement(by)).Options.Select(x => x.Text.Trim()).ToList();
        }

        /// <summary>
        /// Waits for a specified amount of window handles to be available. By default, it will wait for 2 window handles.
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        /// <param name="windowHandleCount">Amount of window handles to wait for</param>
        /// <param name="timeoutInSeconds">Amount of time to wait for specified window handle count. Default time is 30 seconds.</param>
        public static void waitForWindowHandles(this IWebDriver driver, int windowHandleCount = 2, int timeoutInSeconds = 30)
        {
            int count = 0;
            while ((driver.WindowHandles.Count != windowHandleCount) && (count < timeoutInSeconds * 2))
            {
                Thread.Sleep(500); // poll for windowHandle count every 500 milliseconds (half second is the reason for *2 in the while condition)
                count++;
            }
        }

        /// <summary>
        /// Hovers over an element
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        /// <param name="by">locator for element to hover over</param>
        public static void Hover(this IWebDriver driver, By by)
        {
            new Actions(driver).MoveToElement(driver.WaitForElementDisplayed(by)).Build().Perform();
        }
        
        /// <summary>
        /// helpful method when needing to scroll to an element to be clicked, solidifies consistency.
        /// </summary>
        public static void ScrollTo(this IWebDriver driver, By by)
        {
            IWebElement element = driver.FindElement(by);
            Actions actions = new Actions(driver);
            int xPoint = element.Location.X - 500;
            int yPoint = element.Location.Y - 500;
            actions.ScrollByAmount(xPoint, yPoint)
                .Build()
                .Perform();
            Thread.Sleep(1000);
        }
        /// <summary>
        /// Waits for an alert to display
        /// </summary>
        /// <param name="driver">IWebDriver object</param>
        public static void WaitForAlertToDisplay(this IWebDriver driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(d => IsAlertShown(d));
        }

        private static bool IsAlertShown(IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// waits for element, if not found refreshs page until found
        /// </summary>
        /// <returns>the WebElement if found</returns>
        public static IWebElement WaitForElementByRefreshingPage(this IWebDriver driver, By by, int timesToRefresh = 10, int secToWaitForElement = 5)
        {
            for (int i = 1; i < timesToRefresh; i++)
            {
                try
                {
                    return driver.WaitForElement(by, secToWaitForElement);
                }
                catch (Exception e)
                {
                    driver.Navigate().Refresh();
                }
            }
            return driver.FindElement(by);
        }
    }
}