using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutoCOL.src.TestData
{
    public class FacebookHomeData
    {
        public String userName;
        public String password;
    };

    public class FacebookHomeTestData : TestData
    {
        // Class data
        private Dictionary<String, FacebookHomeData> dataSet;

        // Constructor
        public FacebookHomeTestData(String p_FileName)
        {
            Load(p_FileName); // load test data
        }

        // Load TD for SignIn page test cases
        public override void Load(String p_FileName)
        {
            if (isLoaded) return; // don't reload

            dataSet = new Dictionary<String, FacebookHomeData>();
            try
            {
                String jsonString = File.ReadAllText(GetFilePath(p_FileName));
                dataSet = JsonConvert.DeserializeObject<Dictionary<String, FacebookHomeData>>(jsonString);
                if ((dataSet != null) && dataSet.Count() > 0)
                {
                    isLoaded = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught while loading test data for FacebookHome, error: " + ex.ToString());
            }
        }

        // Returns FacebookHomeData for input test name
        public FacebookHomeData GetTestData(String p_TestName)
        {
            return dataSet[p_TestName];
        }

    }
}
