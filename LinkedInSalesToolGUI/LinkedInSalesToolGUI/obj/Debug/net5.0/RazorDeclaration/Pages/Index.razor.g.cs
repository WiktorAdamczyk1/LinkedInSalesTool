// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace LinkedInSalesToolGUI.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using LinkedInSalesToolGUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using LinkedInSalesToolGUI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Index.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Index.razor"
using LinkedInSalesToolGUI.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Index.razor"
using LinkedInLib;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 65 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Index.razor"
         
    bool databaseConnectionCreated = false;
    List<ClientData> clientDatas = new List<ClientData>();
    Account account = new Account();
    int amountOfNotifications = 0;

    string[] currentMessageInputValues = new string[4];
    DateTime[] dateTimes = new DateTime[2];
    int[] timeSpans = new int[3];
    string[] databaseConnection = new string[5];
    readonly List<string> messageVariableNames = new List<string>() { "Initial Message", "Followup Message", "Special Account Initial Message", "Special Account Followup Message" };
    readonly List<string> timeVariableNames = new List<string>() { "Tool start time", "Tool stop time" };
    readonly List<string> daysVariableNames = new List<string>() { "Time before Initial message", "Time before Followup message", "Time after Followup message" };
    readonly List<string> databaseVariableNames = new List<string>() { "server", "database", "port", "username", "password" };

    System.Timers.Timer t;
    DateTime syncTimer;
    Timers timers;
    bool isSyncLoopOn = false;
    bool isCurrentlySyncing = false;
    bool showAlert = false;

    protected override async Task OnInitializedAsync()
    {

    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            StateHasChanged();
            await ReadSettingsForSync(); // TODO: move out of if, add statechanged inside
            CreateDatabaseConnection();
            databaseConnectionCreated = true;
            await ReadSyncTimer();
            await ReadSyncFinishDateTime();

            LinkedInController.logger.Info("First render of index page completed");

        }

    }

    private async void CreateDatabaseConnection()
    {
        int i = 0;
        foreach (var item in databaseVariableNames)
        {

            var result = await BrowserStorage.GetAsync<string>(databaseVariableNames[i]);
            databaseConnection[i] = result.Success ? result.Value : "";
            i++;
        }
        if (await dbService.CheckDatabaseConnection(databaseConnection[0], databaseConnection[1], databaseConnection[2], databaseConnection[3], databaseConnection[4]))
        {
            Settings.databaseConnectionValid = true;
            Startup.databaseManagerSet = true;
            Startup.databaseManager = new DatabaseManager(databaseConnection[0], databaseConnection[1], databaseConnection[2], databaseConnection[3], databaseConnection[4]);

        }
        else
        {
            Settings.databaseConnectionValid = false;
            Startup.databaseManagerSet = false;
        }
        StateHasChanged();
    }

    private async Task ReadSettingsForSync()
    {
        int j = 0;
        foreach (var value in currentMessageInputValues)
        {
            await ReadMessage(j);
            j++;
        }
        j = 0;
        foreach (var value in dateTimes)
        {
            await ReadTime(j);
            j++;
        }
        j = 0;
        foreach (var value in timeSpans)
        {
            await ReadTimeWithDays(j);
            j++;
        }
        timers.TimeBeforeInitialMessage = TimeSpan.FromDays(timeSpans[0]);
        timers.TimeBeforeFollowupMessage = TimeSpan.FromDays(timeSpans[1]);
        timers.TimeAfterFollowupMessage = TimeSpan.FromDays(timeSpans[2]);

        timers.ToolStartTime = TimeSpan.FromHours(dateTimes[0].Hour);
        timers.ToolStopTime = TimeSpan.FromHours(dateTimes[1].Hour);
    }

    private async Task StartSync()
    {
        if (!isSyncLoopOn) await SaveSyncTimer();
        isCurrentlySyncing = true;
        await syncService.Synchronise(timers, currentMessageInputValues);
        await SaveSyncFinishDateTime();
        isCurrentlySyncing = false;
    }

    private void SyncLoop()
    {
        if (syncTimer.Hour != 0 || syncTimer.Minute != 0)
        {
            SaveSyncTimer();
            t = new System.Timers.Timer();
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            t.Interval = GetInterval();
            isSyncLoopOn = true;
            t.Start();
            LinkedInController.logger.Info($"loop started at: {DateTime.Now.ToString("dd-MM-yyyy  H:mm:ss")}");
            LinkedInController.logger.Info($"Interval is {new TimeSpan(0, 0, 0, 0, Convert.ToInt32(t.Interval))}");
        }
        else
        {
            showAlert = true;
        }

    }

    private double GetInterval()
    {
        DateTime now = DateTime.Now;
        return (syncTimer.Hour * 60 * 60 * 1000) + (syncTimer.Minute * 1 * 1000);
    }

    private async void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        t.Stop();
        LinkedInController.logger.Info($"Loop finished at: {DateTime.Now.ToString("H:mm:ss")} starting sync");
        await StartSync();
        t.Interval = GetInterval();
        t.Start();
        LinkedInController.logger.Info($"Loop starting at: {DateTime.Now.ToString("H:mm:ss")}");

    }

    private void stopSync()
    {
        t.Stop();
        isSyncLoopOn = false;
        LinkedInController.logger.Info("Synchronisation loop has been stopped");
    }

    public async void CheckNotifications(AccountCreditentials accountCreditentials)
    {
        clientDatas = await dbService.CheckNotificationsForAccount(accountCreditentials.Id);
    }

    public int CountNotifications()
    {
        amountOfNotifications = 0;
        foreach (var accountCred in account.GetAllAccountsCreditentials())
        {
            CheckNotifications(accountCred);
            if (clientDatas.Any())
            {
                amountOfNotifications += clientDatas.Count;
            }
        }
        return amountOfNotifications;
    }

    private async Task ReadMessage(int id)
    {
        var result = await BrowserStorage.GetAsync<string>(messageVariableNames[id]);
        currentMessageInputValues[id] = result.Success ? result.Value : "";
    }

    private async Task ReadTimeWithDays(int id)
    {
        var result = await BrowserStorage.GetAsync<int>(daysVariableNames[id]);
        timeSpans[id] = result.Success ? result.Value : 0;
    }

    private async Task ReadTime(int id)
    {
        var result = await BrowserStorage.GetAsync<DateTime>(timeVariableNames[id]);
        dateTimes[id] = result.Success ? result.Value : new DateTime(2);
    }

    private async Task SaveSyncTimer()
    {
        await BrowserStorage.SetAsync("SyncTimer", syncTimer);
    }

    private async Task ReadSyncTimer()
    {
        var result = await BrowserStorage.GetAsync<DateTime>("SyncTimer");
        syncTimer = result.Success ? result.Value : new DateTime(0);
    }

    private async Task SaveSyncFinishDateTime()
    {
        await BrowserStorage.SetAsync("SyncFinishDate", DateTime.Now);
    }

    private async Task ReadSyncFinishDateTime()
    {
        var result = await BrowserStorage.GetAsync<DateTime>("SyncFinishDate");
        Startup.lastSyncDateTime = result.Success ? result.Value : new DateTime(0);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SyncService syncService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private DatabaseService dbService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage BrowserStorage { get; set; }
    }
}
#pragma warning restore 1591
