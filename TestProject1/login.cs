using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class Tests
    {
        private IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginWithValidCredentials()
        {   //here we can add all test when using the specflow in the feature file with examples with valid and invalid credentials and it will be the same steps only we will change the assertion value for every ex 
            driver.Navigate().GoToUrl("https://www.demo.guru99.com/V4/");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='uid']")).SendKeys("mngr474192");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='password']")).SendKeys("Ugysupu");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='btnLogin']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//tbody / tr[2] / td / marquee")).Text.Equals("Welcome To Manager's Page of Guru99 Bank"), "The expected message was not displayed.");    
        }

        [Test]
        public void LoginWithBlank()
        {
            driver.Navigate().GoToUrl("https://www.demo.guru99.com/V4/");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='uid']")).Click();
            Thread.Sleep(100);
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='password']")).Click();
            Thread.Sleep(100);
            driver.FindElement(By.XPath("//form/table/tbody/tr[2]/td[1]")).Click();
            Thread.Sleep(100);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(By.XPath("//tbody/tr[1]/td/label")).Text.Equals("User-ID must not be blank"), "The expected message was not displayed.");
                Assert.IsTrue(driver.FindElement(By.XPath("//tbody/tr[2]/td/label")).Text.Equals("Password must not be blank"), "The expected message was not displayed.");
            });
            
        }

        [Test]
        public void TestTheResetButton()
        {
            driver.Navigate().GoToUrl("https://www.demo.guru99.com/V4/");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='uid']")).SendKeys("mngr474192");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='password']")).SendKeys("Ugysupu");
            driver.FindElement(By.XPath("//tbody/tr/td/input[@name='btnReset']")).Click();
            //we can assert here and say that the field is empty but there is no action changed in the html to assert on it so we just can see when it automaticaly run that the field cleared
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}