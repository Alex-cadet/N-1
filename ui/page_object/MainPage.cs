using System;
using System.Collections.Generic;
using System.Text;
using N_1.buisness_objects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace N_1
{
    public class MainPage
    {
        public Product drink = new Product("http://localhost:5000/", "user", "user", "kvas", "Beverages", "Pavlova, Ltd.", "45");
        private IWebDriver drv;
        public MainPage(IWebDriver drv)
        {
            this.drv = drv;
        }
        IWebElement searchbuttonAllProducts => drv.FindElement(By.XPath("//a[@href='/Product']"));
        IWebElement searchbuttonCreateNew => drv.FindElement(By.XPath("//a[contains(text(),'Create new')]"));
        IWebElement serachinputProductName => drv.FindElement(By.XPath("//input[@id='ProductName']"));
        IWebElement searchinputCategory => drv.FindElement(By.XPath("//select[@id='CategoryId']"));
        IWebElement searchinputCategoryValue => drv.FindElement(By.XPath($"//select[@id='CategoryId']/option[text()='{drink.Category}']"));
        IWebElement searchinputSupplier => drv.FindElement(By.XPath("//select[@id='SupplierId']"));
        IWebElement searchinputSupplierValue => drv.FindElement(By.XPath($"//select[@id='SupplierId']/option[text()='{drink.Supplier}']"));
        IWebElement searchinputUnitPrice => drv.FindElement(By.XPath("//input[@id='UnitPrice']"));
        IWebElement searchbuttonSubmit => drv.FindElement(By.XPath("//input[@type='submit']"));
        IWebElement search_hrefNewProduct => drv.FindElement(By.XPath($"//a[text()='{drink.ProductName}']"));
       
        public void ClickAllProduct()
        {
            new Actions(drv).Click(searchbuttonAllProducts).Build().Perform();
        }
        public void ClickCreateNew()
        {
            new Actions(drv).Click(searchbuttonCreateNew).Build().Perform();
        }
        public void ChooseProduct(string productName)
        {
            new Actions(drv).SendKeys(serachinputProductName, productName).Build().Perform();
        }
        public void SelectCategory(string category)
        {
            var searchinputC = searchinputCategory;
            var selectElementC = new SelectElement(searchinputC);
            selectElementC.SelectByText(category);
        }
        public void SelectSupplier(string supplier)
        { 
             var searchinputS = searchinputSupplier;
             var selectElementS = new SelectElement(searchinputS);
            selectElementS.SelectByText(supplier);
        }
        public void ChoosetUnitPrice(string unitPrice)
        {
            new Actions(drv).SendKeys(searchinputUnitPrice, unitPrice).Build().Perform();
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
        public void Submit()
        {
            new Actions(drv).Click(searchbuttonSubmit).Build().Perform();
            
        }
        public void CheckNewProduct()
        {
            new Actions(drv).Click(search_hrefNewProduct).Build().Perform();
           
        }
    }
}
