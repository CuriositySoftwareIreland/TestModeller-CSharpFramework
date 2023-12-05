using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pages
{
    public class BasePage
    {
        protected IWebDriver m_Driver;

        protected WebDriverWait jsWait;

        protected IJavaScriptExecutor jsExec;

        public BasePage(IWebDriver driver)
        {
            m_Driver = driver;

            jsWait = new WebDriverWait(this.m_Driver, new TimeSpan(0, 0, 10));

            jsExec = (IJavaScriptExecutor)this.m_Driver;
        }

        public void passStep(String msg)
        {
            Utilities.TestModellerLogger.PassStep(m_Driver, msg);
        }

        public void passStepWithScreenshot(String msg)
        {
            Utilities.TestModellerLogger.PassStepWithScreenshot(m_Driver, msg);
        }

        public void failStep(String msg)
        {
            Utilities.TestModellerLogger.FailStepWithScreenshot(m_Driver, msg);

            throw new Exception(msg);
        }

        public void failStep(String msg, String details)
        {
            Utilities.TestModellerLogger.FailStepWithScreenshot(m_Driver, msg + "; " + details);

            throw new Exception(msg + "; " + details);
        }

        public RemoteWebElement expandRootElement(IWebElement element)
        {
            RemoteWebElement ele = (RemoteWebElement)((IJavaScriptExecutor)m_Driver).ExecuteScript("return arguments[0].shadowRoot", element);

            return ele;
        }

        protected void clickElement(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)m_Driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        protected void sendKeysElement(IWebElement element, String text)
        {
            clickElement(element);

            element.Clear();

            element.SendKeys(text);
        }

        protected RemoteWebElement expandShadowRoots(List<By> elems)
        {
            if (elems.Count == 0)
                return null;

            RemoteWebElement element = expandRootElement(getWebElement(elems.ElementAt(0)));

            for (int i = 1; i < elems.Count; i++)
            {
                element = expandRootElement(getWebElement(element, elems.ElementAt(i)));
            }

            return element;
        }

        protected IWebElement getWebElement(IWebElement elem, By by)
        {
            waitForLoaded(elem, by, 5);
            waitForVisible(elem, by, 5);

            return elem.FindElement(by);
        }

        protected List<IWebElement> getWebElements(By by)
        {
            waitForLoaded(by, 2);
            waitForVisible(by, 2);

            try
            {
                return new List<IWebElement> (m_Driver.FindElements(by));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        protected void waitForLoaded(IWebElement elem, By by, int waitTime)
        {
            WebDriverWait wait = new WebDriverWait(m_Driver, new TimeSpan(0, 0, waitTime));

            for (int attempt = 0; attempt < waitTime; attempt++)
            {
                try
                {
                    elem.FindElement(by);
                    break;
                }
                catch (Exception e)
                {
                    m_Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 1);
                }
            }
        }

        protected void waitForVisible(IWebElement selem, By by, int waitTime)
        {
            try
            {
                IWebElement elem = selem.FindElement(by);

                WebDriverWait wait = new WebDriverWait(m_Driver, new TimeSpan(0, 0, waitTime));

                wait.Until(m_Driver => elem.Displayed);
            } catch (Exception e) { }

            try
            {
                IWebElement elem = selem.FindElement(by);

                WebDriverWait wait = new WebDriverWait(m_Driver, new TimeSpan(0, 0, waitTime));

                wait.Until(m_Driver => elem.Enabled);
            } catch (Exception e) {

            }

        }

        protected IWebElement getWebElement(By by)
        {
            waitForLoaded(by, 10);
            waitForVisible(by, 10);

            try
            {
                return m_Driver.FindElement(by);
            }
            catch (Exception e)
            {
                return SearchInAllIframes(by);
            }
        }
        protected IWebElement SearchInAllIframes(By by)
        {
            IWebElement element = null;

            // Search for the desired element on the main page
            try
            {
                element = m_Driver.FindElement(by);
                Console.WriteLine("Element found on main page: " + by.ToString());
                return element;
            }
            catch (NoSuchElementException)
            {
                // Element not found on main page
            }

            // Get a list of all iframes on the page
            IList<IWebElement> iframes = m_Driver.FindElements(By.TagName("iframe"));

            // Loop through each iframe and search for the desired element within it
            foreach (IWebElement iframe in iframes)
            {
                try
                {
                    m_Driver.SwitchTo().Frame(iframe);
                }
                catch (Exception)
                {
                    continue;
                }

                try
                {
                    element = m_Driver.FindElement(by);
                    return element;
                }
                catch (NoSuchElementException)
                {
                    // Element not found in iframe
                }

                // Recursively search within any nested iframes
                IWebElement elem = SearchInAllIframes(by);
                if (elem != null)
                    return elem;

                try
                {
                    m_Driver.SwitchTo().DefaultContent();
                }
                catch (Exception) { }
            }

            return null;
        }


        protected void waitForLoaded(By by, int waitTime)
        {
            WebDriverWait wait = new WebDriverWait(m_Driver, new TimeSpan(0, 0, waitTime));

            for (int attempt = 0; attempt < waitTime; attempt++)
            {
                try
                {
                    m_Driver.FindElement(by);
                    break;
                }
                catch (Exception e)
                {
                    m_Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 1);
                }
            }
        }

        protected void waitForVisible(By by, int waitTime)
        {
            IWebElement elem = m_Driver.FindElement(by);

            WebDriverWait wait = new WebDriverWait(m_Driver, new TimeSpan(0, 0, waitTime));

            wait.Until(m_Driver => elem.Displayed);
        }
    }
}
