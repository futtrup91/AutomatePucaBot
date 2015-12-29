using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AutomatePucaBot
{
    internal class Program
    {
        private static readonly IWebDriver driver = new FirefoxDriver();
        private static DateTime time = DateTime.Now;
        private static List<Member> memberlList;

        private static void Main(string[] args)
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
            var lowest_visible_points = 0;
            while (true)
            {
                try
                {
                    lowest_visible_points =
                        int.Parse(driver.FindElement(By.CssSelector(".cards-show tbody tr:last-of-type td.points")).Text);
                }

                catch (Exception)
                {
                    break;
                }


                if (lowest_visible_points < minValue)
                {
                    break;
                }

                ((IJavaScriptExecutor) driver).ExecuteScript("window.scrollBy(0, " + 5000 + ");");

                Thread.Sleep(1000);
                while (true)
                {
                    try
                    {
                        var pucas_load_spinner = driver.FindElement(By.Id("fancybox-loading"));
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
                var scroll_y = ((IJavaScriptExecutor) driver).ExecuteScript("return window.scrollY;");
            }
        }

        public static ReadOnlyCollection<IWebElement> GetTableRows()
        {
            return driver.FindElements(By.CssSelector("tbody tr"));
        }

        public static List<Member> read_and_populate_list()
        {
            var members = new List<Member>();
            Member member;
            foreach (var row in GetTableRows())
            {
                var memberName = row.FindElement(By.ClassName("member")).Text.Trim();
                        var memberLink = "";
                        var memberLinkList =
                            row.FindElement(By.ClassName("member")).FindElements(By.CssSelector("a"));
                        var memberPoints = row.FindElement(By.ClassName("points")).Text;
                        foreach (var mm in memberLinkList)
                        {
                            var s = mm.GetAttribute("href");
                            if (s.Contains("profile"))
                            {
                                memberLink = mm.GetAttribute("href");
                            }
                        }
                        member = new Member(memberName, memberPoints, memberLink);                   

                    var cardLinkList =
                        row.FindElement(By.ClassName("fancybox-send"))
                            .GetAttribute("href");
                    var cardName = row.FindElement(By.ClassName("cb")).Text;

                    var cardValue = row.FindElement(By.ClassName("value")).Text;

                    var c = new Card(cardName, cardValue, cardLinkList, member);
                    member.addCard(c);
                    members.Add(member);                
         
            }
            return members;
        }

        public static
            void find_trades
            ()
        {
            var min_value = 750;
        }


        private static
            void GoToTrades
            ()
        {
            driver.Navigate().GoToUrl("http://www.pucatrade.com/trades");

            //Toogle automatching on
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("label.niceToggle")).Click();

            //Sort by Member points
            driver.FindElement(By.CssSelector("th[title='user_points']")).Click();

            load_and_scroll(250);
            Console.WriteLine(read_and_populate_list().Count);
   
            Console.Write("Works");
        }
    }
}