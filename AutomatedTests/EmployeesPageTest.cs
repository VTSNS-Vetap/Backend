using AutomatedTests.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests
{
    internal class EmployeesPageTest : BaseTest
    {
        [Test]
        public void EmployeesPage_CheckIfWorking()
        {

            driver.Navigate().GoToUrl(SiteNavigation.HomePage);
            driver.FindElement(By.Name("signInBtn")).Click();
            Task.Delay(1000).Wait();

            driver.FindElement(By.Name("signInEmail")).SendKeys("admin@vetap.com");
            driver.FindElement(By.Name("signInPassword")).SendKeys("1234");
            driver.FindElement(By.Name("signInBtnSubmit")).Submit();
            Task.Delay(2000).Wait();

            driver.FindElement(By.Name("sideBarEmployees")).Click();
            Task.Delay(1000).Wait();

            Assert.IsTrue(driver.FindElement(By.TagName("h4")).Text == "Zaposleni" );
        }

        [Test]
        public void EmployeesPage_AddNewEmployee_CheckIfWorking()
        {

            driver.Navigate().GoToUrl(SiteNavigation.HomePage);
            driver.FindElement(By.Name("signInBtn")).Click();
            Task.Delay(1000).Wait();

            driver.FindElement(By.Name("signInEmail")).SendKeys("admin@vetap.com");
            driver.FindElement(By.Name("signInPassword")).SendKeys("1234");
            driver.FindElement(By.Name("signInBtnSubmit")).Submit();
            Task.Delay(2000).Wait();

            driver.FindElement(By.Name("sideBarEmployees")).Click();
            Task.Delay(500).Wait();

            driver.FindElement(By.Name("employeesAddBtn")).Click();
            Task.Delay(1000).Wait();

            driver.FindElement(By.Name("Rola")).SendKeys("admin");

            driver.FindElement(By.Name("Email")).SendKeys("test@vetap.com");
            driver.FindElement(By.Name("Ime")).SendKeys("Test");
            driver.FindElement(By.Name("Prezime")).SendKeys(".");
            driver.FindElement(By.Name("Telefon")).SendKeys("062121212");
            driver.FindElement(By.Name("JMBG")).SendKeys("1111111111111");
            driver.FindElement(By.Name("Adresa")).SendKeys("Bulevar Oslobođenja 22, Novi Sad");
            driver.FindElement(By.Name("PocetakRada")).SendKeys("1.1.2024.");

            driver.FindElement(By.Name("employeesAddBtnSubmit")).Submit();
            Task.Delay(1000).Wait();

            driver.FindElement(By.Id("signOutBtn")).Click();

            Task.Delay(1000).Wait();

            driver.FindElement(By.Name("signInEmail")).SendKeys("test@vetap.com");
            driver.FindElement(By.Name("signInPassword")).SendKeys("1234");
            driver.FindElement(By.Name("signInBtnSubmit")).Submit();
            Task.Delay(1000).Wait();

            driver.FindElement(By.Name("signInPassword")).SendKeys("12345");
            driver.FindElement(By.Name("signInPasswordConfirm")).SendKeys("12345");
            Task.Delay(1000).Wait();
            driver.FindElement(By.Name("signInBtnSubmit")).Submit();
            Task.Delay(1000).Wait();

            driver.FindElement(By.Name("signInPassword")).SendKeys("12345");
            driver.FindElement(By.Name("signInBtnSubmit")).Submit();
            Task.Delay(2000).Wait();

            driver.FindElement(By.Name("sideBarEmployees")).Click();
            Task.Delay(500).Wait();

            driver.FindElement(By.Name("employeesSearchInput")).SendKeys("test@vetap.com");
            driver.FindElement(By.Name("employeesSearchInput")).SendKeys(Keys.Enter);
            Task.Delay(500).Wait();

            driver.FindElement(By.Name("employeesRemoveBtn")).Click();
            Task.Delay(500).Wait();

            driver.FindElement(By.Name("ConfirmModal")).FindElement(By.Name("ConfirmBtn")).Click();

            Task.Delay(2000).Wait();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            driver.FindElement(By.Name("employeesSearchInput")).SendKeys(Keys.Enter);

            Assert.IsNotNull(driver.FindElement(By.Name("employeesRemoveBtn")));
        }
    }
}
