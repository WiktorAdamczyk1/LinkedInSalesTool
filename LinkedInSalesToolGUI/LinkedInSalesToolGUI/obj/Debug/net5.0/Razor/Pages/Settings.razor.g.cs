#pragma checksum "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85dd97be6b5a1234d1e1dd527f33b14652c98f33"
// <auto-generated/>
#pragma warning disable 1591
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
#line 2 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
using LinkedInSalesToolGUI.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
using LinkedInLib;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/settings")]
    public partial class Settings : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<link rel=""stylesheet"" href=""https://unpkg.com/purecss@2.0.6/build/pure-min.css"" integrity=""sha384-Uu6IeWbM+gzNVXJcM9XV3SohHtmWE+3VGi496jvgX1jyvDTXfdK+rfZc8C1Aehk5"" crossorigin=""anonymous"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1"">
");
            __builder.AddMarkupContent(1, "<h1>Settings</h1>");
#nullable restore
#line 13 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
 for (int i = 0; i < messageVariableNames.Count; i++)
{
    var buttonNumber = i;

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "p");
            __builder.AddContent(3, 
#nullable restore
#line 16 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
        messageVariableNames[buttonNumber]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n    ");
            __builder.OpenElement(5, "textarea");
            __builder.AddAttribute(6, "style", "max-width:600px; min-height:280px; resize:none");
            __builder.AddAttribute(7, "class", "form-control");
            __builder.AddAttribute(8, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 17 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                                                                                 currentInputValues[buttonNumber]

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => currentInputValues[buttonNumber] = __value, currentInputValues[buttonNumber]));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n    <br>");
#nullable restore
#line 19 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
    //<button class="btn btn-secondary" @onclick="@(() => SaveMessage(buttonNumber))">Save</button>
    //<button class="btn btn-secondary" @onclick="@(() => ReadMessage(buttonNumber))">Remove changes</button>

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(11, "<hr>");
#nullable restore
#line 22 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
 for (int i = 0; i < timeVariableNames.Count; i++)
{
    var buttonNumber = i;

#line default
#line hidden
#nullable disable
            __builder.OpenElement(12, "p");
            __builder.AddContent(13, 
#nullable restore
#line 27 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
        timeVariableNames[buttonNumber]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n    ");
            __builder.OpenElement(15, "input");
            __builder.AddAttribute(16, "type", "time");
            __builder.AddAttribute(17, "class", "e-control e-timepicker e-lib e-input");
            __builder.AddAttribute(18, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 28 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                                                           dateTimes[buttonNumber]

#line default
#line hidden
#nullable disable
            , format: "HH:mm:ss", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(19, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => dateTimes[buttonNumber] = __value, dateTimes[buttonNumber], format: "HH:mm:ss", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n    <br>");
#nullable restore
#line 30 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
    //<button class="btn btn-secondary" @onclick="@(() => SaveTime(buttonNumber))">Save</button>
    //<button class="btn btn-secondary" @onclick="@(() => ReadTime(buttonNumber))">Remove changes</button>

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(21, "<hr>");
#nullable restore
#line 33 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
 for (int i = 0; i < daysVariableNames.Count; i++)
{
    var buttonNumber = i;

#line default
#line hidden
#nullable disable
            __builder.OpenElement(22, "p");
            __builder.AddContent(23, 
#nullable restore
#line 38 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
        daysVariableNames[buttonNumber]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n        Days:\r\n    \r\n    ");
            __builder.OpenElement(25, "input");
            __builder.AddAttribute(26, "type", "number");
            __builder.AddAttribute(27, "min", "0");
            __builder.AddAttribute(28, "oninput", "validity.valid||(value=\'\');");
            __builder.AddAttribute(29, "class", "e-control e-timepicker e-lib e-input");
            __builder.AddAttribute(30, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 42 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                                                                                                           timeSpans[buttonNumber]

#line default
#line hidden
#nullable disable
            , culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(31, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => timeSpans[buttonNumber] = __value, timeSpans[buttonNumber], culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n    <br>");
#nullable restore
#line 44 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
    //<html>Hours and minutes:</html> <input type="time" class="e-control e-timepicker e-lib e-input" @bind="dateTimes[buttonNumber]" />
    //<br>
    //<button class="btn btn-secondary" @onclick="@(() => SaveTime(buttonNumber))">Save</button>
    //<button class="btn btn-secondary" @onclick="@(() => ReadTime(buttonNumber))">Remove changes</button>

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(33, "<hr>");
#nullable restore
#line 49 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(34, "<text> Delete user status: </text>\r\n<br>\r\n");
            __builder.OpenElement(35, "select");
            __builder.AddAttribute(36, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 53 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                    UserStatusSelected

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(37, "class", "selectpicker");
            __builder.AddAttribute(38, "data-live-search", "true");
            __builder.OpenElement(39, "option");
            __builder.AddAttribute(40, "selected");
            __builder.AddAttribute(41, "disabled");
            __builder.AddContent(42, "Remove status");
            __builder.CloseElement();
#nullable restore
#line 55 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
     for (int i = 1; i < userStatusesStrings.Count(); i++)
    {
        var statusId = i;

#line default
#line hidden
#nullable disable
            __builder.OpenElement(43, "option");
            __builder.AddAttribute(44, "value", 
#nullable restore
#line 58 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                        statusId

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(45, 
#nullable restore
#line 58 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                   userStatusesStrings[i]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 59 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n\r\n<hr>\r\n");
            __builder.AddMarkupContent(47, "<p>Database connection</p>\r\n");
            __builder.OpenElement(48, "form");
            __builder.AddAttribute(49, "class", "pure-form");
            __builder.OpenElement(50, "fieldset");
            __builder.AddAttribute(51, "class", "pure-group");
            __builder.OpenElement(52, "input");
            __builder.AddAttribute(53, "type", "text");
            __builder.AddAttribute(54, "id", "server");
            __builder.AddAttribute(55, "placeholder", "Server");
            __builder.AddAttribute(56, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 66 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                                                   databaseConnection[0]

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(57, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => databaseConnection[0] = __value, databaseConnection[0]));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n        ");
            __builder.OpenElement(59, "input");
            __builder.AddAttribute(60, "type", "text");
            __builder.AddAttribute(61, "id", "database");
            __builder.AddAttribute(62, "placeholder", "Database");
            __builder.AddAttribute(63, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 67 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                                                       databaseConnection[1]

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(64, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => databaseConnection[1] = __value, databaseConnection[1]));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n        ");
            __builder.OpenElement(66, "input");
            __builder.AddAttribute(67, "type", "text");
            __builder.AddAttribute(68, "id", "port");
            __builder.AddAttribute(69, "placeholder", "Port");
            __builder.AddAttribute(70, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 68 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                                               databaseConnection[2]

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(71, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => databaseConnection[2] = __value, databaseConnection[2]));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\r\n        ");
            __builder.OpenElement(73, "input");
            __builder.AddAttribute(74, "type", "text");
            __builder.AddAttribute(75, "id", "username");
            __builder.AddAttribute(76, "placeholder", "Username");
            __builder.AddAttribute(77, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 69 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                                                       databaseConnection[3]

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(78, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => databaseConnection[3] = __value, databaseConnection[3]));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(79, "\r\n        ");
            __builder.OpenElement(80, "input");
            __builder.AddAttribute(81, "id", "password");
            __builder.AddAttribute(82, "type", "password");
            __builder.AddAttribute(83, "placeholder", "Password");
            __builder.AddAttribute(84, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 70 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                                                           databaseConnection[4]

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(85, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => databaseConnection[4] = __value, databaseConnection[4]));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 74 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
 if (checkingDatabaseConnection)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(86, "<p><em>Loading...</em></p>");
#nullable restore
#line 77 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
}
else if (databaseConnectionValid)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(87, "<p style=\"color:limegreen\"><em>Valid connection established</em></p>");
#nullable restore
#line 81 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(88, "<p style=\"color:red\"><em>Couldn\'t establish a connection</em></p>");
#nullable restore
#line 85 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
}

#line default
#line hidden
#nullable disable
            __builder.OpenElement(89, "button");
            __builder.AddAttribute(90, "class", "btn btn-secondary");
            __builder.AddAttribute(91, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 86 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                              CheckDatabaseInfo

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(92, "Check database connection");
            __builder.CloseElement();
            __builder.AddMarkupContent(93, "\r\n<hr>\r\n");
            __builder.OpenElement(94, "button");
            __builder.AddAttribute(95, "class", "btn btn-secondary");
            __builder.AddAttribute(96, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 88 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                              SaveEverything

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(97, "Save changes");
            __builder.CloseElement();
            __builder.AddMarkupContent(98, "\r\n");
            __builder.OpenElement(99, "button");
            __builder.AddAttribute(100, "class", "btn btn-secondary");
            __builder.AddAttribute(101, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 89 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
                                              ReadEverything

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(102, "Cancel new changes");
            __builder.CloseElement();
            __builder.AddMarkupContent(103, "\r\n<br>");
        }
        #pragma warning restore 1998
#nullable restore
#line 92 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Settings.razor"
       
    string[] currentInputValues = new string[4];
    DateTime[] dateTimes = new DateTime[2];
    int[] timeSpans = new int[3];
    string[] databaseConnection = new string[5];
    readonly List<string> messageVariableNames = new List<string>() { "Initial Message", "Followup Message", "Special Account Initial Message", "Special Account Followup Message" };
    readonly List<string> timeVariableNames = new List<string>() { "Tool start time", "Tool stop time" };
    readonly List<string> daysVariableNames = new List<string>() { "Time before Initial message", "Time before Followup message", "Time after Followup message" };
    readonly List<string> databaseVariableNames = new List<string>() { "server", "database", "port", "username", "password" };
    List<string> userStatusesStrings = new List<string>();
    public bool checkingDatabaseConnection = false;
    public static bool databaseConnectionValid = false;

    protected override async Task OnInitializedAsync()
    {
        Index index = new Index();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (Startup.databaseManagerSet) userStatusesStrings = await dbService.GetUserStatusesStrings();
            await ReadEverything();
            StateHasChanged();
            await CheckDatabaseInfo();

        }

    }

    private async Task SaveDatabaseInfo(int id)
    {
        await BrowserStorage.SetAsync(databaseVariableNames[id], databaseConnection[id]);
    }

    private async Task SaveTimeWithDays(int id)
    {
        await BrowserStorage.SetAsync(daysVariableNames[id], timeSpans[id]);
    }

    private async Task SaveMessage(int id)
    {
        await BrowserStorage.SetAsync(messageVariableNames[id], currentInputValues[id]);
    }

    private async Task SaveTime(int id)
    {
        await BrowserStorage.SetAsync(timeVariableNames[id], dateTimes[id]);
    }

    private async Task ReadTimeWithDays(int id)
    {

        //var resultTime = await BrowserStorage.GetAsync<DateTime>(timeVariableNames[id]);
        //dateTimes[id] = result.Success ? result.Value : new DateTime(2);
        var result = await BrowserStorage.GetAsync<int>(daysVariableNames[id]);
        timeSpans[id] = result.Success ? result.Value : 0;

    }

    private async Task ReadMessage(int id)
    {
        var result = await BrowserStorage.GetAsync<string>(messageVariableNames[id]);
        currentInputValues[id] = result.Success ? result.Value : "";
    }

    private async Task ReadTime(int id)
    {
        var result = await BrowserStorage.GetAsync<DateTime>(timeVariableNames[id]);
        dateTimes[id] = result.Success ? result.Value : new DateTime(2);
    }

    private async Task ReadDatabase(int id)
    {
        var result = await BrowserStorage.GetAsync<string>(databaseVariableNames[id]);
        databaseConnection[id] = result.Success ? result.Value : "";
    }

    private async Task SaveEverything()
    {
        int j = 0;
        foreach (var value in currentInputValues)
        {
            await SaveMessage(j);
            j++;
        }
        j = 0;
        foreach (var value in dateTimes)
        {
            await SaveTime(j);
            j++;
        }
        j = 0;
        foreach (var value in timeSpans)
        {
            await SaveTimeWithDays(j);
            j++;
        }
        j = 0;
        foreach (var value in databaseVariableNames)
        {
            await SaveDatabaseInfo(j);
            j++;
        }
    }

    private async Task ReadEverything()
    {
        int j = 0;
        foreach (var value in currentInputValues)
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
        j = 0;
        foreach (var value in databaseVariableNames)
        {
            await ReadDatabase(j);
            j++;
        }
    }

    private async Task DeleteMessage(int id)
    {
        await BrowserStorage.DeleteAsync(messageVariableNames[id]);
    }

    private async Task CheckDatabaseInfo()
    {
        checkingDatabaseConnection = true;
        StateHasChanged();
        if (await dbService.CheckDatabaseConnection(databaseConnection[0], databaseConnection[1], databaseConnection[2], databaseConnection[3], databaseConnection[4]))
        {
            databaseConnectionValid = true;
            Startup.databaseManagerSet = true;
            Startup.databaseManager = new DatabaseManager(databaseConnection[0], databaseConnection[1], databaseConnection[2], databaseConnection[3], databaseConnection[4]);

        }
        else
        {
            databaseConnectionValid = false;
            Startup.databaseManagerSet = false;
        }
        checkingDatabaseConnection = false;
        StateHasChanged();
    }

    private async Task UserStatusSelected(ChangeEventArgs e)
    {
        bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to remove {e.Value.ToString()} from user statuses?"); // Confirm
        if (confirmed && await dbService.RemoveUserStatus(userStatusesStrings[Convert.ToInt32(e.Value.ToString())])) userStatusesStrings = await dbService.GetUserStatusesStrings();
        StateHasChanged();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage BrowserStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private DatabaseService dbService { get; set; }
    }
}
#pragma warning restore 1591
