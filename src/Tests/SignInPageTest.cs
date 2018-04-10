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


namespace AutoCOL.src.Tests
{
    [TestClass]
    public class SignInPageTest : BaseTest
    {
        // Test data for this class
        private SignInTestData testData = new SignInTestData("SignIn.json");
        private IWebDriver driver;

        //////////////////////////////////////////////////////////////////////

        [TestInitialize]
        public void TestInit()
        {
            driver = InitDriver(); // Setup driver
        }

        [TestCleanup]
        public void TestClean()
        {
            driver.Quit(); // Cleanup driver
        }

        ////////////////////////////////////////////////////////////////////

        // Helper test function to perform common SignIn routine
        private SignInPage PerformSignIn(SignInData p_SignInData)
        {
            // Verify driver is initialized
            Assert.IsNotNull(driver, "Driver initialization FAILED");

            // Verify input SignInData
            Assert.IsNotNull(p_SignInData, "TestData load FAILED");

            // Verify Home page is loaded
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.VerifyPage(), "HomePage VerifyPage() FAILED");

            // Verify SignIn page is loaded
            SignInPage signInPage = homePage.ClickSignUp();
            Assert.IsNotNull(signInPage, "ClickSignUp() FAILED");
            Assert.IsTrue(signInPage.VerifyPage(), "SignInPage VerifyPage() FAILED");

            // Verify test data are set
            Assert.IsTrue(signInPage.SetUserName(p_SignInData.userName), "SetUserName() FAILED");
            Assert.IsTrue(signInPage.SetPassword(p_SignInData.password), "SetPassword() FAILED");

            // Verify SigIn button is clicked
            Assert.IsTrue(signInPage.ClickSignIn(), "ClickSignIn() FAILED");

            return signInPage;
        }


        [TestMethod]
        public void TestSignIn()
        {
            //Verify input SignInData
            Assert.IsNotNull(testData, "TestData Load Failed");
            SignInData signInData = testData.GetTestData("TestSignIn");
            
            // Perform Sign In
            PerformSignIn(signInData);

            //Verify SignInSuccessPage is loaded
            SignInSuccessPage signInSuccessPage = new SignInSuccessPage(driver);
            Assert.IsTrue(signInSuccessPage.VerifyPage(), "SignInSuccessPage VerifyPage() FAILED");

            Assert.IsTrue(signInSuccessPage.ClickMyAccount(), "SignInSuccessPage ClickMyAccount() FAILED");

            MyProfilePage myProfilePage = new MyProfilePage(driver);

            Assert.IsTrue(myProfilePage.VerifyMyProfileEmail(signInData.userName), "MyProfliPage VerifyProfilePage() FAILED");
        }

    }
}
