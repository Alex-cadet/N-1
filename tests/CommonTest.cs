using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace N_1.tests
{
    public class CommonTest
    {
        protected static IWebDriver drv;
        [SetUp]
        public void Setup()
        {
            drv = new ChromeDriver();
            drv.Navigate().GoToUrl("http://localhost:5000/");
            drv.Manage().Window.Maximize();
        }
        [TearDown]
        public void Exit()
        {
            drv.Close();
            drv.Quit();
        }
    }
}
