using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Amazon
{
    public class Tests
    {
        WebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test_AmazonE2E()
        {
            // go to Amazon website
            driver.Url = "https://www.amazon.in/";
            driver.Manage().Window.Maximize();

            //search for mobiles
            IWebElement search = driver.FindElement(By.Id("twotabsearchtextbox"));
            search.Click();
            search.SendKeys("mobiles");
            search.SendKeys(Keys.Enter);

            //get all searched mobiles list
            IList<IWebElement> list = driver.FindElements(By.XPath("//span[@class='a-size-medium a-color-base a-text-normal']"));
            foreach (var item in list)
            {
                Console.WriteLine(item.Text);
            }
            // select 7th mobile in a search
            string sel = list[7].Text;
            Console.WriteLine(sel);
            list[7].Click();
            Console.WriteLine("-----------");
            //stay in that child window
             int count = driver.WindowHandles.Count;
            Console.WriteLine(count);
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            Thread.Sleep(2000);
            Boolean display = driver.FindElement(By.Id("add-to-cart-button")).Displayed;
            Console.WriteLine("display" + display);
            Boolean press1 = display;
            switch (press1)
            {
                case true:
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("scrollBy(0,300);");
                    //add to cart 1nd product
                    driver.FindElement(By.Id("add-to-cart-button")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.Id("attach-close_sideSheet-link")).Click();
                    Thread.Sleep(500);
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Navigate().Refresh();
                    break;
                default:
                    driver.FindElement(By.XPath("//a[text()=' See All Buying Options ']")).Click();
                    driver.FindElement(By.ClassName("submit.addToCart")).Click();
                    driver.FindElement(By.CssSelector("i.a-icon.a-icon-close.a-icon-medium.aod-close-button")).Click();
                    Thread.Sleep(500);
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Navigate().Refresh();
                    break;
            }
             
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("scrollBy(0,4500);");
            //click on for next pages
            driver.FindElement(By.XPath("//a[text()='3']")).Click();
            Thread.Sleep(2000);
            //
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
            js2.ExecuteScript("scrollBy(0,6000);");

            driver.FindElement(By.XPath("//a[text()='4']")).Click();
            Thread.Sleep(2000);
            //
            IJavaScriptExecutor js3 = (IJavaScriptExecutor)driver;
            js3.ExecuteScript("scrollBy(0,4000);");

            driver.FindElement(By.XPath("//a[text()='5']")).Click();
            Thread.Sleep(2000);
            //
            IJavaScriptExecutor js4 = (IJavaScriptExecutor)driver;
            js4.ExecuteScript("scrollBy(0,4000);");

            driver.FindElement(By.XPath("//a[text()='6']")).Click();
            Thread.Sleep(2000);
            //
            IJavaScriptExecutor js5 = (IJavaScriptExecutor)driver;
            js5.ExecuteScript("scrollBy(0,6000);");

            driver.FindElement(By.XPath("//a[text()='7']")).Click();
            Thread.Sleep(2000);
            //
            IJavaScriptExecutor js6 = (IJavaScriptExecutor)driver;
            js6.ExecuteScript("scrollBy(0,4000);");
            driver.FindElement(By.XPath("//a[text()='8']")).Click();
            Thread.Sleep(2000);

              IList<IWebElement> lst = driver.FindElements(By.XPath("//span[@class='a-size-medium a-color-base a-text-normal']"));
                foreach (var item in lst)
                {
                    Console.WriteLine(item.Text);
                }
            string product = lst[8].Text;
            Console.WriteLine(product);
            lst[8].Click();

            driver.SwitchTo().Window(driver.WindowHandles[2]);
            Thread.Sleep(2000);
            // scroll down
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("scrollBy(0,300);");


            Boolean display1 = driver.FindElement(By.Id("add-to-cart-button")).Displayed;
            Console.WriteLine("display" + display1);


            Boolean press = display1;
            switch (press)
            {
                case true:
                    //add to cart 2nd product
                    driver.FindElement(By.Id("add-to-cart-button")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.Id("attach-close_sideSheet-link")).Click();
                    Thread.Sleep(500);
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Navigate().Refresh();
                    break;
                default:
                    driver.FindElement(By.XPath("//a[text()=' See All Buying Options ']")).Click();
                    driver.FindElement(By.ClassName("submit.addToCart")).Click();
                    driver.FindElement(By.CssSelector("i.a-icon.a-icon-close.a-icon-medium.aod-close-button")).Click();
                    Thread.Sleep(500);
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Navigate().Refresh();
                    break;
            }

            Thread.Sleep(1000);
            //scroll up
            IJavaScriptExecutor j1 = (IJavaScriptExecutor)driver;
            j1.ExecuteScript("scrollBy(0,-3000);");

            // click cart
            driver.FindElement(By.Id("nav-cart-count")).Click();
            driver.FindElement(By.CssSelector("[value='Delete']")).Click();
            String amount= driver.FindElement(By.XPath("//span[@id='sc-subtotal-label-buybox']/../span[2]/span")).Text;
            Console.WriteLine(amount);
            string actualRate = "11,499.00";
            Assert.Pass(amount,actualRate);
            driver.Close();
           
        }

    }
}