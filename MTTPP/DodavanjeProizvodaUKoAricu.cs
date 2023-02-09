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
    public class DodavanjeProizvodaUKoAricu
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
        public void TheDodavanjeProizvodaUKoAricuTest()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
            driver.FindElement(By.Id("login2")).Click();
            driver.FindElement(By.Id("loginusername")).Click();
            driver.FindElement(By.Id("loginusername")).Clear();
            driver.FindElement(By.Id("loginusername")).SendKeys("nekiusername");
            driver.FindElement(By.XPath("//div[@id='logInModal']/div/div/div[2]/form")).Click();
            driver.FindElement(By.Id("loginpassword")).Click();
            driver.FindElement(By.Id("loginpassword")).Clear();
            driver.FindElement(By.Id("loginpassword")).SendKeys("nekasifra");
            driver.FindElement(By.XPath("//div[@id='logInModal']/div/div/div[3]/button[2]")).Click();
            Thread.Sleep(1000);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            //wait.Until(ExpectedConditions.ElementExists(By.LinkText("Samsung galaxy s6")));
            driver.FindElement(By.LinkText("Samsung galaxy s6")).Click();
            driver.FindElement(By.LinkText("Add to cart")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Product added.", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("cartur")).Click();
            driver.FindElement(By.XPath("//div[@id='page-wrapper']/div/div[2]/button")).Click();
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys("neko ime");
            driver.FindElement(By.Id("country")).Click();
            driver.FindElement(By.Id("country")).Clear();
            driver.FindElement(By.Id("country")).SendKeys("neka zemlja");
            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("neki grad");
            driver.FindElement(By.Id("card")).Click();
            driver.FindElement(By.Id("card")).Clear();
            driver.FindElement(By.Id("card")).SendKeys("brojevi");
            driver.FindElement(By.Id("month")).Click();
            driver.FindElement(By.Id("month")).Clear();
            driver.FindElement(By.Id("month")).SendKeys("neki mjesec");
            driver.FindElement(By.Id("year")).Click();
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys("neka godina");
            driver.FindElement(By.XPath("//div[@id='orderModal']/div/div/div[3]/button[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancel'])[1]/following::button[1]")).Click();
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
