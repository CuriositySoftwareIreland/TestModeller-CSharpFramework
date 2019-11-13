using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModellerCSharp.Pages.Samples.Splendid
{
    public class OpportunitiesPage : BasePage
    {
        private By NameElem = By.XPath("//INPUT[@name='ctl00$cntBody$ctlEditView$NAME']");

        private By AccountNameElem = By.XPath("//INPUT[@name='ctl00$cntBody$ctlEditView$ACCOUNT_NAME']");

        private By OpportunityTypeElem = By.XPath("//SELECT[@name='ctl00$cntBody$ctlEditView$OPPORTUNITY_TYPE']");

        private By AssignedToNameElem = By.XPath("//INPUT[@name='ctl00$cntBody$ctlEditView$ASSIGNED_TO_NAME']");

        private By LeadSourceElem = By.XPath("//SELECT[@name='ctl00$cntBody$ctlEditView$LEAD_SOURCE']");

        private By DescriptionElem = By.XPath("//TEXTAREA[@name='ctl00$cntBody$ctlEditView$DESCRIPTION']");

        private By CurrencyIDElem = By.XPath("//SELECT[@name='ctl00$cntBody$ctlEditView$CURRENCY_ID']");

        private By AmountElem = By.XPath("//INPUT[@name='ctl00$cntBody$ctlEditView$AMOUNT']");

        private By DateClosedElem = By.XPath("//INPUT[@name='ctl00$cntBody$ctlEditView$DATE_CLOSED$txtDATE']");

        private By NextStepElem = By.XPath("//INPUT[@name='ctl00$cntBody$ctlEditView$NEXT_STEP']");

        private By ProbabilityElem = By.XPath("//INPUT[@name='ctl00$cntBody$ctlEditView$PROBABILITY']");

        private By SalesStageElem = By.XPath("//SELECT[@name='ctl00$cntBody$ctlEditView$SALES_STAGE']");

        private By CampaignNameElem = By.XPath("//INPUT[@name='ctl00$cntBody$ctlEditView$CAMPAIGN_NAME']");
        
        private By _Save_Elem = By.XPath("//INPUT[@name='ctl00$cntBody$ctlEditView$ctlFooterButtons$btnSAVE']");

        private By _Cancel_Elem = By.XPath("//INPUT[@name='ctl00$cntBody$ctlEditView$ctlFooterButtons$btnCANCEL']");

        private String pageURL = "http://localhost:81/SplendidCRM/Opportunities/edit.aspx";

        public OpportunitiesPage(IWebDriver driver) : base(driver)
        {

        }


        public void GoToUrl()
        {
            m_Driver.Url = pageURL;
        }

        public void AssertURL()
        {
            String currentUrl = m_Driver.Url;

            if (!currentUrl.Equals(pageURL))
            {
                Assert.Fail("Expecting URL - " + pageURL + " Found " + currentUrl);
            }
        }

        /**
         *  @name Name
         * @param Name [name]
         */
        public void Enter_Name(String Name)
        {
            IWebElement elem = getWebElement(NameElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + NameElem.ToString());
            }

            elem.SendKeys(Name);
        }

        /**
         *  @name AccountName
         * @param AccountName [name]
         */
        public void Enter_AccountName(String AccountName)
        {
            IWebElement elem = getWebElement(AccountNameElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + AccountNameElem.ToString());
            }

            elem.SendKeys(AccountName);
        }

        /**
         *  @name OpportunityType
         * @param OpportunityType [select(["--None--","Existing business","New business"])]
         */
        public void Select_OpportunityType(String OpportunityType)
        {
            IWebElement elem = getWebElement(OpportunityTypeElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + OpportunityTypeElem.ToString());
            }
            SelectElement dropdown = new SelectElement(elem);
            dropdown.SelectByText(OpportunityType);
        }

        /**
         *  @name AssignedToName
         * @param AssignedToName [name]
         */
        public void Enter_AssignedToName(String AssignedToName)
        {
            IWebElement elem = getWebElement(AssignedToNameElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + AssignedToNameElem.ToString());
            }

            elem.SendKeys(AssignedToName);
        }

        /**
         *  @name LeadSource
         * @param LeadSource [select(["--None--","Cold call","Existing customer","Self generated","Employee","Partner","Public relations","Direct mail","Conference","Trade show","Web site","Word of mouth","Email","Campaign","Other"])]
         */
        public void Select_LeadSource(String LeadSource)
        {
            IWebElement elem = getWebElement(LeadSourceElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + LeadSourceElem.ToString());
            }
            SelectElement dropdown = new SelectElement(elem);
            dropdown.SelectByText(LeadSource);
        }

        /**
         *  @name Description
         * @param Description [description]
         */
        public void Enter_Description(String Description)
        {
            IWebElement elem = getWebElement(DescriptionElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + DescriptionElem.ToString());
            }

            elem.SendKeys(Description);
        }

        /**
         *  @name CurrencyID
         * @param CurrencyID [select(["--None--","U.S. Dollar: $"])]
         */
        public void Select_CurrencyID(String CurrencyID)
        {
            IWebElement elem = getWebElement(CurrencyIDElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + CurrencyIDElem.ToString());
            }
            SelectElement dropdown = new SelectElement(elem);
            dropdown.SelectByText(CurrencyID);
        }

        /**
         *  @name Amount
         * @param Amount [amount]
         */
        public void Enter_Amount(String Amount)
        {
            IWebElement elem = getWebElement(AmountElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + AmountElem.ToString());
            }
            elem.SendKeys(Amount);
        }

        /**
         *  @name DateClosed
         * @param DateClosed [date]
         */
        public void Enter_DateClosed(String DateClosed)
        {
            IWebElement elem = getWebElement(DateClosedElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + DateClosedElem.ToString());
            }
            elem.SendKeys(DateClosed);
        }

        /**
         *  @name NextStep
         * @param NextStep [text]
         */
        public void Enter_NextStep(String NextStep)
        {
            IWebElement elem = getWebElement(NextStepElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + NextStepElem.ToString());
            }
            elem.SendKeys(NextStep);
        }

        /**
         *  @name Probability
         * @param Probability [probability]
         */
        public void Enter_Probability(String Probability)
        {
            IWebElement elem = getWebElement(ProbabilityElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + ProbabilityElem.ToString());
            }
            elem.SendKeys(Probability);
        }

        /**
         *  @name SalesStage
         * @param SalesStage [select(["--None--","Prospecting","Qualification","Needs analysis","Value proposition","Id. decision makers","Perception analysis","Proposal/price quote","Negotiation/review","Closed won","Closed lost","Other"])]
         */
        public void Select_SalesStage(String SalesStage)
        {
            IWebElement elem = getWebElement(SalesStageElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + SalesStageElem.ToString());
            }

            SelectElement dropdown = new SelectElement(elem);
            dropdown.SelectByText(SalesStage);
        }

        /**
         *  @name CampaignName
         * @param CampaignName [name]
         */
        public void Enter_CampaignName(String CampaignName)
        {
            IWebElement elem = getWebElement(CampaignNameElem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + CampaignNameElem.ToString());
            }
            elem.SendKeys(CampaignName);
        }

        /**
         * @name   Save
         */
        public void Click__Save_()
        {
            IWebElement elem = getWebElement(_Save_Elem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + _Save_Elem.ToString());
            }
            elem.Click();
        }

        /**
         * @name   Cancel
         */
        public void Click__Cancel_()
        {
            IWebElement elem = getWebElement(_Cancel_Elem);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + _Cancel_Elem.ToString());
            }
            elem.Click();
        }
    }
}
