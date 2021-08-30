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
#line 2 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Messages.razor"
using LinkedInLib;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Messages.razor"
using LinkedInSalesToolGUI.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Messages.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Messages.razor"
using log4net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Messages.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Messages")]
    public partial class Messages : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 224 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Messages.razor"
       
    private List<AccountCreditentials> accountsCreditentials;
    private List<ClientData> clientDatas;
    private List<MessageDetails> messagesDetails = new List<MessageDetails>();
    private List<int> systemStatuses = new List<int>();
    private List<int> userStatuses = new List<int>();
    private List<string> systemStatusesStrings = new List<string>();
    private List<string> userStatusesStrings = new List<string>();
    private AccountCreditentials selectedAccount;
    private ClientData selectedClient;
    private string selectedSystemStatus = "Show all";
    private string selectedUserStatus = "Show all";
    private bool anyAccountSelected = false;
    private bool anyClientSelected = false;
    private bool sendingMessage = false;
    private string messageText = null;
    private string SelectedUserStatus { get; set; } = "Unassigned";

    protected override async Task OnInitializedAsync()
    {
        if (Startup.databaseManagerSet)
        {
            accountsCreditentials = await dbService.GetAccountsAsync();
            clientDatas = await dbService.GetClientsAsync();
            systemStatusesStrings = await dbService.GetSystemStatusesStrings();
            userStatusesStrings = await dbService.GetUserStatusesStrings();

        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {

        if (Startup.databaseManagerSet) await JsRuntime.InvokeVoidAsync("ScrollToBottom", "chatContainer");

    }

    private async Task OnClientClick(int clientNumber)
    {
        if (!anyClientSelected)
        {
            anyClientSelected = true;
        }

        selectedClient = clientDatas[clientNumber];
        await GetMessagesWithClient();
        SelectedUserStatus = userStatusesStrings[userStatuses[clientNumber]];
        await dbService.SetNotify(selectedAccount.Id, selectedClient.Id, false);
        StateHasChanged();
    }

    private async Task AccountSelected(ChangeEventArgs e)
    {
        if (!anyAccountSelected)
        {
            anyAccountSelected = true;
        }

        selectedAccount = accountsCreditentials[Convert.ToInt32(e.Value.ToString())];
        systemStatuses.Clear();
        userStatuses.Clear();
        foreach (var clientData in clientDatas)
        {
            int userStatus = await dbService.GetUserStatusId(selectedAccount.Id, clientData.Id);
            int systemStatus = await dbService.GetSystemStatusId(selectedAccount.Id, clientData.Id);
            systemStatuses.Add(systemStatus);
            userStatuses.Add(userStatus);
        }

        StateHasChanged();
    }

    private string GetSystemStatus(int clientId)
    {
        return systemStatusesStrings[systemStatuses[clientId] - 1];
    }

    private string GetUserStatus(int clientId)
    {
        return userStatusesStrings[userStatuses[clientId]];
    }

    private async Task GetMessagesWithClient()
    {
        messagesDetails = await dbService.GetMessages(selectedAccount.Id, selectedClient.Id);
    }

    private async Task SendMessage(string message)
    {
        if (!string.IsNullOrEmpty(message) && anyAccountSelected && anyClientSelected && !sendingMessage)
        {
            sendingMessage = true;
            await dbService.SendMessage(selectedAccount, selectedClient.Id, message);
            sendingMessage = false;
            messageText = null;
            await GetMessagesWithClient();
            StateHasChanged();
        }
        else if (sendingMessage)
        {
            await JsRuntime.InvokeAsync<bool>("alert", "Message is currently being sent, please wait."); // Confirm
        }
        else if (string.IsNullOrEmpty(message))
        {
            await JsRuntime.InvokeAsync<bool>("alert", "Cannot send an empty message!");
        }
        else
        {
            await JsRuntime.InvokeAsync<bool>("alert", "Please choose an account and a client!");
        }
    }

    private async Task UserStatusSelected(ChangeEventArgs e)
    {

        if (e.Value.ToString() == "Add new status")
        {
            string prompt = await JsRuntime.InvokeAsync<string>("prompt", "Type new user status:"); // Prompt
            if (await dbService.InsertUserStatus(prompt)) userStatusesStrings = await dbService.GetUserStatusesStrings();
        }
        else if (Convert.ToInt32(e.Value.ToString()) == 0)
        {
            //unassign
            await dbService.UnassignUserStatus(selectedAccount.Id, selectedClient.Id);
            SelectedUserStatus = userStatusesStrings[Convert.ToInt32(e.Value.ToString())];
        }
        else
        {
            await dbService.ChangeUserStatus(selectedAccount.Id, selectedClient.Id, await dbService.GetUserStatusId(userStatusesStrings[Convert.ToInt32(e.Value.ToString())]));
            SelectedUserStatus = userStatusesStrings[Convert.ToInt32(e.Value.ToString())];
        }
    }

    private int FindAccountInList(AccountCreditentials accountCreditentials)
    {
        for (int i = 0; i < accountsCreditentials.Count; i++)
        {
            if (accountsCreditentials[i].Id == accountCreditentials.Id) return i;
        }

        return -1;
    }

    private async Task FixIncorrectData()
    {
        //await dbService.FixIncorrectData(selectedClient, selectedAccount).ContinueWith(t => GetMessagesWithClient());
        await dbService.FixIncorrectData(selectedClient, selectedAccount);
        await GetMessagesWithClient();

    }

    private async Task<bool> CheckIfClientNotify(int id)
    {
        return await dbService.CheckIfClientNotify(id);
    }

    private async Task<bool> CheckIfAccountNotify(int id)
    {
        return await dbService.CheckIfAccountNotify(id);

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private DatabaseService dbService { get; set; }
    }
}
#pragma warning restore 1591
