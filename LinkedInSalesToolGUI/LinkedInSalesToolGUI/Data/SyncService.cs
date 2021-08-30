using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkedInLib;

namespace LinkedInSalesToolGUI.Data
{
    public class SyncService
    {
        public Task<bool> Synchronise(Timers timers, string[] messageValues)
        {
            SalesTool salesTool = new SalesTool(timers, messageValues);
            salesTool.SyncAllClientsFromEveryAccount();
            return Task.FromResult(true);
        }
    }
}
