using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AutoCOL.src.PageObjects
{
    class FacebookHomePage : BasePageObject
    {
        // Constants
        private const String PAGE_TITLE = "Facebook – log in or sign up";

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement userName;

        [FindsBy(How = How.Id, Using = "pass")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//input[@value='Log In']")]
        private IWebElement logInButton;

        // Constructor
        public FacebookHomePage(IWebDriver p_Driver)
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

        // Input Email Address in SignIn Page
        public bool SetUserName(String p_UserName)
        {
            try
            {
                if (!userName.Enabled || !userName.Displayed)
                {
                    return LogError("Username textbox is disabled or invisible!");
                }

                userName.Clear();
                userName.SendKeys(p_UserName);
            }
            catch (Exception ex)
            {
                return LogError("Exception occurs while performing SetUserName(), error: " + ex.ToString());
            }

            return true;
        }

        // Input Password in SignIn Page
        public bool SetPassword(String p_Password)
        {
            try
            {
                if (!password.Enabled || !password.Displayed)
                {
                    return LogError("Password textbox is disabled or invisible");
                }

                password.Clear();
                password.SendKeys(p_Password);
            }
            catch (Exception ex)
            {
                return LogError("Exception occurs while performing SetPassword(), error: " + ex.ToString());
            }

            return true;
        }


        //Click on Log In button
        public bool ClickLogIn()
        {
            try
            {
                if (!logInButton.Enabled || !logInButton.Displayed)
                {
                    return LogError("Sign In button is disabled or invisible");
                }

                logInButton.Click();
                return true;
            }
            catch (Exception ex)
            {
                return LogError("Exception occurs while performing ClickLogIn(), error: " + ex.ToString());
            }
        }
    }
}
