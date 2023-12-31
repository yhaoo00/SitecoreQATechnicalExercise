﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SitecoreSeleniumExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // driver will not be insert as arg here as it comes along with the selenium nuget package already
            IWebDriver driver = new ChromeDriver();

            // can change the url to singapore (https://www.amazon.sg) if dont want to manual entry for captcha
            // driver.Navigate().GoToUrl("https://www.amazon.sg/");
            driver.Navigate().GoToUrl("https://www.amazon.com/");

            string captcha;

            // another workaround if get captcha
            // user can manually enter captcha via console app
            if (IsCaptchaPage(driver))
            {
                Console.WriteLine("Please enter CAPTCHA: ");
                captcha = Console.ReadLine();

                IWebElement captchaBox = driver.FindElement(By.Id("captchacharacters"));
                captchaBox.SendKeys(captcha);

                IWebElement submitCaptcha = driver.FindElement(By.ClassName("a-button-text"));
                submitCaptcha.Click();
            }

            // find search box with id in the website
            // insert "laptop" string into search box
            IWebElement searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
            searchBox.SendKeys("laptop");

            // find submit search button and click it
            IWebElement submitSearch = driver.FindElement(By.Id("nav-search-submit-button"));
            submitSearch.Click();

            // get first result item
            IWebElement firstResult = driver.FindElement(By.XPath("//div[@data-csa-c-pos='1']//h2/a"));
            firstResult.Click();

            // get price
            IWebElement itemPriceWhole = driver.FindElement(By.XPath("//span[@class='a-price-whole']"));
            IWebElement itemPriceDecimal = driver.FindElement(By.XPath("//span[@class='a-price-fraction']"));

            // concat string to make it into a complete price decimal
            string itemPriceString = itemPriceWhole.Text + '.' + itemPriceDecimal.Text;

            // convert string to double
            double itemPrice = ConvertString(itemPriceString);

            // assert > 100
            if (itemPrice <= 100.00)
            {
                throw new Exception("Laptop price is not more than $100.00, the price is $" +  itemPrice);
            }

            Console.WriteLine("Laptop price is more than $100.00...");

            driver.Quit();

        }

        // to check captcha
        static bool IsCaptchaPage(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.Id("captchacharacters"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // to convert string to double
        static double ConvertString(string s)
        {
            double d;

            if (Double.TryParse(s, out d))
            {
                return d;
            }

            return 0;
        }
    }
}
