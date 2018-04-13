using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutoCOL.src.Config
{
    // Class provides global test configuration settings
    public static class TestConfig
    {
        // Config environment variable name
        private static String CONFIG_FILE_ENV_STR = "COLTestConfigFilePath";

        // Test configuration default values (will be overrider by the config file contents at runtime)
        public static String browser = "Chrome";
        public static String colUrl = "https://pages.circles.life/";
        public static String fbUrl = "https://www.facebook.com/";
        private static bool isLoaded = false;

        // Constructor
        static TestConfig()
        {
            LoadConfigs();
        }

        // Load test configurations
        public static void LoadConfigs()
        {
            if (isLoaded) return; // don't reload again

            String configFilePath = Environment.GetEnvironmentVariable(CONFIG_FILE_ENV_STR);
            if (String.IsNullOrEmpty(configFilePath))
            {
                Console.WriteLine("Error: Failed to get 'COLTestConfigFilePath' environment variable value!");
                return;
            }

            var json = File.ReadAllText(configFilePath);
            try
            {
                var jObject = JObject.Parse(json);
                if (jObject == null) return;

                colUrl = jObject["COL_URL"].ToString();
                fbUrl = jObject["FB_URL"].ToString();
                browser = jObject["Browser"].ToString();

                // Testing only
                Console.WriteLine("\tURL: " + jObject["URL"].ToString());
                Console.WriteLine("\tBrowser: " + jObject["Browser"].ToString());

                isLoaded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Exception caught while loading test configuration from file: '" + configFilePath +"', error: " + ex.ToString());
            }
        }

    }
}
