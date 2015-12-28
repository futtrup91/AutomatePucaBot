using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AutomatePucaBot
{
    class Program
    {
        private static IWebDriver driver = new FirefoxDriver();
        private static DateTime time = DateTime.Now;

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

        private static void load_and_scroll(int minValue)
        {
            object oldScroll_y = 0;
            int lowest_visible_points = 0;
            while (true)
            {
                try
                {
                  lowest_visible_points = int.Parse(driver.FindElement(By.CssSelector(".cards-show tbody tr:last-of-type td.points")).Text);
                }

                catch(Exception)
                {
                    break;
                }
               

                if(lowest_visible_points < minValue)
                {
                    break;
                }
                
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, " + 5000 + ");");

                Thread.Sleep(1000);
                while (true)
                {
                    try {
                        var pucas_load_spinner = driver.FindElement(By.Id("fancybox-loading"));
                    }
                    catch(Exception e)
                    {
                        break;
                    }
                }
                var scroll_y = ((IJavaScriptExecutor)driver).ExecuteScript("return window.scrollY;");
            }
        }

        public void read_and_populate_list()
        {

        }


        private static void GoToTrades()
        {
            driver.Navigate().GoToUrl("http://www.pucatrade.com/trades");

            //Toogle automatching on
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("label.niceToggle")).Click();

            //Sort by Member points
            driver.FindElement(By.CssSelector("th[title='user_points']")).Click();

            load_and_scroll(250);
            Console.Write("Works");
        }
    }
}
