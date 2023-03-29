using DigitalLeaf.tests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace DigitalLeaf.tests.TestClasses
{
    /// <summary>
    /// Digital Leaf User Registration Quality Tests 
    /// </summary>
    [TestClass]
    public class UnauthenticatedHomePageTests : DigitalLeafBaseTest
    {
        static string baseUrl = "http://localhost:8080/";
        
        [TestMethod]
        public void DigitalLeafLogoTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            UnauthenticatedHomePage unauthenticatedHomePage = new UnauthenticatedHomePage(driver, baseUrl);
           
            /// Begin check
            unauthenticatedHomePage.HasDigitalLeafLogo().Should().BeTrue();
        }

        [TestMethod]
        public void LogInButtonTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            UnauthenticatedHomePage unauthenticatedHomePage = new UnauthenticatedHomePage(driver, baseUrl);
           
            /// Begin check
            unauthenticatedHomePage.HasLoginButton().Should().BeTrue();
        }

        [TestMethod]
        public void WelcomeHeaderTest()
        {
            /// Test set up 
            using var driver = GetWebDriver();
            UnauthenticatedHomePage unauthenticatedHomePage = new UnauthenticatedHomePage(driver, baseUrl);
           
            /// Begin check
            unauthenticatedHomePage.HasWelcomeHeader().Should().BeTrue();
        }
    }
}