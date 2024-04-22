using AutomatedTests.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace AutomatedTests
{
    public class BaseTest
    {
        public IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver();
            driver.Navigate().GoToUrl(SiteNavigation.HomePage);
            (driver as IJavaScriptExecutor).ExecuteScript("localStorage.clear();");
        }

        [OneTimeTearDown]
        public void OnTimeTearDown()

        {
            driver.Quit();

        }

        [TearDown]
        public void TearDown()

        {

            driver.Dispose();
        }
    }
}
