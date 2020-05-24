using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace N_1
{
    class MainPage
    {
        private IWebDriver drv;
        public MainPage(IWebDriver drv)
        {
            this.drv = drv;
        }
        IWebElement hrefPrd => drv.FindElement(By.XPath("//a[@href='/Product']"));
        IWebElement hrefCre => drv.FindElement(By.XPath("//a[contains(text(),'Create new')]"));
        IWebElement inputN => drv.FindElement(By.XPath("//input[@id='ProductName']"));
        IWebElement inputCat => drv.FindElement(By.XPath("//select[@id='CategoryId']"));
        IWebElement inputSupp => drv.FindElement(By.XPath("//select[@id='SupplierId']"));
        IWebElement inputUP => drv.FindElement(By.XPath("//input[@id='UnitPrice']"));
        IWebElement inputQP => drv.FindElement(By.XPath("//input[@id='QuantityPerUnit']"));
        IWebElement inputUIS => drv.FindElement(By.XPath("//input[@id='UnitsInStock']"));
        IWebElement inputUOOr => drv.FindElement(By.XPath("//input[@id='UnitsOnOrder']"));
        IWebElement inputRL => drv.FindElement(By.XPath("//input[@id='ReorderLevel']"));
        IWebElement inputsub => drv.FindElement(By.XPath("//input[@type='submit']"));
        IWebElement hrefKV => drv.FindElement(By.XPath("//a[contains(text(),'kvas')]"));
        public void Neww(string n, string up, string qp, string uis, string uor, string rl)
        {
            new Actions(drv).Click(hrefPrd).Build().Perform();
            new Actions(drv).Click(hrefCre).Build().Perform();
            new Actions(drv).SendKeys(inputN, n).Build().Perform();
            var veb = inputCat;
            var bev = new SelectElement(veb);
            bev.SelectByText("Beverages");
            var ltd = inputSupp;
            var pavl = new SelectElement(ltd);
            pavl.SelectByText("Pavlova, Ltd.");
            new Actions(drv).SendKeys(inputUP, up).Build().Perform();
            new Actions(drv).SendKeys(inputQP, qp).Build().Perform();
            new Actions(drv).SendKeys(inputUIS, uis).Build().Perform();
            new Actions(drv).SendKeys(inputUOOr, uor).Build().Perform();
            new Actions(drv).SendKeys(inputRL, rl).Build().Perform();
            new Actions(drv).Click(inputsub).Build().Perform();
            new Actions(drv).Click(hrefKV).Build().Perform();
            
        }
    }
}
