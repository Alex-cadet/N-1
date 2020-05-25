using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace N_1
{
   public class Exxit
    {
        private IWebDriver drv;
        public Exxit(IWebDriver drv)
        {
            this.drv = drv;
        }
        IWebElement searchHrefLogout => drv.FindElement(By.XPath("//a[@href='/Account/Logout']"));
        public string GetLogOut()
        {
            return searchHrefLogout.Text;
        }
        public void LogOut()
        {
            new Actions(drv).Click(searchHrefLogout).Build().Perform();
        }
    }
}
