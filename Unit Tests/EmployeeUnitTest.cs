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
    public class EmployeeUnitTest
    {
        string url = "http://localhost:5000/Employees";
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

            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElement(By.Id("DateJoined")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("DateJoined")).SendKeys("01012021" + Keys.Right + "1111pm");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("EmerContact")).SendKeys("EmerContact Test1");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("FirstName")).SendKeys("FirstName Test1");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("LastName")).SendKeys("LastName Test1");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Email")).SendKeys("EmailTest1@gmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Branch")).SendKeys("Branch Test1");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Address")).SendKeys("Address Test1");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            new SelectElement(driver.FindElement(By.Id("SelectedRolesID"))).SelectByText("Admin");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
            driver.Quit();
        }

        [Test, Order(2)]
        public void EditEmployee()
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

            //EDIT EMPLOYEE CLICK
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("DateJoined")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("DateJoined")).Clear();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("DateJoined")).SendKeys("01022021" + Keys.Right + "1211am");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElement(By.Id("EmerContact")).Clear();
            driver.FindElement(By.Id("EmerContact")).SendKeys("Edited EmerContact Test1");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("FirstName")).Clear();
            driver.FindElement(By.Id("FirstName")).SendKeys("Edited FirstName Test1");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("LastName")).Clear();
            driver.FindElement(By.Id("LastName")).SendKeys("Edited LastName Test1");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("EditedEmailTest1@gmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Branch")).Clear();
            driver.FindElement(By.Id("Branch")).SendKeys("Edited Branch Test1");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Address")).Clear();
            driver.FindElement(By.Id("Address")).SendKeys("Coquitlam");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
            driver.Quit();
        }

        [Test, Order(3)]
        public void DetailsEditEmployee()
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

            //DETAIL EMPLOYEE CLICK
            driver.FindElement(By.LinkText("Details")).Click();
            Thread.Sleep(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.LinkText("Edit")).Click();
            Thread.Sleep(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.LinkText("Back to List")).Click();
            driver.Quit();
        }


        [Test, Order(4)]
        public void DeleteEmployee()
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

            //DELETE EMPLOYEE CLICK
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
            driver.Quit();
        }

    }
}
