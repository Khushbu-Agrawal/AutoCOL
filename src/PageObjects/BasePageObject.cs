using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace AutoCOL.src.PageObjects
{
    //BasePageObject class to serve all the derived PageObject classes
    class BasePageObject
    {
        //Constants
        private const String ERROR_PREFIX_STR = "Error: ";

        //Class Data
        protected IWebDriver driver;

        //Helper functions log error and return false
        public bool LogError(String p_ErrorString)
        {
            Console.WriteLine(ERROR_PREFIX_STR + p_ErrorString);
            return false;
        }

        // Helper function to validate input string and log error if required
        public bool Validate(String p_InputString)
        {
            if(String.IsNullOrEmpty(p_InputString))
            {
                return LogError("Input string is empty!");
            }
            return true;
        }

    }
}
