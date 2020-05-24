using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace N_1
{
    public class Tests
    {
             private string n = "kvas";
             private string up = "45";
             private string qp = "2.0l-6bottles";
             private string uis = "500";
             private string uoor = "300";
             private string rl = "10";
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
            MainPage mp = new MainPage(drv);
            mp.Neww($"{n}",$"{up}", $"{qp}", $"{uis}", $"{uoor}", $"{rl}");             
            Assert.AreEqual("kvas",drv.FindElement(By.XPath("//input[@id='ProductName']")).GetAttribute("value"));
            Assert.AreEqual("Beverages",drv.FindElement(By.XPath("//select[@id='CategoryId']/option[@value='1']")).Text);
            Assert.AreEqual("Pavlova, Ltd.",drv.FindElement(By.XPath("//select[@id='SupplierId']/option[@value='7']")).Text);
            Assert.AreEqual("45,0000",drv.FindElement(By.XPath("//input[@id='UnitPrice']")).GetAttribute("value"));
            Assert.AreEqual("2.0l-6bottles", drv.FindElement(By.XPath("//input[@id='QuantityPerUnit']")).GetAttribute("value"));
            Assert.AreEqual("500",drv.FindElement(By.XPath("//input[@id='UnitsInStock']")).GetAttribute("value"));
            Assert.AreEqual("300",drv.FindElement(By.XPath("//input[@id='UnitsOnOrder']")).GetAttribute("value"));
            Assert.AreEqual("10",drv.FindElement(By.XPath("//input[@id='ReorderLevel']")).GetAttribute("value"));
            Assert.AreEqual("true", drv.FindElement(By.XPath("//input[@id='Discontinued']")).GetAttribute("value"));
        }
        //↓↓↓↓↓↓↓↓↓▬▬▬▬▬ Тест логаута ▬▬▬▬▬↓↓↓↓↓↓
        [Test]
        [Obsolete]
        public void Test3()
        {
            Sign.Reg(drv);
            Exxit ex = new Exxit(drv);
            ex.Goout();            
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