using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests
{
    [TestFixture]
    public class KontaktPoruka
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
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
        public void TheKontaktPorukaTest()
        {
            driver.Navigate().GoToUrl("chrome://newtab/");
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            driver.FindElement(By.Id("login2")).Click();
            driver.FindElement(By.Id("loginusername")).Click();
            driver.FindElement(By.Id("loginusername")).Clear();
            driver.FindElement(By.Id("loginusername")).SendKeys("nekiusername");
            driver.FindElement(By.Id("loginpassword")).Click();
            driver.FindElement(By.Id("loginpassword")).Clear();
            driver.FindElement(By.Id("loginpassword")).SendKeys("nekasifra");
            driver.FindElement(By.XPath("//div[@id='logInModal']/div/div/div[3]/button[2]")).Click();
            Thread.Sleep(2000);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            //wait.Until(ExpectedConditions.ElementExists(By.LinkText("Contact")));
            driver.FindElement(By.LinkText("Contact")).Click();
            //wait.Until(ExpectedConditions.ElementExists(By.Id("recipient-email")));
            driver.FindElement(By.Id("recipient-email")).Click();
            driver.FindElement(By.Id("recipient-email")).Clear();
            driver.FindElement(By.Id("recipient-email")).SendKeys("nekimail@nekimail.com");
            driver.FindElement(By.Id("recipient-name")).Click();
            driver.FindElement(By.Id("recipient-name")).Clear();
            driver.FindElement(By.Id("recipient-name")).SendKeys("neko ime");
            driver.FindElement(By.Id("message-text")).Click();
            driver.FindElement(By.Id("message-text")).Clear();
            driver.FindElement(By.Id("message-text")).SendKeys("ovo je random poruka");
            driver.FindElement(By.XPath("//div[@id='exampleModal']/div/div/div[3]/button[2]")).Click();
            Assert.AreEqual("Thanks for the message!!", CloseAlertAndGetItsText());
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
