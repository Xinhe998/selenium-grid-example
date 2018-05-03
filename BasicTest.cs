using NUnit.Framework;
using OpenQA.Selenium;

namespace Demo_UITest
{
    [TestFixture("ie", "", "")]
    [TestFixture("chrome", "", "")]
    [TestFixture("firefox", "", "")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class BasicTest : Driver
    {
        public BasicTest(string browser, string userEmail, string userPassword) : base(browser, userEmail, userPassword) { }

        [Test, Order(1)]
        [Category("Demo_UITest")]
        [Category("Priority_High")]
        public void Basic()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.XPath("//*[contains(., 'Gmail')]"));
        }
    }
}