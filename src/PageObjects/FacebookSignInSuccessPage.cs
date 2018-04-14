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
    class FacebookSignInSuccessPage : BasePageObject
    {
        // Constants
        private const String PAGE_TITLE = "Facebook";

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Home')]")]
        private IWebElement home;

        [FindsBy(How = How.XPath, Using = "//textarea[@name='xhpc_message']")]
        private IWebElement status;
 
        private String commentText = "Sample comment";

        // Constructor
        public FacebookSignInSuccessPage(IWebDriver p_Driver)
        {
            driver = p_Driver;
            PageFactory.InitElements(driver, this);
        }

        // Verify whether its a home page or not
        public bool VerifyPage()
        {
            try
            {
                return (driver.Title.ToUpper().Contains(PAGE_TITLE.ToUpper()));
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyPage(),Error: " + ex.ToString());
            }
        }

        // Post comment in Facebook Home Page
        public bool PostComment()
        {
            try
            {
                home.Click();
                Thread.Sleep(3000);

                // Write post message                  
                status.SendKeys(commentText);
                Thread.Sleep(3000);

                // Post comment
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Post']"))).Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                return LogError("Exception occurs while performing PostComment(), error: " + ex.ToString());
            }

            return true;
        }

    }
}
