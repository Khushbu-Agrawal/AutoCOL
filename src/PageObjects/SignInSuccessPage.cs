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
    class SignInSuccessPage : BasePageObject
    {
        //Constants
        private const String PAGE_URL = "https://shop.circles.life/plan";
     
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'MY ACCOUNT')]")]
        private IWebElement myAccount;

        //Constructor
        public SignInSuccessPage(IWebDriver p_Driver)
        {
            driver = p_Driver;
            PageFactory.InitElements(driver, this);
        }

        //Verify whether its a Sign In Success page or not
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

        //Click on MY ACCOUNT Link in SignIn Success Page

        public bool ClickMyAccount()
        {
            try
            {
                if (!myAccount.Enabled || !myAccount.Displayed)
                {
                    return LogError("My ACCOUNT Link is disabled or invisible");
                }

                myAccount.Click();
                return true;
            }

            catch (Exception ex)
            {
                return LogError("Exception occurs while performing ClickMyAccount(), error: " + ex.ToString());
            }

        }
    }
}
