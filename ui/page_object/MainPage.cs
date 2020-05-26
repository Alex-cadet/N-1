using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace N_1
{
   public class MainPage
    {
        private IWebDriver drv;
        public MainPage(IWebDriver drv)
        {
            this.drv = drv;
        }
        IWebElement searchbuttonAllProducts  => drv.FindElement(By.XPath("//a[@href='/Product']"));
        IWebElement searchbuttonCreateNew => drv.FindElement(By.XPath("//a[contains(text(),'Create new')]"));
        IWebElement serachinputProductName => drv.FindElement(By.XPath("//input[@id='ProductName']"));
        IWebElement searchinputCategory => drv.FindElement(By.XPath("//select[@id='CategoryId']"));
        IWebElement searchinputCategoryValue => drv.FindElement(By.XPath("//select[@id='CategoryId']/option[@value='1']"));
        IWebElement searchinputSupplier => drv.FindElement(By.XPath("//select[@id='SupplierId']"));
        IWebElement searchinputSupplierValue => drv.FindElement(By.XPath("//select[@id='SupplierId']/option[@value='7']"));
        IWebElement searchinputUnitPrice => drv.FindElement(By.XPath("//input[@id='UnitPrice']"));
        IWebElement searchinputQuantityPerUnit => drv.FindElement(By.XPath("//input[@id='QuantityPerUnit']"));
        IWebElement searchinputUnitsInStock => drv.FindElement(By.XPath("//input[@id='UnitsInStock']"));
        IWebElement searchinputUnitsOnOrder => drv.FindElement(By.XPath("//input[@id='UnitsOnOrder']"));
        IWebElement searchinputReorderLevel => drv.FindElement(By.XPath("//input[@id='ReorderLevel']"));
        IWebElement searchbuttonSubmit => drv.FindElement(By.XPath("//input[@type='submit']"));
        IWebElement search_hrefKvas => drv.FindElement(By.XPath("//a[contains(text(),'kvas')]"));
        IWebElement searchcheckboxDiscontinued => drv.FindElement(By.XPath("//input[@id='Discontinued']"));
        public void CreateNewProduct(string productName, string category, string supplier, string unitPrice, string quantityPerUnit,
            string untInStock, string unitOnOrder, string reorderLevel)
        {
            new Actions(drv).Click(searchbuttonAllProducts).Build().Perform();
            new Actions(drv).Click(searchbuttonCreateNew).Build().Perform();
            new Actions(drv).SendKeys(serachinputProductName, productName).Build().Perform();
            var veb = searchinputCategory;
            var bev = new SelectElement(veb);
            bev.SelectByText(category);
            var ltd = searchinputSupplier;
            var pavl = new SelectElement(ltd);
            pavl.SelectByText(supplier);
            new Actions(drv).SendKeys(searchinputUnitPrice, unitPrice).Build().Perform();
            new Actions(drv).SendKeys(searchinputQuantityPerUnit, quantityPerUnit).Build().Perform();
            new Actions(drv).SendKeys(searchinputUnitsInStock, untInStock).Build().Perform();
            new Actions(drv).SendKeys(searchinputUnitsOnOrder, unitOnOrder).Build().Perform();
            new Actions(drv).SendKeys(searchinputReorderLevel, reorderLevel).Build().Perform();
        }
        public string GetProductName()
        {

            return serachinputProductName.GetAttribute("value");
        }
        

        public string GetCategory()
        {
            
            return searchinputCategoryValue.Text;
        }
        public string GetSupplier()
        {
            
            return searchinputSupplierValue.Text;
        }
        public string GetUnitPrice()
        {
            
            return searchinputUnitPrice.GetAttribute("value");
        }
        public string GetQuantityPerUnit()
        {
             
            return searchinputQuantityPerUnit.GetAttribute("value");
        }
        public string GetUnitsInStock()
        {
            
            return searchinputUnitsInStock.GetAttribute("value");
        }
        public string GetUnitsOnOrder()
        {
           
            return searchinputUnitsOnOrder.GetAttribute("value");
        }
        public string GetReorderLevel()
        {
             
            return searchinputReorderLevel.GetAttribute("value");
        }
        public string GetDiscontinued()
        {
            return searchcheckboxDiscontinued.GetAttribute("value");
        }
        public void Submit()
        {
            new Actions(drv).Click(searchbuttonSubmit).Build().Perform();
            
        }
        public void CheckNewProduct()
        {
            new Actions(drv).Click(search_hrefKvas).Build().Perform();
           
        }
    }
}
