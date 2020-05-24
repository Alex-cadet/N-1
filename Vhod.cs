using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace N_1
{
    public class Vhod
    {
        private IWebDriver drv;
        public Vhod(IWebDriver drv)
        {
            this.drv = drv;
        }
        IWebElement searchinputL => drv.FindElement(By.XPath("//*[@id='Name']"));
        IWebElement searchinputP => drv.FindElement(By.XPath("//*[@id='Password']"));
        IWebElement searchbtn => drv.FindElement(By.XPath("//input[@type='submit']"));
        public void LogPar(string Login,string Parol)
        {
            new Actions(drv).SendKeys(searchinputL,Login).Build().Perform();
            new Actions(drv).SendKeys(searchinputP, Parol).Build().Perform();
            new Actions(drv).Click(searchbtn).Build().Perform();
        }
    }
}
