using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutomatePucaBot
{
    class Program
    {
        private static IWebDriver driver = new FirefoxDriver();

        static void Main(string[] args)
        {
            login();
            GoToTrades();
            Console.Read();
        }

        private static void login()
        {
            driver.Navigate().GoToUrl("http://www.pucatrade.com/");
            var home_login = driver.FindElement(By.Id("home-login"));
            home_login.FindElement(By.Id("login")).SendKeys("kingsplat1337@gmail.com");
            home_login.FindElement(By.Id("password")).SendKeys("Lort1234!");
            home_login.FindElement(By.ClassName("btn-primary")).Click();
          
        }

        private static void GoToTrades()
        {
            driver.Navigate().GoToUrl("http://www.pucatrade.com/trades");

            //Toogle automatching on
            driver.FindElement(By.CssSelector("label.niceToggle")).Click();

            //Sort by Member points
            driver.FindElement(By.CssSelector("th[title='user_points']")).Click();


        }
    }
}
