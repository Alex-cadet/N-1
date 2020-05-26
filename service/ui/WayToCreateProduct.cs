using System;
using System.Collections.Generic;
using System.Text;
using N_1.buisness_objects;
using OpenQA.Selenium;

namespace N_1.service.ui
{
    public class WayToCreateProduct
    {
        public static MainPage Steps(Product drink, IWebDriver drv)
        {
            
            drv.Navigate().GoToUrl("http://localhost:5000/Product");
            MainPage mp = new MainPage(drv);
            mp.CreateNewProduct(drink.ProductName, drink.Category, drink.Supplier, drink.UnitPrice, drink.QuantityPerUnit, drink.UntInStock,
                drink.UnitOnOrder, drink.ReorderLevel);
            mp.Submit();
            mp.CheckNewProduct();
            return mp;
        }
    }
}
