using CuriositySoftware.RunResult.Entities;
using CuriositySoftware.RunResult.Services;
using CuriositySoftware.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagentoSeleniumNet.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;

        public String APIUrl = "";

        public String APIKey = "";

        [SetUp]
        public void initDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(new String[] { "--start-maximized" });

            driver = new ChromeDriver(options);
        }

        [TearDown]
        public void closerDriver()
        {
            TestModellerId[] attr = TestExecutionContext.CurrentContext.CurrentTest.Method.GetCustomAttributes<TestModellerId>(true);
            if (attr != null && attr.Length > 0)
            {
                String guid = attr[0].guid;

                TestPathRunEntity testPathRun = new TestPathRunEntity();
                testPathRun.message = TestExecutionContext.CurrentContext.CurrentResult.Message; 
                testPathRun.runTime = (int) (TestExecutionContext.CurrentContext.CurrentResult.EndTime.ToUniversalTime().Ticks - TestExecutionContext.CurrentContext.CurrentResult.StartTime.ToUniversalTime().Ticks);
                testPathRun.runTimeStamp = DateTime.Now;
                testPathRun.testPathGuid = (guid);
                testPathRun.vipRunId = (TestRunIdGenerator.GenerateGuid());

                if (TestExecutionContext.CurrentContext.CurrentResult.ResultState.Equals(ResultState.Success)) {
                    testPathRun.testStatus = (TestPathRunStatus.Passed);
                } else {
                    testPathRun.testStatus = (TestPathRunStatus.Failed);
                }

                // Post it
                ConnectionProfile cp = new ConnectionProfile();
                cp.APIKey = APIKey;
                cp.Url = APIUrl;

                TestRunService runService = new TestRunService(cp);
                runService.PostTestRun(testPathRun);
            }

            driver.Quit();
        }
    }
}
