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
    class MyProfilePage : BasePageObject
    {
        // Constants
        private const String PAGE_URL = "https://shop.circles.life/my_profile";

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'MY ACCOUNT')]")]
        private IWebElement myAccount;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"st-container\"]/div/div/div[2]/div[1]/div/div[2]/div/div/div/div[2]/div[2]/div/div/div/form/div[3]/div/input")]
        private IWebElement myAccountEmail;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"st-container\"]/div/div/div[1]/div/div/div[2]/div/a[6]/div")]
        private IWebElement logout;

        // Constructor
        public MyProfilePage(IWebDriver p_Driver)
        {
            driver = p_Driver;
            PageFactory.InitElements(driver, this);
        }

        // Verify whether its a My Profile page or not
        public bool VerifyPage()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'MY ACCOUNT')]")));
                Thread.Sleep(3000);

                return (driver.Url.ToUpper() == PAGE_URL.ToUpper());
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyPage(),Error: " + ex.ToString());
            }
        }

        // Verify whether My Profile Email Id is correct or not
        public bool VerifyMyProfileEmail(String p_EmailId)
        {
            String email = null;
            try
            {
                if(!myAccountEmail.Displayed)
                {
                    return LogError("Email ID textbox is not displayed ");
                }

                email = myAccountEmail.GetAttribute("value");

                return (email == p_EmailId);
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyMyProfileEmail(),Error: " + ex.ToString());
            }
        }

        // Click on Logout button
        public bool ClickLogout()
        {
            try
            {
                if (!logout.Enabled || !logout.Displayed)
                {
                    return LogError("Logout Link is disabled or invisible");
                }

                logout.Click();
                return true;
            }

            catch (Exception ex)
            {
                return LogError("Exception occurs while performing ClickLogout(), error: " + ex.ToString());
            }
        }

    }
}
