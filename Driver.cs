using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace Demo_UITest
{
    public class Driver
    {
        public RemoteWebDriver driver;
        protected string browser;
        protected string userEmail;
        protected string userPassword;
        protected string baseURL = "https://www.google.com";
        protected string RemoteURL = "";
        public Driver(string browser, string userEmail, string userPassword)
        {
            this.browser = browser;
            this.userEmail = userEmail;
            this.userPassword = userPassword;
        }

        [OneTimeSetUp]
        public void Initialize()
        {
            DesiredCapabilities capability = new DesiredCapabilities();

            switch (browser)
            {
                case "chrome":
                    capability.SetCapability("browserName", "chrome");
                    driver = new RemoteWebDriver(
                      new Uri(RemoteURL), capability
                    );
                    break;
                case "firefox":
                    capability.SetCapability("browserName", "firefox");
                    driver = new RemoteWebDriver(
                      new Uri(RemoteURL), capability
                    );
                    break;
                case "ie":
                    var options = new InternetExplorerOptions()
                    {
                        InitialBrowserUrl = baseURL,
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        IgnoreZoomLevel = true,
                        EnableNativeEvents = false,
                    };
                    driver = new InternetExplorerDriver(options);
                    break;
            }
            driver.Manage().Window.Maximize();

            // Login
            if (userEmail != "" && userPassword != "")
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.LinkText("Login")).Click();
                driver.FindElement(By.Name("userEmail")).Clear();
                driver.FindElement(By.Name("userEmail")).SendKeys(userEmail);
                driver.FindElement(By.Name("userPassword")).Clear();
                driver.FindElement(By.Name("userPassword")).SendKeys(userPassword);
                driver.FindElement(By.LinkText("Sign In")).Click();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                var element = wait.Until(x => x.FindElement(by));
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
