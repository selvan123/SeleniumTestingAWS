using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System.Net;

namespace SeleniumTest.Tests
{
    [TestClass()]
    public class FirstTestCaseTests
    {
        //[TestMethod()]
        //public void IsParticularElementPresent()
        //{
        //    IWebDriver driver = new ChromeDriver(@"D:\Users\sels\Downloads");
        //    //driver.Url = "http://www.demoqa.com";
        //    driver.Navigate().GoToUrl("https://www.google.com");
        //    string txt = driver.FindElement(By.TagName ("body")).Text;

        //    driver.Close();

        //    Assert.IsTrue( txt.Contains("offered"));
        //}

        //[TestMethod()]
        //public void Login()
        //{
        //    IWebDriver driver = new ChromeDriver(@"D:\Users\sels\Downloads");
        //    //driver.Url = "http://www.demoqa.com";
        //    driver.Navigate().GoToUrl("http://localhost/BORCA/login.aspx");

        //    var  uname = driver.FindElement(By.Id("ctl00_cphBORCA_txtUserName"));
        //    var  pwd = driver.FindElement(By.Id("ctl00_cphBORCA_txtPassword"));
        //    var btn = driver.FindElement(By.Id("ctl00_cphBORCA_btnLogin1"));

        //    uname.SendKeys("sels");
        //    pwd.SendKeys("Dynamic6&8");
        //    btn.Click();
        //    driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);


        //    string txt = driver.FindElement(By.TagName("body")).Text;
        //    driver.Close();
        //    Assert.IsTrue(txt.Contains("Menu"));
        //}

      
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


            Assert.AreEqual("Home2", driver.Title);
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