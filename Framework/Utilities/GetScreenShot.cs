using OpenQA.Selenium;
using System;
using System.IO;

namespace Utilities
{
    public class GetScreenShot {
        public static byte[] captureAsByteArray(IWebDriver driver)
        {
            return ((ITakesScreenshot) driver).GetScreenshot().AsByteArray;
        }
    }
}