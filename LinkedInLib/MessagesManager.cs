using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedInLib
{
    public class MessageDetails // TODO: change to struct
    {
        public int Id { get; set; }
        public int Account_fk { get; set; }
        public int Client_fk { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool Sent_by_client { get; set; }
        public bool Read { get; set; }
    }

    public class MessagesManager:LinkedInController
    {
        private bool OpenMessagesWithUser(string profileAddress, bool scrollUp = false)
        {
            //TODO: Check if already opened
            if (driver.Url != profileAddress) VisitPage(profileAddress); // Go to profile page
            try
            {
                // Open chat window
                var sendMessageButton = driver.FindElement(By.XPath("//*[@class=\"message-anywhere-button pvs-profile-actions__action artdeco-button \"]"));
                sendMessageButton.Click();
                Random rnd = new Random();
                System.Threading.Thread.Sleep(rnd.Next(700, 1500));
                if (scrollUp)
                {
                    bool loading = true;
                    while (loading)
                    {

                        var firstMessage = driver.FindElement(By.XPath("//*[contains(@class,'msg-s-message-list__event clearfix')]"));
                        IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                        Thread.Sleep(rnd.Next(30, 50));
                        js.ExecuteScript("arguments[0].scrollIntoView(true); ", firstMessage);
                        Thread.Sleep(rnd.Next(1300, 2300));
                        var newFirstMessage = driver.FindElement(By.XPath("//*[contains(@class,'msg-s-message-list__event clearfix')]"));

                        if (firstMessage.GetAttribute("Id") == newFirstMessage.GetAttribute("Id")) loading = false;
                    }
                    
                }
                

            }
            catch
            {
                logger.Error($"Could not open chat with user {profileAddress}");
                return false;
            }

            return true;
        }

        public bool MessageUser(string profileAddress, string message, int myAccountId, int clientId)
        {
            
            if (message.Length > 0 && message.Length <= 8000) // Check if message is correct (max 8000 char, at least 1 char)
            {
                if (OpenMessagesWithUser(profileAddress))
                {
                    try
                    {
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        var textBox = driver.FindElement(By.XPath("//*[@role=\"textbox\"]"));
                        textBox.Click();
                        textBox.SendKeys(message);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        textBox.SendKeys(Keys.Control + Keys.Enter);
                        Random rnd = new Random();
                        Thread.Sleep(rnd.Next(110, 230));
                        // Check chat if newest message is mine, if it is take closest timestamp
                        string timestamp = CheckMyMessageTimestamp(myAccountId, clientId, message);
                        Message msg = new Message();
                        msg.InsertMessage(new MessageDetails { Account_fk = myAccountId, Client_fk = clientId, Text = message, Date = DateTime.Today.ToString("yyyy-MM-dd"), Time = timestamp, Sent_by_client = false, Read = true });
                        Thread.Sleep(rnd.Next(50, 200));
                        var chatCloseButton = driver.FindElement(By.XPath("//*[@data-control-name=\"overlay.close_conversation_window\"]"));
                        chatCloseButton.Click();
                        return true;
                    }
                    catch (Exception e)
                    {
                        // Log error
                        logger.Error($"Could not successfully send a message to a user {profileAddress} \nerror: {e}");

                        return false;
                    }
                }
            }
            else
            {
                // Message too long/short error
                logger.Error($"Could not send a message to {profileAddress}\nMessage was too long/short ({message.Length})");
                
            }
            return false;
        }

        private string CheckMyMessageTimestamp(int myAccountId, int clientId, string myMessageText) // TODO: make while break after x tries in case it fails (never has so far)
        {
            IReadOnlyCollection<IWebElement> messagesElements = driver.FindElements(By.XPath("//*[contains(@class,'msg-s-message-list__event clearfix')]"));
            var messageText = messagesElements.Last().FindElement(By.XPath(".//*[contains(@class,'msg-s-event-listitem__body t-14 t-black--light')]")).Text;
            Random rnd = new Random();
            while (messageText != myMessageText)
            {
                Thread.Sleep(rnd.Next(50, 120));
                messagesElements = driver.FindElements(By.XPath("//*[contains(@class,'msg-s-message-list__event clearfix')]"));
                messageText = messagesElements.Last().FindElement(By.XPath(".//*[contains(@class,'msg-s-event-listitem__body t-14 t-black--light')]")).Text;
                logger.Info(messageText);
            }

            try
            {
                string messageTimestamp = messagesElements.Last().FindElement(By.XPath(".//*[contains(@class,'msg-s-message-group__timestamp white-space-nowrap t-12 t-black--light t-normal')]")).Text;
                return messageTimestamp;
            }
            catch
            {
                Message message = new Message();
                string messageTimestamp = message.GetNewestMessageTimestamp(myAccountId, clientId);
                return messageTimestamp;
            }
            
            
        }
        
        public List<MessageDetails> RetrieveChatDataWithUser(string profileAddress, AccountCreditentials account, bool oldMessages = false)
        {

            if (OpenMessagesWithUser(profileAddress, true))
            {
                int messageCount = 0;
                string messageSender = null;
                string messageTimestamp = null;
                List<MessageDetails> messages = new List<MessageDetails>();
                Random rnd = new Random();

                // Read messages
                Thread.Sleep(rnd.Next(400, 600));
                IReadOnlyCollection<IWebElement> messagesElements = driver.FindElements(By.XPath("//*[contains(@class,'msg-s-message-list__event clearfix')]"));

                foreach (IWebElement messageElement in messagesElements)
                {
                    // Get text
                    var messageText = messageElement.FindElement(By.XPath(".//*[contains(@class,'msg-s-event-listitem__body t-14 t-black--light')]")).Text;

                    // Try to get sender and timestamp attached to the message
                    try
                    {
                        // Get sender
                        messageSender = messageElement.FindElement(By.XPath(".//*[contains(@class,'msg-s-message-group__name t-14 t-black t-bold hoverable-link-text')]")).Text;
                        // Get timestamp
                        messageTimestamp = messageElement.FindElement(By.XPath(".//*[contains(@class,'msg-s-message-group__timestamp white-space-nowrap t-12 t-black--light t-normal')]")).Text;
                    }
                    catch (NoSuchElementException)
                    {
                        // Message has been sent in a quick succession resulting in no attached sender and timestamp
                        // Previously found elements will be used since they are the current value of those variables
                    }

                    logger.Info($" count:{messageCount} {messageTimestamp} {messageSender}: {messageText}");
                    messageCount++;
                    
                    MessageDetails message = SetMessageValues(account, profileAddress, messageText, messageTimestamp, messageSender, oldMessages);
                    messages.Add(message);
                }
                Thread.Sleep(rnd.Next(1800, 4000));
                var chatCloseButton = driver.FindElement(By.XPath("//*[@data-control-name=\"overlay.close_conversation_window\"]"));
                chatCloseButton.Click();
                return messages;
            }
            logger.Error("Could not open chat");
            return null;
        }

        private MessageDetails SetMessageValues(AccountCreditentials account, string profileAddress, string messageText, string messageTimestamp, string messageSender, bool oldMessages)
        {
            Client client = new Client();
            MessageDetails message = new MessageDetails
            {
                Account_fk = account.Id,
                Client_fk = Convert.ToInt32(client.GetClientId(profileAddress)),
                Text = messageText,
                Date = oldMessages ? DateTime.MinValue.ToString("yyyy-MM-dd") : DateTime.Today.ToString("yyyy-MM-dd"),
                Time = messageTimestamp,
                Sent_by_client = account.Name != messageSender
            };

            return message;
        }

        public bool CheckIfReceivedNewMessage(string profileAddress, AccountCreditentials account)
        {
            logger.Info("Checking for new messages");
            List<MessageDetails> messages = RetrieveChatDataWithUser(profileAddress, account);
            var message = new Message();
            Account_Client account_Client = new Account_Client();
            Client client = new Client();
            if (message.CheckIfMessageExistsInDb(messages.Last()))
            {
                if (message.CheckIfMessageIsRead(messages.Last()))
                {
                    account_Client.SetNotify(account.Id, Convert.ToInt32(client.GetClientId(profileAddress)), false);
                }
                else
                {
                    account_Client.SetNotify(account.Id, Convert.ToInt32(client.GetClientId(profileAddress)), true);
                }

                return false;
            }

            account_Client.SetNotify(account.Id, Convert.ToInt32(client.GetClientId(profileAddress)), true);
            return true;
        }

        public bool GetAndInsertNewMessages(ClientData clientData, AccountCreditentials account) // Additionally checks if DB is missing some messages, if yes return false;
        {
            logger.Info("Getting new messages");
            List<MessageDetails> messages = RetrieveChatDataWithUser(clientData.ProfileAddress, account);
            Message message = new Message();
            Stack<MessageDetails> newMessages = new Stack<MessageDetails>();

            bool reachedOldMessage = false;

            for (int i = messages.Count-1; i >= 0; i--)
            {
                if (!reachedOldMessage && !message.CheckIfMessageExistsInDb(messages[i]))
                {
                    newMessages.Push(messages[i]);
                }
                else reachedOldMessage = true;

                if (reachedOldMessage && !message.CheckIfMessageExistsInDb(messages[i]))
                {
                    logger.Error("Encountered discrepancy between Database messages and chat messages!");
                    return false;
                }
            }

            for (int i = 0; i < newMessages.Count; i++)
            {
                message.InsertMessage(newMessages.Pop());
            }

            return true;
        }

        public bool FixIncorrectData(ClientData clientData, AccountCreditentials accountCreditentials)
        {
            AccountManager accountManager = new AccountManager();
            if (accountManager.LogIntoLinkedIn(accountCreditentials))
            {
                logger.Info($"Fixing discrepancy between account: {accountCreditentials.Id} {accountCreditentials.Name} and client: {clientData.Id} {clientData.Name}");
                //get messages from db
                Message message = new Message();
                List<MessageDetails> messagesDetailsDb = message.SelectMessagesWithClient(accountCreditentials.Id, clientData.Id);
                //get messages from chat
                List<MessageDetails> messagesDetailsChat = RetrieveChatDataWithUser(clientData.ProfileAddress, accountCreditentials);

                //Get dates that were saved in db
                for (int i = 0; i < messagesDetailsDb.Count; i++)
                {
                    for (int j = 0; j < messagesDetailsChat.Count; j++)
                    {
                        if (messagesDetailsDb[i].Sent_by_client == messagesDetailsChat[j].Sent_by_client
                            && messagesDetailsDb[i].Time == messagesDetailsChat[j].Time
                            && messagesDetailsDb[i].Text == messagesDetailsChat[j].Text)
                        {
                            messagesDetailsChat[j].Date = messagesDetailsDb[i].Date;
                            break;
                        }
                    }
                }
                //remove old messages from db
                message.RemoveMessagesWithClient(accountCreditentials.Id, clientData.Id);
                //insert new messages into db
                message.InsertMessages(messagesDetailsChat);

                return true;
            }
            return false;
        }
    }
}


