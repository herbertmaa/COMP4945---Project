using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Unit_Tests
{
    [TestClass]
    class Login_RegisterTest
    {
        private string url = "https://localhost:44372";
        private ChromeDriver CreateDriver()
        {
            string path = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\chromeDriver\"));
            return new ChromeDriver(newPath);
        }

        
        [Test]
        public void RegisterTest()
        {
            ChromeDriver driver = CreateDriver();
            RegisterUser(driver);
            DeleteUser(driver);
            driver.Quit();
        }

        [Test]
        public void LoginTest()
        {
            ChromeDriver driver = CreateDriver();
            RegisterUser(driver);
            Logout(driver);
            NavigateToLogin(driver);
            Login(driver);
            DeleteUser(driver);
            driver.Quit();
        }

        [Test]
        public void AdminLoginTest()
        {
            ChromeDriver driver = CreateDriver();
            LoginAdmin(driver);
            Logout(driver);
            driver.Quit();
        }

        private void Login(ChromeDriver driver)
        {
            NavigateToLogin(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Email")).SendKeys("usertest@gmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).SendKeys("123Bob?");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/section/form/div[5]/button")).Click();
        }

        private void LoginAdmin(ChromeDriver driver)
        {
            NavigateToSite(driver);
            NavigateToLogin(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Email")).SendKeys("admin@gmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).SendKeys("password");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/section/form/div[5]/button")).Click();
            
        }

        private void Logout(ChromeDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/form/button")).Click();
        }

        private void DeleteUser(ChromeDriver driver)
        {
            NavigateToUser(driver);
            driver.FindElement(By.Id("personal-data")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).SendKeys("123Bob?");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("/html/body/div/main/div/div/div[2]/div[2]/form/button")).Click();
        }

        private void RegisterUser(ChromeDriver driver)
        {
            NavigateToSite(driver);
            NavigateToRegister(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Email")).SendKeys("usertest@gmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_Password")).SendKeys("123Bob?");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("Input_ConfirmPassword")).SendKeys("123Bob?");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var userType = driver.FindElement(By.Id("Input_Name"));
            var selectElement1 = new SelectElement(userType);
            selectElement1.SelectByText("Admin");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/form/button")).Click();
        }
        private void NavigateToLogin(ChromeDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.LinkText("Login")).Click();
        }
        private void NavigateToRegister(ChromeDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.LinkText("Register")).Click();
        }
        private void NavigateToSite(ChromeDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }
        
        private void NavigateToUser(ChromeDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.LinkText("Hello usertest@gmail.com!")).Click();
        }

    }
}
