using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedInLib
{
    public struct ClientData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileAddress { get; set; }
        public int AssignedAccount { get; set; }
    }

    public class ClientManager:LinkedInController
    {
        private string GetUserNameFromLink(string profileAddress)
        {
            string userName = "";

            if (profileAddress.Contains("https://www.linkedin.com/in/"))
            {
                userName = profileAddress.Replace("https://www.linkedin.com/in/", "");
            }
            userName = userName.Replace("-", " ");
            userName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userName);

            if (userName.Split(' ').Length - 1 == 2)
            {
                string name = userName.Split(" ")[0];
                string sourname = (userName.Substring(userName.IndexOf(' ') + 1)).Split(" ")[0];
                userName = $"{name} {sourname}";
            }
            else
            {
                userName = userName.Remove(userName.Length - 1);

            }
            return userName;
        } // Doesn't work for users with custom links

        public string GetUserNameFromProfile()
        {
            string userName;

            userName = driver.FindElement(By.XPath("//*[@class=\"text-heading-xlarge inline t-24 v-align-middle break-words\"]"))?.Text;
            logger.Info($"Received user name is: {userName}");
            return userName;
        }

        public string GetUserNameFromProfile(string profileAddress)
        {
            string userName;
            VisitPage(profileAddress);
            userName = driver.FindElement(By.XPath("//*[@class=\"text-heading-xlarge inline t-24 v-align-middle break-words\"]"))?.Text;
            logger.Info($"Received user name is: {userName}");
            return userName;
        }

        public bool InviteUser(string profileAddress) // Send an invite
        {
            Random rnd = new Random();
            
            if(driver.Url != profileAddress) VisitPage(profileAddress);
            // Send Invite
            try
            {

                var inviteButton = LinkedInController.driver.FindElement(By.XPath($"//*[@aria-label=\"Nawiąż kontakt z użytkownikiem {GetUserNameFromProfile()}\"]"));
                inviteButton.Click();
                Thread.Sleep(rnd.Next(50, 200));
                var sendButton = driver.FindElement(By.XPath("//*[@aria-label=\"Wyślij teraz\"]"));
                sendButton.Click();
                
            }
            catch (NoSuchElementException e) // Can be thrown when page loads slowly
            {
                // log error
                logger.Debug($"Error: Could not invite user using method 1 (NoSuchElementException)\nTrying method 2");
                try
                {
                    var moreButton = LinkedInController.driver.FindElement(By.XPath("//*[contains(@class,'artdeco-dropdown__trigger artdeco-dropdown__trigger--placement-bottom ember-view pvs-profile-actions__action artdeco-button artdeco-button--secondary artdeco-button--muted')]"));
                    moreButton.Click();
                    Thread.Sleep(rnd.Next(20, 100));
                    var contactButton = LinkedInController.driver.FindElement(By.XPath("//*[contains(@data-control-name,'connect')]"));
                    contactButton.Click();
                    Thread.Sleep(rnd.Next(20, 100));
                    var connectWithButton = LinkedInController.driver.FindElement(By.XPath("//*[contains(@class,'mr2 artdeco-button artdeco-button--muted artdeco-button--2 artdeco-button--secondary ember-view')]"));
                    connectWithButton.Click();
                    Thread.Sleep(rnd.Next(20, 100));
                    var sendButton = driver.FindElement(By.XPath("//*[@aria-label=\"Wyślij teraz\"]"));
                    sendButton.Click();
                
                }
                catch (Exception ex)
                {
                    logger.Debug($"Error: Could not invite user using method 2 Exception:\n{ex}");
                    return false;
                }
                
            }
            logger.Info($"Succesfully invited {profileAddress}");
            return true;
        }

        public bool InviteUser(string profileAddress, string message) // Send an invite with custom message
        {
            Random rnd = new Random();
            if (driver.Url != profileAddress) VisitPage(profileAddress);
            
            if (message.Length > 0 && message.Length <= 300) // Check if message is correct (max 300 char, at least 1 char) check for null
            {
                // Send Invite
                try
                {
                    var InviteButton = driver.FindElement(By.XPath($"//*[@aria-label=\"Nawiąż kontakt z użytkownikiem {GetUserNameFromProfile()}\"]"));
                    InviteButton.Click();
                    Thread.Sleep(rnd.Next(50, 200));
                    var addNoteButton = driver.FindElement(By.XPath("//*[@aria-label=\"Dodaj notatkę\"]"));
                    addNoteButton.Click();

                    var textArea = driver.FindElement(By.XPath("//*[@id=\"custom-message\"]"));
                    textArea.Click();
                    Thread.Sleep(rnd.Next(50, 200));
                    textArea.SendKeys(message);
                    var sendButton = driver.FindElement(By.XPath("//*[@aria-label=\"Wyślij teraz\"]"));
                    sendButton.Click();
                }
                catch (NoSuchElementException e) // Can be thrown when page loads slowly
                {
                    // log error
                    logger.Debug($"Error: Could not invite user using method 1(message) (NoSuchElementException)\nTrying method 2");
                    try
                    {
                        var moreButton = LinkedInController.driver.FindElement(By.XPath("//*[contains(@class,'artdeco-dropdown__trigger artdeco-dropdown__trigger--placement-bottom ember-view pvs-profile-actions__action artdeco-button artdeco-button--secondary artdeco-button--muted')]"));
                        moreButton.Click();
                        Thread.Sleep(rnd.Next(25, 200));
                        var contactButton = LinkedInController.driver.FindElement(By.XPath("//*[contains(@data-control-name,'connect')]"));
                        contactButton.Click();
                        Thread.Sleep(rnd.Next(20, 150));
                        var connectWithButton = LinkedInController.driver.FindElement(By.XPath("//*[contains(@class,'mr2 artdeco-button artdeco-button--muted artdeco-button--2 artdeco-button--secondary ember-view')]"));
                        connectWithButton.Click();
                        var addNoteButton = driver.FindElement(By.XPath("//*[@aria-label=\"Dodaj notatkę\"]"));
                        addNoteButton.Click();
                        Thread.Sleep(rnd.Next(30, 100));
                        var textArea = driver.FindElement(By.XPath("//*[@id=\"custom-message\"]"));
                        textArea.Click();
                        textArea.SendKeys(message);
                        Thread.Sleep(rnd.Next(50, 200));
                        var sendButton = driver.FindElement(By.XPath("//*[@aria-label=\"Wyślij teraz\"]"));
                        sendButton.Click();

                    }
                    catch (Exception ex)
                    {
                        logger.Debug($"Error: Could not invite user using method 2(message) Exception:\n{ex}");
                        return false;
                    }

                }
                logger.Info($"Succesfully invited {profileAddress}");
                return true;
            }
            else
            {
                //message too long/short error
                logger.Error("Message too long/short");
                return false;
            }
        }

        public bool CheckIfInviteSent(string clientName)
        {
            const string sentInvitesPageAddress = "https://www.linkedin.com/mynetwork/invitation-manager/sent/";
            if (driver.Url != sentInvitesPageAddress) VisitPage(sentInvitesPageAddress);

            var nameElements = driver.FindElements(By.XPath("//*[@class=\"text-heading-xlarge inline t-24 v-align-middle break-words\"]"));
            foreach (var name in nameElements)
            {
                if (name.Text == clientName) return true;
            }
            return false;
        }
    }
}
