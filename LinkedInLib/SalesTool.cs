using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInLib
{
    public enum Status
    {
        Error = 1,
        NotFriends = 2,
        InviteSent = 3,
        InviteAccepted = 4,
        InitialMessageSent = 5,
        FollowupSent = 6,
        ContactFailed = 7,
        ManualContact = 8
    }

    public struct Timers
    {
        public TimeSpan TimeBeforeInitialMessage { get; set; } // Length of time to wait before sending an initial message
        public TimeSpan TimeBeforeFollowupMessage { get; set; } // Length of time to wait before sending a followup message
        public TimeSpan TimeAfterFollowupMessage { get; set; }  // Length of time the tool will be checking the client after sending a followup message

        public TimeSpan ToolStartTime { get; set; } // Time of the day at which the tool will start
        public TimeSpan ToolStopTime { get; set; }  // Time of the day at which the tool will stop
    }

    public class SalesTool
    {
        Timers timers;
        string[] messageValues = new string[4];

        public SalesTool()
        {
            timers.TimeBeforeInitialMessage = new TimeSpan(4, 0, 25, 0);
            timers.TimeBeforeFollowupMessage = new TimeSpan(4, 0, 25, 0);
            timers.TimeAfterFollowupMessage = new TimeSpan(7, 3, 0, 0);

            timers.ToolStartTime = new TimeSpan(7, 0, 0);
            timers.ToolStopTime = new TimeSpan(18, 0, 0);
        }

        public SalesTool(Timers timer, string[] messages)
        {
            timers = timer;
            messageValues = messages;
        }

        private void NoStatusSet(AccountCreditentials accountCreditentials, ClientData clientData) // Does initial check to assign proper status
        {
            var linkedInController = new LinkedInController();
            ClientManager inviteSender = new ClientManager();
            Account_Client accountClient = new Account_Client();
            bool friendsStatus = linkedInController.CheckIfFriends(clientData.ProfileAddress);

            if (friendsStatus)
            {
                accountClient.SetInviteAccepted(accountCreditentials.Id, clientData.Id, friendsStatus);
                accountClient.ChangeSystemStatus(accountCreditentials.Id, clientData.Id, (int)Status.InviteAccepted);
                MessagesManager messagesManager = new MessagesManager();
                // Get chat history and insert into db
                // Set all dates to e.g. 0.0.0 0:0:0, so you can show that those were sent before starting the tool
                List<MessageDetails> messagesDetails = messagesManager.RetrieveChatDataWithUser(clientData.ProfileAddress, accountCreditentials, true); 
                
                Message message = new Message();
                message.InsertMessages(messagesDetails);
            }
            else
            {
                inviteSender = new ClientManager();
                if (inviteSender.CheckIfInviteSent(clientData.Name)) // not friends -> if invite sent -> change status
                    accountClient.ChangeSystemStatus(accountCreditentials.Id, clientData.Id, (int)Status.InviteSent);
                else accountClient.ChangeSystemStatus(accountCreditentials.Id, clientData.Id, (int)Status.NotFriends);
            }
        }

        void SyncClient(AccountCreditentials accountCreditentials, ClientData clientData)
        {
           
            // IAccount_Client iaccountClient = new Account_Client();
            Account_Client accountClient = new Account_Client();
            var client = new Client();

            if (clientData.AssignedAccount == -1) // If marked for assignment, assign current account
            {
                client.AssignAccountToClient(accountCreditentials.Id, clientData.Id);
                clientData.AssignedAccount = accountCreditentials.Id;
            }
            
            var currentClientStatus = accountClient.GetSystemStatusId(accountCreditentials.Id, clientData.Id); // Gets current status
            if (clientData.AssignedAccount == 0) // If client was marked as completed, do nothing
            {
                LinkedInController.logger.Info("Client was marked as completed, skipping");
                return;
            }

            if(clientData.AssignedAccount == accountCreditentials.Id)
            {
                LinkedInController.logger.Info($"Client status before is: {currentClientStatus}");
                switch (currentClientStatus)    //use enum not string => solved by using struct with const strings => changed into enum after database changes
                {
                    case (int)Status.Error:
                        // If friends -> change status
                        NoStatusSet(accountCreditentials, clientData);
                        break;

                    case (int)Status.NotFriends:
                        // Send invite and change status
                        ClientManager inviteSender = new ClientManager();
                        if(inviteSender.InviteUser(clientData.ProfileAddress)) 
                            accountClient.ChangeSystemStatus(accountCreditentials.Id, clientData.Id, (int)Status.InviteSent);
                        break;

                    case (int)Status.InviteSent:
                        // If invite accepted -> change status
                        LinkedInController linkedInController = new LinkedInController();
                        if(linkedInController.CheckIfFriends(clientData.ProfileAddress)) 
                            accountClient.ChangeSystemStatus(accountCreditentials.Id, clientData.Id, (int)Status.InviteAccepted);
                        break;

                    case (int)Status.InviteAccepted:
                        // If time passed -> send initial message -> change status
                        var messagesManager = new MessagesManager();
                        if (TimePassedSinceLastStatusUpdate(accountCreditentials.Id, clientData.Id) >timers.TimeBeforeInitialMessage)
                        {
                            if(messagesManager.MessageUser(clientData.ProfileAddress, accountCreditentials.Special ? messageValues[2] : messageValues[0], accountCreditentials.Id, clientData.Id))
                            {
                                accountClient.ChangeSystemStatus(accountCreditentials.Id, clientData.Id, (int)Status.InitialMessageSent);
                            }
                        }
                        break;

                    case (int)Status.InitialMessageSent:
                        // If answered -> change status and notify
                        messagesManager = new MessagesManager();
                        if (messagesManager.CheckIfReceivedNewMessage(clientData.ProfileAddress, accountCreditentials))
                        {
                            if(!messagesManager.GetAndInsertNewMessages(clientData, accountCreditentials)) messagesManager.FixIncorrectData(clientData, accountCreditentials);
                            accountClient.ChangeSystemStatus(accountCreditentials.Id, clientData.Id, (int)Status.ManualContact); 
                        }
                        else    // If time passed -> send a followup -> change status
                        {

                            if (TimePassedSinceLastStatusUpdate(accountCreditentials.Id, clientData.Id) > timers.TimeBeforeFollowupMessage)
                                if (messagesManager.MessageUser(clientData.ProfileAddress, accountCreditentials.Special ? messageValues[3] : messageValues[1], accountCreditentials.Id, clientData.Id))
                                    accountClient.ChangeSystemStatus(accountCreditentials.Id, clientData.Id, (int)Status.FollowupSent);
                        }
                        break;

                    case (int)Status.FollowupSent:
                        // If answered -> change status and notify
                        messagesManager = new MessagesManager();
                        if (messagesManager.CheckIfReceivedNewMessage(clientData.ProfileAddress, accountCreditentials))
                        {
                            if(!messagesManager.GetAndInsertNewMessages(clientData, accountCreditentials)) messagesManager.FixIncorrectData(clientData, accountCreditentials); ;
                            accountClient.ChangeSystemStatus(accountCreditentials.Id, clientData.Id, (int)Status.ManualContact);
                            
                        }
                        else    // If time passed -> change status
                        {
                            if (TimePassedSinceLastStatusUpdate(accountCreditentials.Id, clientData.Id) > timers.TimeAfterFollowupMessage)
                            {
                                accountClient.ChangeSystemStatus(accountCreditentials.Id, clientData.Id, (int)Status.ContactFailed);
                                Account account = new Account();
                                if (account.GetAllAccountsCreditentials().Last().Id == accountCreditentials.Id) // If last account
                                    client.AssignAccountToClient(accountCreditentials.Id, 0); // true -> delete client mark as failed (value 0)
                                else client.AssignAccountToClient(accountCreditentials.Id, -1); // alse -> mark for assignment of new account (value -1)
                            }
                        }
                        break;

                    case (int)Status.ContactFailed:
                        // Check if tried on every account->delete client? || do nothing || check for answer but rarely
                        messagesManager = new MessagesManager();
                        if (messagesManager.CheckIfReceivedNewMessage(clientData.ProfileAddress, accountCreditentials))
                        {
                            if(!messagesManager.GetAndInsertNewMessages(clientData, accountCreditentials)) messagesManager.FixIncorrectData(clientData, accountCreditentials);
                            accountClient.ChangeSystemStatus(accountCreditentials.Id, clientData.Id, (int)Status.ManualContact);
                        }
                        break;

                    case (int)Status.ManualContact:
                        // Check if received new message -> notify
                        messagesManager = new MessagesManager();
                        if (messagesManager.CheckIfReceivedNewMessage(clientData.ProfileAddress, accountCreditentials))
                        {
                            if(!messagesManager.GetAndInsertNewMessages(clientData, accountCreditentials)) messagesManager.FixIncorrectData(clientData, accountCreditentials); ;
                        }
                        break;
                }
                
            }
            else
            {
                LinkedInController.logger.Info("Client assigned to a different account");
                return;
            }
            currentClientStatus = accountClient.GetSystemStatusId(accountCreditentials.Id, clientData.Id); // Gets current status
            LinkedInController.logger.Info($"Client status after is: {currentClientStatus}");
        }

        public void SyncAllClientsFromEveryAccount()
        {
            if (CheckIfToolWorkHours())
            {
                LinkedInController.logger.Info($"Starting sync for nonspecial accounts");
                CallSyncForAccountsMarkedSpecial(false);
                LinkedInController.logger.Info($"Starting sync for special accounts");
                CallSyncForAccountsMarkedSpecial(true);

            }
            LinkedInController.logger.Info($"Synchronisation finished");
        }

        private void CallSyncForAccountsMarkedSpecial(bool special = false)
        {
            // Get all accounts
            var account = new Account();
            List<AccountCreditentials> accounts = account.GetAllAccountsCreditentials();

            // Get all clients
            var client = new Client();
            List<ClientData> clientDatas = clientDatas = client.GetAllClientsData();

            var accountManager = new AccountManager();
            foreach (var accountCreditentials in accounts)
            {
                if(accountCreditentials.Special == special)
                {
                    accountManager.LogIntoLinkedIn(accountCreditentials);
                    for (int i = 0; i < clientDatas.Count; i++)
                    {
                        LinkedInController.logger.Info($"Account email: {accountCreditentials.Email} Synchronising for client id: {clientDatas[i].Id} ");
                        SyncClient(accountCreditentials, clientDatas[i]);
                    }
                    accountManager.LogOut();
                }
            }

        }

        public TimeSpan TimePassedSinceLastStatusUpdate(int myAccountId, int clientId) // Returns how much time has passed since last status update
        {
            TimeSpan timeSpan = DateTime.Now - Account_Client.GetStatusChangedDate(myAccountId, clientId);
            LinkedInController.logger.Info($"Time since last status change: {timeSpan}");
            return timeSpan;
        }

        private bool CheckIfToolWorkHours()
        {
            if (DateTime.Now.TimeOfDay > timers.ToolStartTime && DateTime.Now.TimeOfDay < timers.ToolStopTime) return true;
            return false;
        }

    }
}