using CuriositySoftware.TestModeller;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.CustomerAuthentication
{
    public class CustomerRegistrationPage : BasePage
    {
        String customerRegistrationUrl = "https://magento.nublue.co.uk/customer/account/create/";

        By firstNameFieldId = By.Id("firstname");

        By firstNameErrorLabelId = By.Id("firstname-error");

        By lastNameFieldId = By.Id("lastname");

        By lastNameErrorLabelId = By.Id("lastname-error");

        By subscribeId = By.Id("is_subscribed");

        By emailId = By.Id("email_address");

        By emailErrorId = By.Id("email_address-error");

        By passwordId = By.Id("password");

        By passwordErrorId = By.Id("password-error");

        By passwordConfirmationId = By.Id("password-confirmation");

        By passwordConfirmationErrorId = By.Id("password-confirmation-error");

        By createAccountClassName = By.ClassName("submit");

        public CustomerRegistrationPage(IWebDriver driver)
            : base(driver)
        {

        }


        public void goToURL()
        {
            m_Driver.Url = customerRegistrationUrl;
        }

        public void enterFirstName(String firstname)
        {
            getWebElement(firstNameFieldId).SendKeys(firstname);
        }

        public void assertFirstNameError()
        {
            Assert.That(getWebElement(firstNameErrorLabelId).Displayed);
        }

        public void enterLastName(String lastname)
        {
            getWebElement(lastNameFieldId).SendKeys(lastname);
        }

        public void assertLastNameError()
        {
            Assert.That(getWebElement(lastNameErrorLabelId).Displayed);
        }

        public void signUpNewsLetter(Boolean signup)
        {
            getWebElement(subscribeId).Click();
        }

        public void enterEmail(String email)
        {
            getWebElement(emailId).SendKeys(email);
        }

        public void assertEmailError()
        {
            Assert.That(getWebElement(emailErrorId).Displayed);
        }

        public void enterPassword(String password)
        {
            getWebElement(passwordId).SendKeys(password);
        }

        public void assertPasswordError()
        {
            Assert.That(getWebElement(emailErrorId).Displayed);
        }

        public void enterConfirmPassword(String password)
        {
            getWebElement(passwordConfirmationId).SendKeys(password);
        }

        public void assertPasswordConfirmationError()
        {
            Assert.That(getWebElement(passwordConfirmationErrorId).Displayed);
        }

        public void submitCreateAccount()
        {
            getWebElement(createAccountClassName).Click();
        }
    }
}
