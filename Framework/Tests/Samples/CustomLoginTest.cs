using Pages.CustomerAuthentication;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuriositySoftware.RunResult.Entities;
using CuriositySoftware.DataAllocation.Engine;

namespace Tests
{
    [TestFixture]
    [Ignore("Sample test requires correct ConnectionProfile setup")]
    public class CustomLoginTest : TestBase
    {
        [Test]
        [TestModellerId("91eb4aaf-516c-49f2-a373-b359928c1b9f")]
        public void InvalidLoginEmail()
        {
            CustomerLoginPage customerLoginPage = new CustomerLoginPage(driver);
            customerLoginPage.goToURL();
            customerLoginPage.enterEmail("james");
            customerLoginPage.enterPassword("james");
            customerLoginPage.submitLogin();
        }
    }
}
