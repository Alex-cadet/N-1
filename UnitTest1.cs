using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace N_1
{
    public class Tests
    {
        private IWebDriver drv;
        [SetUp]
        public void Setup()
        {

            drv = new ChromeDriver();
            drv.Navigate().GoToUrl("http://localhost:5000/");
            drv.Manage().Window.Maximize();
            drv.FindElement(By.XPath("//*[@id='Name']")).SendKeys("user");
            drv.FindElement(By.XPath("//*[@id='Password']")).SendKeys("user");
            drv.FindElement(By.XPath("//input[@type='submit']")).Click();
        }
        //↓↓↓↓↓↓↓↓↓▬▬▬▬▬ Тест регистрации ▬▬▬▬▬↓↓↓↓↓↓
        [Test]
        public void Test1()
        {
           Assert.AreEqual("Logout", drv.FindElement(By.XPath("//a[contains(text(),'Logout')]")).Text);
        }
        //↓↓↓↓↓↓↓↓↓ ▬▬▬▬▬ Тест создания нового продукта: проверка полей ▬▬▬▬↓↓↓↓↓↓
        [Test]
        public void Test2()
        {
            drv.FindElement(By.XPath("//a[@href='/Product']")).Click();           
            drv.FindElement(By.XPath("//a[contains(text(),'Create new')]")).Click();
            drv.FindElement(By.XPath("//input[@id='ProductName']")).SendKeys("kvas");
            var veb = drv.FindElement(By.XPath("//select[@id='CategoryId']"));
            var bev = new SelectElement(veb);
            bev.SelectByText("Beverages");
            var ltd = drv.FindElement(By.XPath("//select[@id='SupplierId']"));
            var pavl = new SelectElement(ltd);
            pavl.SelectByText("Pavlova, Ltd.");
            drv.FindElement(By.XPath("//input[@id='UnitPrice']")).SendKeys("45");
            drv.FindElement(By.XPath("//input[@id='QuantityPerUnit']")).SendKeys("2.0l-6bottles");
            drv.FindElement(By.XPath("//input[@id='UnitsInStock']")).SendKeys("500");
            drv.FindElement(By.XPath("//input[@id='UnitsOnOrder']")).SendKeys("300");
            drv.FindElement(By.XPath("//input[@id='ReorderLevel']")).SendKeys("10");
            drv.FindElement(By.XPath("//input[@type='submit']")).Click();
            drv.FindElement(By.XPath("//a[contains(text(),'kvas')]")).Click();            
            Assert.AreEqual("kvas", drv.FindElement(By.XPath("//input[@id='ProductName']")).GetAttribute("value").ToString());            
            Assert.AreEqual("Beverages", drv.FindElement(By.XPath("//select[@id='CategoryId']/option[@value='1']")).Text);
            Assert.AreEqual("Pavlova, Ltd.", drv.FindElement(By.XPath("//select[@id='SupplierId']/option[@value='7']")).Text);
            Assert.AreEqual("45,0000", drv.FindElement(By.XPath("//input[@value='45,0000']")).GetAttribute("value").ToString());
            Assert.AreEqual("2.0l-6bottles", drv.FindElement(By.XPath("//input[@value='2.0l-6bottles']")).GetAttribute("value").ToString());
            Assert.AreEqual("500", drv.FindElement(By.XPath("//input[@value='500']")).GetAttribute("value").ToString());
            Assert.AreEqual("300", drv.FindElement(By.XPath("//input[@value='300']")).GetAttribute("value").ToString());
            Assert.AreEqual("10", drv.FindElement(By.XPath("//input[@value='10']")).GetAttribute("value").ToString());
            Assert.IsTrue(drv.FindElement(By.XPath("//input[@value='true']")).Enabled);
        }
        //↓↓↓↓↓↓↓↓↓▬▬▬▬▬ Тест логаута ▬▬▬▬▬↓↓↓↓↓↓
        [Test]
        public void Test3()
        {           
            Thread.Sleep(2000);
            drv.FindElement(By.XPath("//a[@href='/Account/Logout']")).Click();
            Assert.IsNotNull(drv.FindElement(By.XPath("//input[@id='Name']")));
            Assert.IsNotNull(drv.FindElement(By.XPath("//input[@id='Password']")));
            Assert.IsNotNull(drv.FindElement(By.XPath("//input[@type='submit']")));
        }
        [TearDown]
        public void Exit()
        {
            drv.Close();
            drv.Quit();
        }
    }
}