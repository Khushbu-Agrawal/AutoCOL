using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace AutoCOL.src.PageObjects
{
    class HomePage : BasePageObject
    {
        // Constants
        private const String PAGE_TITLE = "Circles.Life | Unlimit your telco. Now.";

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign up')]")]
        private IWebElement signUp;

        // Constructor
        public HomePage(IWebDriver p_Driver)
        {
            driver = p_Driver;
            PageFactory.InitElements(driver, this);
        }

        // Verify whether its a home page or not
        public bool VerifyPage()
        {
            try
            {
                return (driver.Title.ToUpper() == PAGE_TITLE.ToUpper());
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyPage(),Error: " + ex.ToString());
            }
        }

        public SignInPage ClickSignUp()
        {
            try
            {
                Thread.Sleep(1000);
                signUp.Click();

                //Store the parent window handle
                Thread.Sleep(1000);
                String parentWindowHandle=driver.CurrentWindowHandle;

                // Try to close secondry popup window
                List<string> handles = driver.WindowHandles.ToList();
                if (handles.Count > 1)
                {
                    driver.SwitchTo().Window(handles[1]);
                    driver.Close();
                }
                driver.SwitchTo().Window(parentWindowHandle);

                return new SignInPage(driver);
            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing ClickSignUp(), error: " + ex.ToString());
            }

            return null;
        }
    }
}
