using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;


namespace Unit_Tests
{
    [TestClass]
    class ClientTest
    {
        private string url = "http://localhost:5000/Clients";

        private ChromeDriver CreateDriver()
        {
            string path = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\chromeDriver\"));
            return new ChromeDriver(newPath);
        }
        [Test, Order(1)]
        public void CreateEmployee()
        {
            ChromeDriver driver = CreateDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Id("Input_Email")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Email")).SendKeys("admin@gmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).SendKeys("password");
            driver.FindElement(By.ClassName("btn-primary")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("FirstName")).SendKeys("MRRRR");
            driver.FindElement(By.Id("LastName")).SendKeys("Handsome");
            driver.FindElement(By.Id("Email")).SendKeys("handsome@gmail.com");
            driver.FindElement(By.Id("Branch")).SendKeys("LOHA");
            driver.FindElement(By.Id("Address")).SendKeys("123 road");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
            driver.Quit();

        }

        [Test, Order(2)]
        public void EditClient()
        {
            ChromeDriver driver = CreateDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("Input_Email")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Email")).SendKeys("admin@gmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).SendKeys("password");
            driver.FindElement(By.ClassName("btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //EDIT Client CLICK
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("FirstName")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("FirstName")).Clear();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("FirstName")).SendKeys("MSSSS");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("LastName")).Clear();
            driver.FindElement(By.Id("LastName")).SendKeys("UGLY");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("clientlTest1@gmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Branch")).Clear();
            driver.FindElement(By.Id("Branch")).SendKeys("Edited Branch Test11");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Address")).Clear();
            driver.FindElement(By.Id("Address")).SendKeys("Delta");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }

        [Test, Order(3)]
        public void DetailsEditClient()
        {
            ChromeDriver driver = CreateDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("Input_Email")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Email")).SendKeys("admin@gmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).SendKeys("password");
            driver.FindElement(By.ClassName("btn-primary")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //DETAIL CLIENT CLICK
            driver.FindElement(By.LinkText("Details")).Click();
            Thread.Sleep(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.LinkText("Edit")).Click();
            Thread.Sleep(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.LinkText("Back to List")).Click();
        }


        [Test, Order(4)]
        public void DeleteClient()
        {
            ChromeDriver driver = CreateDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Id("Input_Email")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Email")).SendKeys("admin@gmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).SendKeys("password");
            driver.FindElement(By.ClassName("btn-primary")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //DELETE CLIENT CLICK
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }

    }
}
