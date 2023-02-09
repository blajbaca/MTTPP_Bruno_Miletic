using System;
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
    public class MicanjeProizvodaIzKoArice
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
        public void TheMicanjeProizvodaIzKoAriceTest()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            driver.FindElement(By.Id("login2")).Click();
            driver.FindElement(By.Id("loginusername")).Click();
            driver.FindElement(By.Id("loginusername")).Clear();
            driver.FindElement(By.Id("loginusername")).SendKeys("nekiusername");
            driver.FindElement(By.Id("loginpassword")).Click();
            driver.FindElement(By.Id("loginpassword")).Clear();
            driver.FindElement(By.Id("loginpassword")).SendKeys("nekasifra");
            driver.FindElement(By.XPath("//div[@id='logInModal']/div/div/div[3]/button[2]")).Click();
            Thread.Sleep(1000);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            //wait.Until(ExpectedConditions.ElementExists(By.LinkText("Nokia lumia 1520")));
            driver.FindElement(By.LinkText("Nokia lumia 1520")).Click();
            driver.FindElement(By.LinkText("Add to cart")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Product added.", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("cartur")).Click();
            driver.FindElement(By.LinkText("Delete")).Click();
            //wait.Until(ExpectedConditions.ElementExists(By.XPath("/ html / body / nav / div / div / ul / li[1] / a"));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/ html / body / nav / div / div / ul / li[1] / a")).Click();
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
