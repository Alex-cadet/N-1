
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
        private const string Login = "user";
        private const string Password = "user";
        public Sign(IWebDriver drv)
        {
            this.drv = drv;
        }
        public  IWebDriver drv;
        public static IWebDriver Reg(IWebDriver drv)    
        {
            Vhod vh = new Vhod(drv);
            vh.LogPar($"{Login}", $"{Password}");                    
            return drv;
        }
    }
}
