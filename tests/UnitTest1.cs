using System;
using N_1.buisness_objects;
using N_1.service.ui;
using N_1.tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace N_1
{
    public class Tests: CommonTest
    {
             private const string logOut = "Logout";
             public static string Login = "user";
             public  string Password = "user";
             public Product drink = new Product("kvas", "Beverages", "Pavlova, Ltd.", "45", "2.0l-6bottles", "500", "300", "10", "true");
        
        
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
            MainPage mp = WayToCreateProduct.Steps(drink, drv);
            Assert.AreEqual(drink.ProductName, mp.GetProductName());
            Assert.AreEqual(drink.Category, mp.GetCategory());
            Assert.AreEqual(drink.Supplier, mp.GetSupplier());
            Assert.AreEqual(drink.UnitPrice+",0000", mp.GetUnitPrice());
            Assert.AreEqual(drink.QuantityPerUnit, mp.GetQuantityPerUnit());
            Assert.AreEqual(drink.UntInStock, mp.GetUnitsInStock());
            Assert.AreEqual(drink.UnitOnOrder, mp.GetUnitsOnOrder());
            Assert.AreEqual(drink.ReorderLevel, mp.GetReorderLevel());
            Assert.AreEqual(drink.Discontinued, mp.GetDiscontinued());

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
        
    }
}