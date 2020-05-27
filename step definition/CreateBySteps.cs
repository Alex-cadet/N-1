using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using N_1.buisness_objects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace N_1.step_definition
{
    
    [Binding]
    class CreateBySteps
    {
        public Product drink = new Product("http://localhost:5000/", "user", "user","kvas", "Beverages", "Pavlova, Ltd.", "45");
        private IWebDriver drv;
        [Given(@"I open ""(.*)"" url")]
        public void GivenIopenurl(string Url)
        {
            drv = new ChromeDriver();
            drv.Manage().Window.Maximize();
            drv.Url = Url;
        }


        [When(@"I send ""(.*)"" in Name-field and ""(.*)"" Password-field")]
        public void WhenIsend_in_Name(string Login, string Password)
        {
            new LogIn(drv).SignIn(Login, Password);
        }
        [When(@"I click button Submit")]
        public void WhenIclickButtonSubmit()
        {
            new LogIn(drv).ClickbuttonSubmit();
        }
        [When(@"I click  reference allProducts")]
        public void WhenIclick_searchbuttonAllProducts()
        {
            new MainPage(drv).ClickAllProduct();
        }
        [When(@"I click  button createNew")]
        public void WhenIclick_buttonCreateNew()
        {
            new MainPage(drv).ClickCreateNew();
        }
        [When(@"I send ""(.*)"" in ProductName-field")]
        public void WhenIsendinProductName(string ProductName)
        {
            new MainPage(drv).ChooseProduct(ProductName);
        }
        [When(@"I select ""(.*)"" in Category-field")]
        public void WhenIselectCategory(string Category)
        {
            new MainPage(drv).SelectCategory(Category);
        }
        [When(@"I select ""(.*)"" in Supplier-field")]
        public void WhenIselectSupplier(string Supplier)
        {
            new MainPage(drv).SelectSupplier(Supplier);
        }
        [When(@"I send ""(.*)"" in UnitPrice-field")]
        public void WhenIsendUnitePrice(string UnitPrice)
        {
            new MainPage(drv).ChoosetUnitPrice(UnitPrice);
        }
        [When(@"I click Submitbutton")]
        public void WhenIclickSubmitbutton()
        {
            new MainPage(drv).Submit();
        }
        [When(@"I click NowMadeProductReference")]
        public void WhenIclickNowMadeProductReference()
        {
            new MainPage(drv).CheckNewProduct();
        }


        [Then(@"ProductName should be ""(.*)""")]
        public void ThenProductName_Is(string ProductName)
        {
            Assert.AreEqual(ProductName, new MainPage(drv).GetProductName());
        }
        [Then(@"Category should be ""(.*)""")]
        public void ThenCategory_Is(string Category)
        {
            Assert.AreEqual(Category, new MainPage(drv).GetCategory());
        }
        [Then(@"Supplier should be ""(.*)""")]
        public void ThenSupplier_Is(string Supplier)
        {
            Assert.AreEqual(Supplier, new MainPage(drv).GetSupplier());
        }
        [Then(@"UnitPrice should be ""(.*)""")]
        public void ThenUnitPrice_Is(string UnitPrice)
        {
            Assert.AreEqual(UnitPrice, new MainPage(drv).GetUnitPrice());
            Thread.Sleep(2000);
            drv.Close();
            drv.Quit();
        }
    }
}
