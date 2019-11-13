using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModellerCSharp.Pages.Samples.Splendid
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        private By UsernameInput = By.XPath("//INPUT[@name='ctl00$cntBody$ctlLoginView$txtUSER_NAME']");

        private By PasswordInput = By.XPath("//INPUT[@name='ctl00$cntBody$ctlLoginView$txtPASSWORD']");

        private By LoginButton = By.XPath("//INPUT[@name='ctl00$cntBody$ctlLoginView$btnLogin']");

        private By Invalid_User_Name_and_Password = By.XPath("//SPAN[text()='Invalid User Name and Password.']");

        private String pageURL = "http://localhost:81/SplendidCRM/Users/Login.aspx";

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
         * @name UsernameInput
         * @param value [username]
         */
        public void Enter_UsernameInput(String value)
        {
            IWebElement elem = getWebElement(UsernameInput);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + UsernameInput.ToString());
            }
            elem.SendKeys(value);
        }

        /**
         * @name PasswordInput
         * @param value [password]
         */
        public void Enter_PasswordInput(String value)
        {
            IWebElement elem = getWebElement(PasswordInput);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + PasswordInput.ToString());
            }
            elem.SendKeys(value);
        }

        /**
         * @name LoginButton
         */
        public void Click_LoginButton()
        {
            IWebElement elem = getWebElement(LoginButton);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + LoginButton.ToString());
            }

            elem.Click();
        }

        /**
         * @name Invalid User Name and Password.
         */
        public void Assert_Invalid_User_Name_and_Password()
        {
            IWebElement elem = getWebElement(Invalid_User_Name_and_Password);
            if (elem == null)
            {
                Assert.Fail("Unable to locate object: " + Invalid_User_Name_and_Password.ToString());
            }
        }
    }
}
