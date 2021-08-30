using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedInLib
{
    public class AccountManager : LinkedInController
    {

        public bool CheckIfLoggedIn() // Changes current page to front page of linkedin
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(30, 150));
            if (driver.Url != "https://www.linkedin.com/feed/") VisitPage("https://www.linkedin.com/");
            else
            {
                logger.Info("You're currently logged in");
                return true;
            }
            if (driver.Url == "https://www.linkedin.com/feed/")
            {
                logger.Info("You're currently logged in");
                return true;
            }
            logger.Info("You're currently logged out");
            Thread.Sleep(rnd.Next(30, 150));
            return false;
        }

        public bool LogIntoLinkedIn(AccountCreditentials account)
        {
            Random rnd = new Random();
            if (CheckIfLoggedIn())
            {
                LogOut();
                driver.Navigate().GoToUrl("http://www.linkedin.com");
            }

            Thread.Sleep(rnd.Next(30, 150));
            var elementLogin = driver.FindElement(By.XPath("//*[@id=\"session_key\"]"));
            elementLogin.SendKeys(account.Email);
            Thread.Sleep(rnd.Next(30, 150));
            var elementPassword = driver.FindElement(By.XPath("//*[@id=\"session_password\"]"));
            elementPassword.SendKeys(account.Password);
            Thread.Sleep(rnd.Next(30, 150));
            var loginButton = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/section[1]/div[2]/form/button"));
            loginButton.Click();

            if (CheckIfLoggedIn())
            {
                logger.Info($"Logged in using: {account.Email}");
                return true;
            }
            else
            {
                logger.Error("Couldn't log in using: {account.email}");
                return false;
            }

        }

        public bool ManuallyLogIntoLinkedIn(string email, string password) // Creates a new webdriver instance that is visible to user, continues after being closed
        {
            IWebDriver manualLogInDriver = new ChromeDriver();
            manualLogInDriver.Navigate().GoToUrl("http://www.linkedin.com");
            logger.Info($"Waiting for user to log in as {email}");
            waitForDriverToClose(manualLogInDriver);
            if(LogIntoLinkedIn(new AccountCreditentials { Email = email, Password = password }))
            {
                logger.Info("logged in successfully");
                return true;
            }
            else
            {
                logger.Info("Could not log in");
                return false;
            }
        }

        private void waitForDriverToClose(IWebDriver driver)
        {
            bool check = false;

            while (!check)
            {

                try
                {
                    if(driver.Url!=null)
                    Thread.Sleep(200);
                }
                catch (Exception e)
                {
                    check = true;
                }

            }
        }

        public bool LogOut()
        {
            return VisitPage("https://www.linkedin.com/m/logout");
        }

        public string GetCurrentAccountName()
        {
            if (!CheckIfLoggedIn())
            {
                return "Was not logged in when getting Account Name";
            }

            var elementProfile = driver.FindElement(By.XPath("//*[@class=\"global-nav__me-photo ghost-person ember-view\"]"));
            string name = elementProfile.GetAttribute("alt");
            logger.Info($"Account name is {name}");
            
            return name;
        }

    }
}
