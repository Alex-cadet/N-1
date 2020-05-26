using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace N_1
{
    public class LogIn
    {
        private IWebDriver drv;
        public LogIn(IWebDriver drv)
        {
            this.drv = drv;
        }
        IWebElement searchinputLogin => drv.FindElement(By.XPath("//*[@id='Name']"));
        IWebElement searchinputPassword => drv.FindElement(By.XPath("//*[@id='Password']"));
        IWebElement searchbuttonSubmit => drv.FindElement(By.XPath("//input[@type='submit']"));
        public void SignIn(string login,string parol)
        {
            new Actions(drv).SendKeys(searchinputLogin, login).Build().Perform();
            new Actions(drv).SendKeys(searchinputPassword, parol).Build().Perform();
            new Actions(drv).Click(searchbuttonSubmit).Build().Perform();
        }
        public IWebElement GetName()
        {
            return searchinputLogin;
        }
        public IWebElement GetPassword()
        {
            return searchinputPassword;
        }
        public IWebElement GetbuttonSubmit()
        {
            return searchbuttonSubmit;
        }
    }
}
