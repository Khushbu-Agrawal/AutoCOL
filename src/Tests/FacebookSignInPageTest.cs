using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

using AutoCOL.src.PageObjects;
using AutoCOL.src.TestData;
using AutoCOL.src.Config;

namespace AutoCOL.src.Tests
{
    [TestClass]
    public class FacebookSignInPageTest : BaseTest
    {
        // Test data for this class
        private FacebookHomeTestData testData = new FacebookHomeTestData("FacebookSignIn.json");
        private IWebDriver driver;

        //////////////////////////////////////////////////////////////////////

        [TestInitialize]
        public void TestInit()
        {
            driver = InitDriver(TestConfig.fbUrl); // Setup driver
        }

        [TestCleanup]
        public void TestClean()
        {
            driver.Quit(); // Cleanup driver
        }

        ////////////////////////////////////////////////////////////////////

        // Helper test function to perform common SignIn routine
        private void PerformSignIn(FacebookHomeData p_FacebookHomeData)
        {
            // Verify driver is initialized
            Assert.IsNotNull(driver, "Driver initialization FAILED");

            // Verify input SignInData
            Assert.IsNotNull(p_FacebookHomeData, "TestData load FAILED");

            // Verify Home page is loaded
            FacebookHomePage homePage = new FacebookHomePage(driver);
            Assert.IsTrue(homePage.VerifyPage(), "FacebookHomePage VerifyPage() FAILED");

            // Verify test data are set
            Assert.IsTrue(homePage.SetUserName(p_FacebookHomeData.userName), "SetUserName() FAILED");
            Assert.IsTrue(homePage.SetPassword(p_FacebookHomeData.password), "SetPassword() FAILED");

            // Verify SigIn button is clicked
            Assert.IsTrue(homePage.ClickLogIn(), "ClickSignIn() FAILED");
        }

        [TestMethod]
        public void TestFacebookPostComment()
        {
            //Verify input SignInData
            Assert.IsNotNull(testData, "TestData Load Failed");
            FacebookHomeData facebookHomeData = testData.GetTestData("TestFacebookPostComment");

            // Perform Sign In
            PerformSignIn(facebookHomeData);
            
            //Verify FacebookSignInSuccessPage is loaded
            FacebookSignInSuccessPage facebookSignInSuccessPage = new FacebookSignInSuccessPage(driver);
            Assert.IsTrue(facebookSignInSuccessPage.VerifyPage(), "FacebookSignInSuccessPage VerifyPage() FAILED");
            Assert.IsTrue(facebookSignInSuccessPage.PostComment(), "FacebookSignInSuccessPage PostComment() FAILED");
        }

    }
}
