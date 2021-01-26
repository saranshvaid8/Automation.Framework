using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Automation.Framework.Mobile.Automation.Infrastructure
{
    /// <summary>
    /// This class contains setup context
    /// </summary>
    public class Context
    {
        #region Private Members
        private const string _applicationUnderTest = "appPath";
        
        private AppiumDriver<AndroidElement> AndroidContext;
        public AppiumLocalService AppiumServiceContext;

        #endregion

        public IDictionary<string, object> Configuration;

        /// <summary>
        /// Set's up the overall initial state i.e.
        /// starting appiumServer, getting configurations and initializing the driver
        /// </summary>
        public void SetUp()
        {
            
            this.GetConfiguration();
            
        }


        
        /// <summary>
        /// Closes active appium session
        /// </summary>
        public void TearDown()
        {
            AppiumServiceContext.Dispose();
        }



        /// <summary>
        /// Initializes the IOS drivert to launch the app
        /// </summary>
        private void GetIosDriver()
        {
            // initialize options
            //add capabilities
            //initialize IOS driver
        }
        /// <summary>
        /// Reads the "Config.Json" from the output directory and returns a Dictionary 
        /// </summary>
        /// <returns>IDictionary<string,object></string></returns>
        public IDictionary<string, object> GetConfiguration()
        {
            //string fileName = "Config.Json";
            //string path = Path.Combine(Environment.CurrentDirectory,@"Infrastructure" , fileName);

            var text = File.ReadAllText(@"S:\QA\Automation\Appium\src\Automation.Framework\Mobile.Automation\Infrastructure\Config.Json");
            Configuration = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(text);
            
            return Configuration;

        }
    }
}
