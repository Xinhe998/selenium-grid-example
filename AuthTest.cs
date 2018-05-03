using NUnit.Framework;
using OpenQA.Selenium;

namespace Demo_UITest
{
    [TestFixture("chrome", "test@test.com", "123123")]
    [TestFixture("firefox", "test@test.com", "123123")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class AuthTest : Driver
    {
        public AuthTest(string browser, string userEmail, string userPassword) : base(browser, userEmail, userPassword) { }

        [Test, Order(1)]
        [Category("Demo_UITest")]
        [Category("Priority_Low")]
        public void Test_Logout()
        {
            driver.FindElement(By.XPath("//*[contains(., 'Logout')]"));
        }
    }
}
