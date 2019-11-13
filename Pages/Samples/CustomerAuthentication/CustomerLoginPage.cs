using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.CustomerAuthentication
{
    public class CustomerLoginPage : BasePage
    {
        String customerLoginUrl = "https://magento.nublue.co.uk/customer/account/login";

        By emailId = By.Id("email");

        By passwordId = By.Id("pass");

        By loginButtonId = By.Id("send2");

        By forgotPassButtonClass = By.ClassName("action remind");

        By emailErrorId = By.Id("email-error");

        By emptyEmailErrorId = By.Id("email-error");

        By passErrorId = By.Id("pass-error");

        By loginErrorXpath = By.XPath("//*[@id=\"maincontent\"]/div[2]/div[2]/div/div");

        By loggedInWelcomeXpath = By.XPath("/html/body/div[1]/header/div[1]/div/ul/li[1]/span");

        public CustomerLoginPage(IWebDriver driver)
            : base(driver)
        {

        }

        public void goToURL()
        {
            m_Driver.Url = customerLoginUrl;
        }

        public void enterEmail(String email)
        {
            getWebElement(emailId).SendKeys(email);
        }

        public void enterPassword(String password)
        {
            getWebElement(passwordId).SendKeys(password);
        }

        public void submitLogin()
        {
            getWebElement(loginButtonId).Click();
        }

        public void ClickForgotPassword()
        {
            getWebElement(forgotPassButtonClass).Click();
        }

        public void assertInvalidEmail()
        {
            Assert.That(getWebElement(emailErrorId).Displayed);
        }

        public void assertEmptyEmail()
        {
            Assert.That(getWebElement(emailErrorId).Displayed);
        }

        public void assertEmptyPassword()
        {
            Assert.That(getWebElement(passErrorId).Displayed);
        }

        public void assertInvalidLogin()
        {
            Assert.That(getWebElement(loginErrorXpath).Displayed);
        }

        public void assertLoggedIn()
        {

        }
    }
}
