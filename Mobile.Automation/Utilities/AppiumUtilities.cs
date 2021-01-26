using Automation.Framework.Mobile.Automation.Infrastructure;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;

namespace Automation.Framework.Mobile.Automation.Utilities
{
    /// <summary>
    ///The AppiumUtilities class
    ///Contains methods pertaining to Appium
    ///e.g.Method to start AppiumService locally
    /// </summary>
    /// 
    ///
    /// <remarks>
    /// Before using the Utilities please ensure Appium is installed.
    /// Please see <see cref="http://appium.io/docs/en/about-appium/getting-started/?lang=en"/>
    /// </remarks>
    public class AppiumUtilities : Context
    { 
        #region Private Members

        private static AppiumLocalService _appiumLocalService;
        private const string _applicationUnderTest = "appPath";

        #endregion Private Members

        #region Methods

        /// <summary>
        /// Starts Appium Server locally on available free port
        /// </summary>
        public AppiumLocalService StartAppiumLocalService()
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            if (!_appiumLocalService.IsRunning)
                _appiumLocalService.Start();

            return _appiumLocalService;
        }

        /// <summary>
        /// Starts Appium Server locally.
        /// </summary>
        /// <param name="portNumber"></param>
        /// <returns></returns>
        public AppiumLocalService StartAppiumLocalService(int portNumber)
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingPort(portNumber).Build();
            if (!_appiumLocalService.IsRunning)
                _appiumLocalService.Start();

            return _appiumLocalService;
        }

        public static AndroidDriver<AndroidElement> InitializeAndroidNativeApp()
        {
            Context context = new Context();
            var driverOptions = new AppiumOptions();
            context.GetConfiguration();
            dynamic devicesFromconfig = context.Configuration["devices"];
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, devicesFromconfig[0].os);
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, context.Configuration[_applicationUnderTest]);
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, devicesFromconfig[0].deviceName);
            driverOptions.AddAdditionalCapability("autoAcceptAlerts", true);
            driverOptions.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, 100);
            driverOptions.AddAdditionalCapability("autoGrantPermissions", true);

            //This line is specific to the current AUT
            driverOptions.AddAdditionalCapability("appWaitActivity", "md525147372f3ece587b62293ecc226e68b.MainActivity");

            AndroidDriver<AndroidElement> androidDriver = new AndroidDriver<AndroidElement>(_appiumLocalService, driverOptions);
            return androidDriver;
        }

        #endregion Methods
    }
}