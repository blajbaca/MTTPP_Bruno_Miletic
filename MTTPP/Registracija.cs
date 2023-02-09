using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using MTTPP;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests { 

    [TestFixture]
    public class Registracija
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private string randomUserName = TextRandomizer.RandomString(10);
        private string randomPassword = TextRandomizer.RandomString(10);

    [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheRegistracijaTest()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            driver.FindElement(By.Id("signin2")).Click();
            driver.FindElement(By.Id("sign-username")).Click();
            driver.FindElement(By.Id("sign-username")).Clear();
            driver.FindElement(By.Id("sign-username")).SendKeys(randomUserName);
            driver.FindElement(By.Id("sign-password")).Click();
            driver.FindElement(By.Id("sign-password")).Clear();
            driver.FindElement(By.Id("sign-password")).SendKeys(randomPassword);
            driver.FindElement(By.XPath("//div[@id='signInModal']/div/div/div[3]/button[2]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
