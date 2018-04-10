using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCOL.src.TestData
{
    // Base class to serve all test data classes
    public abstract class TestData
    {
        // Constants
        private const String TD_FOLDER_ENV_STR = "COLTestDataFolder";

        // Class data
        public bool isLoaded { get; set; }

        // Derived classes to override
        public abstract void Load(String p_FileName);

        // Gets the TD full file path
        public String GetFilePath(String p_FileName)
        {
            String testFolderPath = Environment.GetEnvironmentVariable(TD_FOLDER_ENV_STR);
            if (String.IsNullOrEmpty(testFolderPath))
            {
                Console.WriteLine("Error: Failed to get 'COLTestDataFolder' environment variable!");
                return "";
            }

            return (testFolderPath + "/" + p_FileName);
        }

    }
}

