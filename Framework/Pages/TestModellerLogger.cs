using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Pages;

namespace Pages
{
    public class TestModellerLogger : BasePage
    {
        public TestModellerLogger(IWebDriver driver)
            : base(driver)
        {

        }

        public void LogMessage(String name, String desc)
        {
            Utilities.TestModellerLogger.LogMessage(name, desc, CuriositySoftware.RunResult.Entities.TestPathRunStatus.Passed);
        }

        public void LogMessageWithScreenshot(String name, String desc)
        {
            Utilities.TestModellerLogger.LogMessageWithScreenshot(name, desc, (Utilities.GetScreenShot.captureAsByteArray(m_Driver)), CuriositySoftware.RunResult.Entities.TestPathRunStatus.Passed);
        }
    }
}
