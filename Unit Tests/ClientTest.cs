using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ClientTests.Test
{
    class ClientTest
    {
        [TestMethod]
        public void CreateClient()
        {
            string url = "https://localhost:44372/Client";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("FirstName")).SendKeys("MRRRR");
            driver.FindElement(By.Id("LastName")).SendKeys("Handsome");
            driver.FindElement(By.Id("Email Address")).SendKeys("handsome@gmail.com");
            driver.FindElement(By.Id("Branch")).SendKeys("LOHA");
            driver.FindElement(By.Id("Address")).SendKeys("123 road");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();

        }

    }
}
