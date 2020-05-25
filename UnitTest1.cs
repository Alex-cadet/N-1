using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace N_1
{
    public class Tests
    {
             private const string logOut = "Logout";
             private const string Login = "user";
             private const string Password = "user";
             private string productName = "kvas";
             private const string category = "Beverages";
             private const string supplier = "Pavlova, Ltd.";
             private string unitPrice = "45";
             private string unitPriceValue = "45,0000";
             private string quantityPerUnit = "2.0l-6bottles";
             private string untInStock = "500";
             private string unitOnOrder = "300";
             private string reorderLevel = "10";
             private string discontinued = "true";
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
            LogIn vh = new LogIn(drv);
            vh.SignIn($"{Login}", $"{Password}");
            Exxit xe = new Exxit(drv);
            Assert.AreEqual(logOut, xe.GetLogOut());
        }
        //↓↓↓↓↓↓↓↓↓ ▬▬▬▬▬ Тест создания нового продукта: проверка полей ▬▬▬▬↓↓↓↓↓↓
        [Test]
        public void Test2()
        {
            LogIn vh = new LogIn(drv);
            vh.SignIn($"{Login}", $"{Password}");
            drv.Navigate().GoToUrl("http://localhost:5000/Product");
            MainPage mp = new MainPage(drv);
            mp.CreateNewProduct(productName, unitPrice, quantityPerUnit, untInStock, unitOnOrder, reorderLevel);
            mp.Submit();
            mp.CheckNewProduct();
            Assert.AreEqual(productName, mp.GetProductName());
            Assert.AreEqual(category, mp.GetCategory());
            Assert.AreEqual(supplier, mp.GetSupplier());
            Assert.AreEqual(unitPriceValue, mp.GetUnitPrice());
            Assert.AreEqual(quantityPerUnit, mp.GetQuantityPerUnit());
            Assert.AreEqual(untInStock, mp.GetUnitsInStock());
            Assert.AreEqual(unitOnOrder, mp.GetUnitsOnOrder());
            Assert.AreEqual(reorderLevel, mp.GetReorderLevel());
            Assert.AreEqual(discontinued, mp.GetDiscontinued());

        }
        //↓↓↓↓↓↓↓↓↓▬▬▬▬▬ Тест логаута ▬▬▬▬▬↓↓↓↓↓↓
        [Test]
        [Obsolete]
        public void Test3()
        {
            LogIn vh = new LogIn(drv);
            vh.SignIn($"{Login}", $"{Password}");
            Exxit ex = new Exxit(drv);
            ex.LogOut();            
            Assert.IsNotNull(vh.GetName());
            Assert.IsNotNull(vh.GetName());
            Assert.IsNotNull(vh.GetbuttonSubmit());
        }
        [TearDown]
        public void Exit()
        {
            drv.Close();
            drv.Quit();
        }
    }
}