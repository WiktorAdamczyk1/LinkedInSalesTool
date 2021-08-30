using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkedInLib;
using System.Globalization;

namespace LinkedInSalesToolGUI.Data
{
    public class DatabaseService
    {
        public void StartLogger()
        {
            var liController = new LinkedInController();
            liController.ConfigureLogger();
        }

        public Task<List<AccountCreditentials>> GetAccountsAsync()
        {
            var databseManager = new DatabaseManager();
            var account = new Account();
            return Task.FromResult(account.GetAllAccountsCreditentials());
        }

        public Task<List<ClientData>> GetClientsAsync()
        {
            var databseManager = new DatabaseManager();
            var client = new Client();
            return Task.FromResult(client.GetAllClientsData());
        }

        public async Task<bool> ImportClientsFromCSVAsync(List<string> profileAddresses, bool checkForName = true)
        {
            var databseManager = new DatabaseManager();
            var client = new Client();
            var inviteSender = new ClientManager();
            var accountManager = new AccountManager();
            Account account = new Account();
            if (checkForName)
            {
                AccountCreditentials accountCreditentials = account.GetAccountCreditentials(account.GetFirstAccountCreditentials().Id); // Change 1 to first account in db
                if (accountCreditentials.Id == 0) throw new Exception("Account doesn't exist, add account first!");
                accountManager.LogIntoLinkedIn(accountCreditentials);
            }
            // Get all accounts
            List<AccountCreditentials> accountsCreditentials = account.GetAllAccountsCreditentials();
            foreach (var profileAddress in profileAddresses)
            {
                if (! (await CheckIfClientExistsInDb(profileAddress)))
                {
                    if (checkForName)
                    {
                        var name = inviteSender.GetUserNameFromProfile(profileAddress);
                        client.InsertClient(profileAddress, name);
                    }
                    else
                    {
                        client.InsertClient(profileAddress);
                    }
                    //create account_client link with every account
                    Account_Client account_Client = new Account_Client();
                    foreach (var accountCred in accountsCreditentials)
                    {
                        account_Client.InsertAccountClient(accountCred.Id, Convert.ToInt32(client.GetClientId(profileAddress)));
                    }

                }
                
            }

            return true;
        }

        public Task<bool> AddClientAsync(string profileAddress, bool checkForName = false)
        {

            var databseManager = new DatabaseManager();
            var client = new Client();
            var inviteSender = new ClientManager();
            var accountManager = new AccountManager();
            Account account = new();

            if (checkForName)
            {
                AccountCreditentials accountCreditentials = account.GetAccountCreditentials(1);
                if (accountCreditentials.Id == 0) throw new Exception("Account doesn't exist, choose a different account for name checking in the settings");
                accountManager.LogIntoLinkedIn(accountCreditentials);
                client.InsertClient(profileAddress, inviteSender.GetUserNameFromProfile(profileAddress));
            }
            else client.InsertClient(profileAddress);
            


            return Task.FromResult(true);
        }

        public Task<bool> RemoveClientAsync(int id)
        {
            var databaseManager = new DatabaseManager();
            var client = new Client();
            var account = new Account();
            var message = new Message();
            var account_Client = new Account_Client();
            
            account_Client.RemoveAccountClientUsingClientId(id);
            foreach (var accountCreditentials in account.GetAllAccountsCreditentials())
            {
                message.RemoveMessagesWithClient(accountCreditentials.Id, id);
            }
            
            client.RemoveClient(id);
            return Task.FromResult(true);
        }

        public Task<bool> RemoveAccountAsync(int id)
        {
            var databaseManager = new DatabaseManager();
            var client = new Client();
            var account = new Account();
            var message = new Message();
            var account_Client = new Account_Client();

            account_Client.RemoveAccountClientUsingAccountId(id);
            foreach (var clientData in client.GetAllClientsData())
            {
                message.RemoveMessagesWithClient(id, clientData.Id);
                if (id == clientData.AssignedAccount) client.ReassignClientAfterAccountDeletition(clientData);
                
            }
            account.RemoveAccount(id);

            

            return Task.FromResult(true);
        }

        public Task<string> GetAccountName(string email, string password)
        {
            AccountManager accountManager = new();
            string name = null;
            bool success = false;
            if(!accountManager.LogIntoLinkedIn(new AccountCreditentials { Email = email, Password = password }))
            {
                // Couldn't log in, log in manually and then try again automatically
                if(accountManager.ManuallyLogIntoLinkedIn(email, password))
                {
                    name = accountManager.GetCurrentAccountName();
                    success = true;
                }
                else
                {
                    //Couldn't log in automatically even after manual log in, try again prompt
                }
            }
            else
            {
                name = accountManager.GetCurrentAccountName();
                success = true;
            }
            return success? Task.FromResult(name) : Task.FromResult("Failed");
        }

        public Task<bool> TestAccountLogIn(string email, string password)
        {
            AccountManager accountManager = new();
            bool success = false;
            if (!accountManager.LogIntoLinkedIn(new AccountCreditentials { Email = email, Password = password }))
            {
                // Couldn't log in, log in manually and then try again automatically
                if (accountManager.ManuallyLogIntoLinkedIn(email, password))
                {
                    success = true;
                }
                else
                {
                    //Couldn't log in automatically even after manual log in, try again prompt
                }
            }
            else
            {
                success = true;
            }

            return Task.FromResult(success);
        }

        public Task<bool> InsertAccount(string email, string password, string name, bool special)
        {
            var databaseManager = new DatabaseManager();
            var account = new Account();
            account.InsertAccount(email, password, name, special);
            Client client = new Client();
            // Get all clients
            List<ClientData> clientDatas = client.GetAllClientsData();
            Account_Client account_Client = new Account_Client();
            foreach (var clientData in clientDatas) // Foreach client insert account_client with this account
            {
                account_Client.InsertAccountClient(account.GetAccountId(email), clientData.Id);
            }
            
            return Task.FromResult(true);
        }

        public Task<bool> CheckDatabaseConnection(string server, string database, string port, string username, string password)
        {
            DatabaseManager databaseManager = new DatabaseManager(server, database, port, username, password);
            return Task.FromResult(databaseManager.ValidConnectionTest());
        }

        public Task<int> GetUserStatusId(int myAccountId, int clientId)
        {
            var databaseManager = new DatabaseManager();
            Account_Client account_Client = new Account_Client();
            int id = account_Client.GetUserStatusId(myAccountId, clientId);
            return Task.FromResult(account_Client.GetUserStatusIndex(id));
        }

        public Task<int> GetUserStatusId(string status)
        {
            var databaseManager = new DatabaseManager();
            Account_Client account_Client = new Account_Client();
            return Task.FromResult(account_Client.GetUserStatusId(status));
        }

        public Task<int> GetSystemStatusId(int myAccountId, int clientId)
        {
            var databaseManager = new DatabaseManager();
            Account_Client account_Client = new Account_Client();
            return Task.FromResult(account_Client.GetSystemStatusId(myAccountId, clientId));
        }

        public Task<List<string>> GetUserStatusesStrings()
        {
            Account_Client account_Client = new Account_Client();
            List<string> result = new List<string> { "Unassigned" };
            result.AddRange(account_Client.GetUserStatusesStrings());
            return Task.FromResult(result);
        }

        public Task<List<string>> GetSystemStatusesStrings()
        {
            Account_Client account_Client = new Account_Client();
            return Task.FromResult(account_Client.GetSystemStatusesStrings());
        }

        public Task<bool> UnassignUserStatus(int myAccountId, int clientId)
        {
            Account_Client account_Client = new Account_Client();
            return Task.FromResult(account_Client.UnassignUserStatus(myAccountId, clientId));
        }

        public Task<bool> ChangeUserStatus(int myAccountId, int clientId, int userStatus)
        {
            Account_Client account_Client = new Account_Client();
            return Task.FromResult(account_Client.ChangeUserStatus(myAccountId, clientId, userStatus));
        }

        public Task<bool> InsertUserStatus(string userStatus)
        {
            Account_Client account_Client = new Account_Client();
            return Task.FromResult(account_Client.InsertUserStatus(userStatus));
        }

        public Task<List<MessageDetails>> GetMessages(int myAccountId, int cliendId)
        {
            var databaseManager = new DatabaseManager();
            Message message = new Message();
            return Task.FromResult(message.SelectMessagesWithClient(myAccountId, cliendId));
        }

        public Task<bool> SendMessage(AccountCreditentials accountCreditentials, int clientId, string messageText)
        {
            MessagesManager messagesManager = new MessagesManager();
            AccountManager accountManager = new AccountManager();
            accountManager.LogIntoLinkedIn(accountCreditentials);
            Client client = new Client();
            
            var success = messagesManager.MessageUser(client.GetClientProfileAddress(clientId), messageText, accountCreditentials.Id, clientId);

            return Task.FromResult(success);

        }

        public Task<bool> CheckIfAccountExistsInDb(string email)
        {
            Account account = new Account();
            return Task.FromResult(account.CheckIfAccountAlreadyAdded(email));
        }

        public Task<bool> CheckIfClientExistsInDb(string profileAddress)
        {
            Client client = new Client();
            return Task.FromResult(client.CheckIfClientAlreadyAdded(profileAddress));
        }

        public Task<List<ClientData>> CheckNotificationsForAccount(int myAccountId)
        {
            Account_Client account_Client = new Account_Client();
            Client client = new Client();
            List<ClientData> clientDatas = client.GetAllClientsData();
            for (int i = 0; i<clientDatas.Count;)
            {
                if (!account_Client.GetNotify(myAccountId, clientDatas[i].Id))
                {
                    clientDatas.RemoveAt(i);
                }
                else i++;
            }
            
            return Task.FromResult(clientDatas);
        }

        public Task<bool> CheckIfClientNotify(int clientId)
        {
            Account_Client account_Client = new();
            return Task.FromResult(account_Client.CheckIfClientNotify(clientId));
        }

        public Task<bool> CheckIfAccountNotify(int myAccountId)
        {
            Account_Client account_Client = new();
            return Task.FromResult(account_Client.CheckIfAccountNotify(myAccountId));
        }

        public bool CheckNotify(int myAccountId, int clientId)
        {
            Account_Client account_Client = new();
            return account_Client.GetNotify(myAccountId, clientId);
        }

        public Task SetNotify(int myAccountId, int clientId, bool notify)
        {
            Account_Client account_Client = new();
            account_Client.SetNotify(myAccountId, clientId, notify);

            return Task.CompletedTask;
        }

        public Task FixIncorrectData(ClientData clientData, AccountCreditentials accountCreditentials)
        {
            MessagesManager messagesManager = new MessagesManager();
            messagesManager.FixIncorrectData(clientData, accountCreditentials);
            return Task.CompletedTask;
        }

        public Task<bool> RemoveUserStatus(string status)
        {
            Account_Client account_Client = new Account_Client();
            return Task.FromResult(account_Client.RemoveUserStatus(status));
        }
    }
}
