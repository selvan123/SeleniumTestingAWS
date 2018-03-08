using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System.Net;

namespace SeleniumTest.Tests
{
    [TestClass()]
    public class FirstTestCaseTests
    {
        
      
        PhantomJSDriver driver = null;
        [TestMethod]
        public void IsParticularElementPresent()
        {
            // var driver = new PhantomJSDriver();
            //IWebDriver driver = new ChromeDriver(@"D:\Users\sels\Downloads");
            //driver.Url = "http://www.demoqa.com";

            WebClient Client = new WebClient();
            string URL = Client.DownloadString("https://s3-us-west-2.amazonaws.com/dotnetdata/elb-dns.txt");

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(300);




            driver.Navigate().GoToUrl(URL);
            string txt = driver.FindElement(By.TagName("body")).Text;

            File.WriteAllText(@"c:\ip.txt", URL+driver.Title);
            Assert.AreEqual("Home", driver.Title);
            //Assert.IsTrue(txt.Contains("offered"));
            // driver.Close();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            driver = new PhantomJSDriver();
             
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
