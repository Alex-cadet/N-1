
using System.Collections.Generic;
using System.Text;
using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace N_1
{
    class Sign
    {
        public Sign(IWebDriver drv)
        {
            this.drv = drv;
        }
        public  IWebDriver drv;
        public static IWebDriver Reg(IWebDriver drv)    
        {
            
            drv.FindElement(By.XPath("//*[@id='Name']")).SendKeys("user");
            drv.FindElement(By.XPath("//*[@id='Password']")).SendKeys("user");
            drv.FindElement(By.XPath("//input[@type='submit']")).Click();
            return drv;
        }
    }
}
