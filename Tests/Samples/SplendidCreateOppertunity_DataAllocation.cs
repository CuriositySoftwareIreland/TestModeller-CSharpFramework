using CuriositySoftware.DataAllocation.Engine;
using CuriositySoftware.DataAllocation.Entities;
using CuriositySoftware.RunResult.Entities;
using MagentoSeleniumNet.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModellerCSharp.Pages.Samples.Splendid;

namespace MagentoSeleniumNet.Tests
{
    [TestFixture]
    public class SplendidCreateOppertunity_DataAllocation : TestBase
    {

        [Test]
        [TestModellerId("6552c259-ba96-48b3-978f-a221b958946f")]
        [DataAllocation("SplendidUAT", "Create Oppertunity", (new[] { "Default Profile_GoToUrl_PositiveName_PositiveAccountName_NegativeAmount_Save1::*" }))]
        public void DefaultProfileGoToUrlPositiveNamePositiveAccountNameNegativeAmountSave1()
        {
            DataAllocationResult CreateOppertunity_AccountName = dataAllocationEngine.GetDataResult("SplendidUAT", "Create Oppertunity", "Default Profile_GoToUrl_PositiveName_PositiveAccountName_NegativeAmount_Save1:::Create Oppertunity_AccountName");

            LoginPage _LoginPage = new LoginPage(driver);
            _LoginPage.GoToUrl();

            _LoginPage.Enter_UsernameInput("admin");

            _LoginPage.Enter_PasswordInput("admin");

            _LoginPage.Click_LoginButton();

            OpportunitiesPage _PagesOpportunities = new OpportunitiesPage(driver);
            _PagesOpportunities.GoToUrl();

            _PagesOpportunities.Enter_Name("omnis");

            _PagesOpportunities.Enter_AccountName(CreateOppertunity_AccountName.GetValueByColumnIndex(0).ToString());

            _PagesOpportunities.Enter_Amount("100.2.22");

            _PagesOpportunities.Click__Save_();
        }
    }
}
