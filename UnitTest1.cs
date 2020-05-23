using System;
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
        }
        //↓↓↓↓↓↓↓↓↓▬▬▬▬▬ Тест регистрации ▬▬▬▬▬↓↓↓↓↓↓
        [Test]
        [System.Obsolete]
        public void Test1()
        {
            Sign.Reg(drv);
            Assert.AreEqual("Logout", drv.FindElement(By.XPath("//a[contains(text(),'Logout')]")).Text);
        }
        //↓↓↓↓↓↓↓↓↓ ▬▬▬▬▬ Тест создания нового продукта: проверка полей ▬▬▬▬↓↓↓↓↓↓
        [Test]
        public void Test2()
        {
            Sign.Reg(drv);
            drv.Navigate().GoToUrl("http://localhost:5000/Product");
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
            Assert.IsTrue(drv.FindElement(By.XPath("//input[@id='ProductName']")).Displayed);
            Assert.IsTrue(drv.FindElement(By.XPath("//select[@id='CategoryId']/option[1]")).Displayed);
            Assert.IsTrue(drv.FindElement(By.XPath("//select[@id='SupplierId']/option[7]")).Displayed);
            Assert.IsTrue(drv.FindElement(By.XPath("//input[@id='UnitPrice']")).Displayed);
            Assert.IsTrue(drv.FindElement(By.XPath("//input[@id='QuantityPerUnit']")).Displayed);
            Assert.IsTrue(drv.FindElement(By.XPath("//input[@id='UnitsInStock']")).Displayed);
            Assert.IsTrue(drv.FindElement(By.XPath("//input[@id='UnitsOnOrder']")).Displayed);
            Assert.IsTrue(drv.FindElement(By.XPath("//input[@id='ReorderLevel']")).Displayed);
            Assert.IsTrue(drv.FindElement(By.XPath("//input[@id='Discontinued']")).Enabled);
        }
        //↓↓↓↓↓↓↓↓↓▬▬▬▬▬ Тест логаута ▬▬▬▬▬↓↓↓↓↓↓
        [Test]
        [Obsolete]
        public void Test3()
        {
            Sign.Reg(drv);           
            drv.FindElement(By.XPath("//a[@href='/Account/Logout']")).Click();
            WebDriverWait wait = new WebDriverWait(drv, TimeSpan.FromSeconds(5));
            wait.Timeout = TimeSpan.FromSeconds(5);
            IWebElement el = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='Name']")));
            drv.FindElement(By.XPath("//input[@id='Name']"));
            drv.FindElement(By.XPath("//input[@id='Password']"));
            drv.FindElement(By.XPath("//input[@type='submit']"));
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