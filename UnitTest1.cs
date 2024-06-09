using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
// using DotNetSeleniumExtras.WaitHelpers;
using SeleniumExtras.WaitHelpers;


namespace ADMLUCID
{
    [TestFixture]

    public class UnitTests1
    {
        IWebDriver driver;

        [SetUp]

        public void Setup()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());

            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.admlucid.com/");

            Assert.That(driver.Url, Is.EqualTo("https://www.admlucid.com/"));
            Assert.That(driver.Title, Is.EqualTo("Home Page - Admlucid"));
            //Assert.Pass();
        }
        [Test]
        public void TextBox()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            driver.FindElement(By.Id("Text1")).Clear();
            driver.FindElement(By.Id("Text1")).SendKeys("adn123456");
        }
        [Test]
        public void TextArea()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            driver.FindElement(By.Name("TextArea2")).Clear();
            driver.FindElement(By.Name("TextArea2")).SendKeys("If you mant to create robust, browser-");
        }
        [Test]
        public void Button()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            driver.FindElement(By.Id("Button1")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
        }
        [Test]
        public void RadioButtonCheckBox()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            driver.FindElement(By.Id("Checkbox1")).Click();
            driver.FindElement(By.Name("Radio2")).Click();
        }
        [Test]
        public void FileInput()
        {

            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");
            driver.FindElement(By.CssSelector("#File4")).SendKeys(@"C:\Users\Febin.Thomas\source\repos\Selenium\ADMLUCID\Text.txt");
        }

        [Test]

        public void FormSubmit()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            driver.FindElement(By.Name("Name")).SendKeys("Smith Daniel");
            driver.FindElement(By.Name("EMail")).SendKeys("Smithdeadmlucid.com");
            driver.FindElement(By.Name("Telephone")).SendKeys("788-88923436");
            driver.FindElement(By.Name("Gender")).Click();

            var selectElement = driver.FindElement(By.Name("age"));
            var select = new SelectElement(selectElement); select.SelectByText("4");

            var selectElement2 = driver.FindElement(By.Name("Service"));
            var select2 = new SelectElement(selectElement2); select2.SelectByText("Child Care");

            driver.FindElement(By.Name("Submit")).Submit();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void multiplewin()
        {
            string originalwin = driver.CurrentWindowHandle;
            driver.Navigate().GoToUrl("https://www.alberta.ca/child-care-subsidy#jumplinks-4");
            driver.FindElement(By.LinkText("online subsidy estimator")).Click();
            foreach (string window in driver.WindowHandles)
            {
                if (originalwin != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
            //driver. Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            // Assert.That(driver.FindElement(By.XPath("/html/body/form/div/div[2]/div/div[2]/h1")).Text, Is.EqualTo("Child Care Subsidy Estimator"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Assert.That(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/form/div/div[2]/div/div[2]/h1"))).Text, Is.EqualTo("Child Care Subsidy Estimator"));
        }
        [Test]
        public void WebElementText()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            Assert.That(driver.FindElement(By.XPath("/html/body/div/main/h1")).Text, Is.EqualTo("Web Elements and Locators"));
            Assert.That(driver.FindElement(By.XPath("/html/body/div/main/h2[1]")).Text, Is.EqualTo("CHILD CARE REGISTRATION"));
        }


        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
