
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class addingNewCustomer
    {
        private IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void AddcustomerWithEmptyValue()
        {   
            driver.Navigate().GoToUrl("https://www.demo.guru99.com/V4/");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='uid']")).SendKeys("mngr474192");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='password']")).SendKeys("Ugysupu");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='btnLogin']")).Click();
            driver.FindElement(By.XPath("//div/ul/li/a[text()='New Customer']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='sub']")).Click();
            IAlert alert = driver.SwitchTo().Alert();   
            String alertMessage = alert.Text;
            Assert.AreEqual(alertMessage, "please fill all fields");
        }

        [Test]
        public void AddcustomerWithCorrectValue()
        {
            driver.Navigate().GoToUrl("https://www.demo.guru99.com/V4/");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='uid']")).SendKeys("mngr474192");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='password']")).SendKeys("Ugysupu");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='btnLogin']")).Click();
            driver.FindElement(By.XPath("//div/ul/li/a[text()='New Customer']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='name']")).SendKeys("dina");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@value='f']")).Click();
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='dob']")).SendKeys("5131997");
            driver.FindElement(By.XPath("//tbody/tr/td/textarea[@name='addr']")).SendKeys("cairo");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='city']")).SendKeys("cairo");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='state']")).SendKeys("cairo");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='pinno']")).SendKeys("513111");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='telephoneno']")).SendKeys("5131947397");
            Random randomGenerator = new Random();
            int randomInt = (int)randomGenerator.NextInt64(1000);
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='emailid']")).SendKeys("username"+ randomInt +"@gmail.com");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='password']")).SendKeys("Ugysupu");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='sub']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//tbody/tr/td/p")).Text.Equals("Customer Registered Successfully!!!"), "The expected message was not displayed.");

        }

        [Test]
        public void AddcustomerWithInCorrectValue()
        {
            driver.Navigate().GoToUrl("https://www.demo.guru99.com/V4/");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='uid']")).SendKeys("mngr474192");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='password']")).SendKeys("Ugysupu");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='btnLogin']")).Click();
            driver.FindElement(By.XPath("//div/ul/li/a[text()='New Customer']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='name']")).SendKeys("-");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@value='f']")).Click();
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='dob']")).SendKeys("-");
            driver.FindElement(By.XPath("//tbody/tr/td/textarea[@name='addr']")).SendKeys("-");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='city']")).SendKeys("-");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='state']")).SendKeys("-");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='pinno']")).SendKeys("-");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='telephoneno']")).SendKeys("-");           
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='emailid']")).SendKeys("-");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='password']")).SendKeys("-");
            //driver.FindElement(By.XPath("//tbody/tr/td/input[@name='sub']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//tbody/tr/td/label")).Text.Equals("Special characters are not allowed"), "The expected message was not displayed.");
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
