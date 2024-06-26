using AutomatedTests.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace AutomatedTests
{
    public class SiteWorkingTest : BaseTest
    {


        [Test]
        public void UnauthoziedUser_NavigateToSite()
        {

            driver.Navigate().GoToUrl(SiteNavigation.HomePage);
           
            Assert.IsTrue(driver.FindElement(By.TagName("h4")).Text == "Neautorizovan pristup");
        }


        [Test]
        public void SignInUser_CorrectCredentials()
        {

            driver.Navigate().GoToUrl(SiteNavigation.HomePage);
            driver.FindElement(By.Name("signInBtn")).Click();
            Task.Delay(1000).Wait();

            driver.FindElement(By.Name("signInEmail")).SendKeys("admin@vetap.com");
            driver.FindElement(By.Name("signInPassword")).SendKeys("1234");
            driver.FindElement(By.Name("signInBtnSubmit")).Submit();
            Task.Delay(2000).Wait();

            Assert.IsNotNull(driver.FindElement(By.Id("signOutBtn")));
        }

        [Test]
        public void SignInUser_WrongPassword_ShowErrorText()
        {

            driver.Navigate().GoToUrl(SiteNavigation.HomePage);
            driver.FindElement(By.Name("signInBtn")).Click();
            Task.Delay(1000).Wait();

            driver.FindElement(By.Name("signInEmail")).SendKeys("admin@vetap.com");
            driver.FindElement(By.Name("signInPassword")).SendKeys("12345");
            driver.FindElement(By.Name("signInBtnSubmit")).Submit();
            Task.Delay(2000).Wait();
            Assert.IsTrue(driver.FindElement(By.Name("signInWorningMessage")).Text == "Pogre�na e-mail adresa ili lozinka.");
        }


    }
}