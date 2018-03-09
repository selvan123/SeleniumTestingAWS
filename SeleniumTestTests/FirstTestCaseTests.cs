using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System.Net;
using System.IO;

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

            File.WriteAllText(@"c:\ip.txt", "Hello");

            WebClient Client = new WebClient();
            string URL = Client.DownloadString("https://s3-us-west-2.amazonaws.com/dotnetdata/elb-dns.txt");


            File.WriteAllText(@"c:\ip1.txt", URL.ToString());

            try
            {
                driver = new PhantomJSDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(300);

                driver.Navigate().GoToUrl(URL);


                string txt = driver.FindElement(By.TagName("body")).Text;

                File.WriteAllText(@"c:\ip2.txt", driver.Title.ToString());

                Assert.AreEqual("Home", driver.Title);
            }
            catch (System.Exception ext)
            {
                File.WriteAllText(@"c:\ipexc1.txt", ext.ToString());
            }
            //Assert.IsTrue(txt.Contains("offered"));
            // driver.Close();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            try
            {
                File.WriteAllText(@"c:\ip.txt", "Before");
                driver = new PhantomJSDriver();
            }
            catch (System.Exception ex)
            {
                File.WriteAllText(@"c:\ipexc.txt", ex.ToString());
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
