using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using SeleniumExtras;
using SeleniumExtras.WaitHelpers;
using System.Globalization;
using log4net.Config;
using log4net;
using System.Collections.Generic;
using CsvHelper;

namespace LinkedInLib
{
    // Required packages: log4net, csvHelper, npgsql, selenium.webdriver, selenium.webdriver.chromedriver
    public class LinkedInController
    {
        public static IWebDriver driver;

        public static ILog logger = LogManager.GetLogger(typeof(LinkedInController)); // Requires Log4Net

        static bool mainDriverLaunched = false;
        
        public LinkedInController(bool headless = true)
        {
            if (!mainDriverLaunched)
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                if (headless)
                {
                    chromeOptions.AddArgument("--disable-extensions");
                    chromeOptions.AddArgument("--disable-gpu");
                    chromeOptions.AddArgument("--headless");
                }
                driver = new ChromeDriver(chromeOptions);
                driver.Manage().Timeouts().ImplicitWait = new TimeSpan(50);
                mainDriverLaunched = true;
            }
            
        }

        public void ConfigureLogger()
        {
            BasicConfigurator.Configure();
        }

        public bool VisitPage(string pageAddress) // Visit linked page
        {
            if (driver.Url != pageAddress)
            {
                driver.Navigate().GoToUrl(pageAddress);
                logger.Info($"Visited url: {pageAddress}");
                return true;
            }
            logger.Info($"You tried to visit current page! (if you wanted to refresh use driver.Navigate().Refresh())");
            return false;
        }

        public List<string> GetProfilesFromCSV(string fileName)
        {
            List<string> profileAddresses = new List<string>();

            using var streamReader = File.OpenText(fileName);
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

            while (csvReader.Read())
            {
                profileAddresses.Add(csvReader.GetField(0));
            }

            return profileAddresses;
        }

        public bool CheckIfFriends(string profileAddress)
        {
            VisitPage(profileAddress);
            try
            {
                var elementLogin = driver.FindElement(By.XPath("//*[@type=\"person-remove-icon\"]"));
                logger.Info($"You are currently friends with {profileAddress}");
                return true;
            }
            catch(NoSuchElementException e)
            {
                logger.Info($"You are currently not friends with {profileAddress}");
                return false;
            }
        }

        public bool StopDriver()
        {
            driver.Quit();
            return true;
        }

    }
}
