using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using AutoCOL.src.PageObjects;
using AutoCOL.src.Config;

namespace AutoCOL.src.Tests
{
    // Base class to serve all test classes
    public class BaseTest
    {
        // Constants
        private const String CHROME = "Chrome";
        private const String FIREFOX = "Firefox";
        // @todo - add other supporting browsers.

        // Returns driver instance
        public IWebDriver InitDriver()
        {
            IWebDriver driver = null;
            switch(TestConfig.browser)
            {
                case CHROME:
                    ChromeOptions options = new ChromeOptions();
                    //options.AddArgument("-incognito");
                    options.AddArgument("--disable-popup-blocking");
                    
                    DesiredCapabilities capabilities = DesiredCapabilities.Chrome();    
                    capabilities.SetCapability(ChromeOptions.Capability, options);
                    driver = new ChromeDriver(options);

                    break;
                case FIREFOX:
                    driver = new FirefoxDriver();
                    break;
                default:
                    Console.WriteLine("Error: Unknown browser detected !!!");
                    return driver;
            }

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestConfig.url);

            return driver;
        }

    }
}
