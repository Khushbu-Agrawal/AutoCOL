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
    class SignInPage : BasePageObject
    {
        //Constants
        private const String PAGE_TITLE = "Unlimit your telco. Now.";

        private const String PAGE_URL = "https://shop.circles.life/login?auto_facebook_login=true";

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement emailAddress;

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Sign In')]")]
        private IWebElement signIn;


        //Constructor
        public SignInPage(IWebDriver p_Driver)
        {
            driver = p_Driver;
            PageFactory.InitElements(driver, this);
        }

        /*
        //Verify whether its a Sign page or not
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
         
         */

        //Verify whether its a Sign In page or not
        public bool VerifyPage()
        {
            try
            {
                return (driver.Url.ToUpper() == PAGE_URL.ToUpper());
            }

            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyPage(),Error: " + ex.ToString());
            }
        }


        //Input Email Address in SignIn Page
        public bool SetUserName(String p_UserName)
        {
            try
            {
                if(!emailAddress.Enabled || !emailAddress.Displayed)
                {
                    return LogError("Username textbox is disabled or invisible!");
                }

                emailAddress.Clear();
                emailAddress.SendKeys(p_UserName);
            }

            catch(Exception ex)
            {
                return LogError("Exception occurs while performing SetUserName(), error: " + ex.ToString());
            }

            return true;
        }

        //Get Email Address in SignIn Page
        public String GetUserName()
        {
            String username = null;
            try
            {               
                if (!emailAddress.Enabled || !emailAddress.Displayed)
                {
                    LogError("Username textbox is disabled or invisible!");
                }
                username = emailAddress.GetAttribute("value");

                return username;

            }

            catch (Exception ex)
            {

                LogError("Exception occurs while performing GetUserName(), error: " + ex.ToString());
            }

            return username;
        }

        //Get Password in SignIn Page
        public String GetPassword()
        {
            String password = null;
            try
            {
                if (!emailAddress.Enabled || !emailAddress.Displayed)
                {
                    LogError("Password textbox is disabled or invisible!");
                }
                password = emailAddress.GetAttribute("value");

                return password;
            }
            catch (Exception ex)
            {

                LogError("Exception occurs while performing GetPassword(), error: " + ex.ToString());
            }

            return password;
        }


        //Input Password in SignIn Page
        public bool SetPassword(String p_Password)
        {
            try
            {
                if(!password.Enabled || !password.Displayed)
                {
                    return LogError("Password textbox is disabled or invisible");
                }

                password.Clear();
                password.SendKeys(p_Password);
            }

            catch(Exception ex)
            {
                return LogError("Exception occurs while performing SetPassword(), error: " + ex.ToString());
            }

            return true;
        }

        //Click on Sign In button
        public bool ClickSignIn()
        {
            try
            {
                if(!signIn.Enabled || !signIn.Displayed)
                {
                    return LogError("Sign In button is disabled or invisible");
                }

                signIn.Click();
                return true;
            }
            catch(Exception ex)
            {
                return LogError("Exception occurs while performing ClickSignIn(), error: " + ex.ToString());
            }
        }

    }
}
