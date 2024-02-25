using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumMobileTests
{
    public class AppiumMobileTests
    {
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;

        private const string appLocation = @"D:\RABOTNA\CODING\Projects\QA_Automation\APK-Fiels\com.android.example.github.apk";
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";

        [SetUp]
        public void PrepearApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);
            driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), options);
            //deviceName : "Pixel_6_Pro_API_33"
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Dispose();
        }

        [Test]
        public void Test_Run_Com_Android_Example_Github_On_Emulator()
        {
            Assert.That(true);
        }

        [Test]
        public void Test_Verify_Brancev_Name()
        {
            var fieldSearchRepostories = driver.FindElementById("com.android.example.github:id/input");
            fieldSearchRepostories.Click();
            fieldSearchRepostories.SendKeys("Selenium\\n");

            //Hit enter
            //driver.PressKeyCode(AndroidKeyCode.Keycode_ENTER);
            //driver.PressKeyCode(66);

            //Assert selenium text
            var textSelenium = driver.FindElementByXPath("//android.view.ViewGroup/android.widget.TextView[2]");
            Assert.That(textSelenium.Text, Is.EqualTo("SeleniumHQ/selenium"));
            textSelenium.Click();

            // Assert Barancev is inside the list
            var listTextBarancev = driver.FindElementByXPath("//android.widget.FrameLayout[2]/android.view.ViewGroup/android.widget.TextView");
            Assert.That(listTextBarancev.Text, Is.EqualTo("barancev"));
            listTextBarancev.Click();

            // Assert Barancev name
            var textFieldBarancev = driver.FindElementByXPath("//android.widget.TextView[@content-desc=\"user name\"]");
            Assert.That(textFieldBarancev.Text, Is.EqualTo("Alexei Barantsev"));


        }
    }
}
