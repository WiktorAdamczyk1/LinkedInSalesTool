#pragma checksum "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31a7955aa6b51b8c35687324a7a8eacf7a92cb61"
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
#line 2 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
using LinkedInSalesToolGUI.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
using LinkedInLib;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Accounts")]
    public partial class Accounts : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<link rel=""stylesheet"" href=""https://unpkg.com/purecss@2.0.6/build/pure-min.css"" integrity=""sha384-Uu6IeWbM+gzNVXJcM9XV3SohHtmWE+3VGi496jvgX1jyvDTXfdK+rfZc8C1Aehk5"" crossorigin=""anonymous"" b-iwa005gquj>
<meta name=""viewport"" content=""width=device-width, initial-scale=1"" b-iwa005gquj>
");
            __builder.AddMarkupContent(1, "<h1 b-iwa005gquj>Accounts</h1>");
#nullable restore
#line 10 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
 if (Startup.databaseManagerSet)
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
     if (!alertClosed)
    {
        if (testSucceded)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "alert");
            __builder.AddAttribute(4, "style", "background-color:limegreen");
            __builder.AddAttribute(5, "b-iwa005gquj");
            __builder.OpenElement(6, "span");
            __builder.AddAttribute(7, "class", "closebtn");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                   ()=>alertClosed = true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "b-iwa005gquj");
            __builder.AddContent(10, "×");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n                Login test successful!\r\n            ");
            __builder.CloseElement();
#nullable restore
#line 21 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "alert");
            __builder.AddAttribute(14, "b-iwa005gquj");
            __builder.OpenElement(15, "span");
            __builder.AddAttribute(16, "class", "closebtn");
            __builder.AddAttribute(17, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 25 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                   ()=>alertClosed = true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "b-iwa005gquj");
            __builder.AddContent(19, "×");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n                Login test has failed!\r\n            ");
            __builder.CloseElement();
#nullable restore
#line 28 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
        }
    }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(21, "p");
            __builder.AddAttribute(22, "b-iwa005gquj");
            __builder.AddContent(23, "Amount of accounts in the database: ");
            __builder.AddContent(24, 
#nullable restore
#line 30 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                            accountsCreditentials.Count

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 32 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
     if (checkingName)
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(25, "<p b-iwa005gquj>Checking your name</p>");
#nullable restore
#line 35 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
    }
    else
    {


#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(26);
            __builder.AddAttribute(27, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 39 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                          accountModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 39 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                        HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(29, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(30);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(31, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(32);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(33, "\r\n            ");
                __builder2.OpenElement(34, "form");
                __builder2.AddAttribute(35, "class", "pure-form");
                __builder2.AddAttribute(36, "b-iwa005gquj");
                __builder2.OpenElement(37, "fieldset");
                __builder2.AddAttribute(38, "class", "pure-group");
                __builder2.AddAttribute(39, "b-iwa005gquj");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(40);
                __builder2.AddAttribute(41, "id", "email");
                __builder2.AddAttribute(42, "placeholder", "Email");
                __builder2.AddAttribute(43, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 44 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                                           accountModel.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(44, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => accountModel.Email = __value, accountModel.Email))));
                __builder2.AddAttribute(45, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => accountModel.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(46, "\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(47);
                __builder2.AddAttribute(48, "id", "password");
                __builder2.AddAttribute(49, "type", "password");
                __builder2.AddAttribute(50, "placeholder", "Password");
                __builder2.AddAttribute(51, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 45 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                                                                 accountModel.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(52, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => accountModel.Password = __value, accountModel.Password))));
                __builder2.AddAttribute(53, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => accountModel.Password));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(54, "\r\n            ");
                __builder2.OpenElement(55, "label");
                __builder2.AddAttribute(56, "for", "checkbox-one");
                __builder2.AddAttribute(57, "class", "pure-checkbox");
                __builder2.AddAttribute(58, "b-iwa005gquj");
                __builder2.OpenElement(59, "input");
                __builder2.AddAttribute(60, "type", "checkbox");
                __builder2.AddAttribute(61, "id", "checkbox-one");
                __builder2.AddAttribute(62, "class", "pure-checkbox");
                __builder2.AddAttribute(63, "checked", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 49 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                                                      accountModel.Special

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(64, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => accountModel.Special = __value, accountModel.Special));
                __builder2.SetUpdatesAttributeName("checked");
                __builder2.AddAttribute(65, "b-iwa005gquj");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(66, " Special account\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(67, "<br b-iwa005gquj>\r\n            ");
                __builder2.AddMarkupContent(68, "<button class=\"btn btn-primary\" type=\"submit\" b-iwa005gquj>Add new account</button>");
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 54 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
     if (accountsCreditentials == null)
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(69, "<p b-iwa005gquj><em b-iwa005gquj>Loading...</em></p>");
#nullable restore
#line 59 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
    }
    else
    {


#line default
#line hidden
#nullable disable
            __builder.OpenElement(70, "table");
            __builder.AddAttribute(71, "class", "table");
            __builder.AddAttribute(72, "b-iwa005gquj");
            __builder.OpenElement(73, "thead");
            __builder.AddAttribute(74, "b-iwa005gquj");
            __builder.OpenElement(75, "tr");
            __builder.AddAttribute(76, "b-iwa005gquj");
            __builder.AddMarkupContent(77, "<th b-iwa005gquj>Delete</th>\r\n                    ");
            __builder.OpenElement(78, "th");
            __builder.AddAttribute(79, "class", "sort-th");
            __builder.AddAttribute(80, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 67 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                    () => SortTable("Id")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(81, "b-iwa005gquj");
            __builder.AddMarkupContent(82, "\r\n                        Id");
            __builder.OpenElement(83, "span");
            __builder.AddAttribute(84, "class", "fas" + " " + (
#nullable restore
#line 68 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                             SetSortIcon("Id")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(85, "b-iwa005gquj");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n                    ");
            __builder.OpenElement(87, "th");
            __builder.AddAttribute(88, "class", "sort-th");
            __builder.AddAttribute(89, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 70 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                    () => SortTable("Name")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(90, "b-iwa005gquj");
            __builder.AddMarkupContent(91, "\r\n                        Name");
            __builder.OpenElement(92, "span");
            __builder.AddAttribute(93, "class", "fas" + " " + (
#nullable restore
#line 71 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                               SetSortIcon("Name")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(94, "b-iwa005gquj");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n                    ");
            __builder.OpenElement(96, "th");
            __builder.AddAttribute(97, "class", "sort-th");
            __builder.AddAttribute(98, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 73 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                    () => SortTable("Email")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(99, "b-iwa005gquj");
            __builder.AddMarkupContent(100, "\r\n                        Email");
            __builder.OpenElement(101, "span");
            __builder.AddAttribute(102, "class", "fas" + " " + (
#nullable restore
#line 74 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                SetSortIcon("Email")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(103, "b-iwa005gquj");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(104, "\r\n                    ");
            __builder.AddMarkupContent(105, "<th b-iwa005gquj>Password</th>\r\n                    ");
            __builder.OpenElement(106, "th");
            __builder.AddAttribute(107, "class", "sort-th");
            __builder.AddAttribute(108, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 77 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                    () => SortTable("Special")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(109, "b-iwa005gquj");
            __builder.AddMarkupContent(110, "\r\n                        Special");
            __builder.OpenElement(111, "span");
            __builder.AddAttribute(112, "class", "fas" + " " + (
#nullable restore
#line 78 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                  SetSortIcon("Special")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(113, "b-iwa005gquj");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(114, "\r\n                    ");
            __builder.AddMarkupContent(115, "<th b-iwa005gquj>Test</th>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(116, "\r\n            ");
            __builder.OpenElement(117, "tbody");
            __builder.AddAttribute(118, "b-iwa005gquj");
#nullable restore
#line 84 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                 for (int i = 0; i < accountsCreditentials.Count(); i++)
                {
                    var buttonNumber = i;

#line default
#line hidden
#nullable disable
            __builder.OpenElement(119, "tr");
            __builder.AddAttribute(120, "b-iwa005gquj");
            __builder.OpenElement(121, "td");
            __builder.AddAttribute(122, "b-iwa005gquj");
            __builder.OpenElement(123, "button");
            __builder.AddAttribute(124, "class", "btn btn-danger");
            __builder.AddAttribute(125, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 88 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                                       e => RemoveAccount(accountsCreditentials[buttonNumber].Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(126, "b-iwa005gquj");
            __builder.AddContent(127, "X");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(128, "\r\n                        ");
            __builder.OpenElement(129, "td");
            __builder.AddAttribute(130, "b-iwa005gquj");
            __builder.AddContent(131, 
#nullable restore
#line 89 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                             accountsCreditentials[i].Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(132, "\r\n                        ");
            __builder.OpenElement(133, "td");
            __builder.AddAttribute(134, "b-iwa005gquj");
            __builder.AddContent(135, 
#nullable restore
#line 90 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                             accountsCreditentials[i].Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(136, "\r\n                        ");
            __builder.OpenElement(137, "td");
            __builder.AddAttribute(138, "b-iwa005gquj");
            __builder.AddContent(139, 
#nullable restore
#line 91 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                             accountsCreditentials[i].Email

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(140, "\r\n                        ");
            __builder.AddMarkupContent(141, "<td b-iwa005gquj>Hidden</td>\r\n                        ");
            __builder.OpenElement(142, "td");
            __builder.AddAttribute(143, "b-iwa005gquj");
            __builder.AddContent(144, 
#nullable restore
#line 93 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                             accountsCreditentials[i].Special

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(145, "\r\n                        ");
            __builder.OpenElement(146, "td");
            __builder.AddAttribute(147, "b-iwa005gquj");
            __builder.OpenElement(148, "button");
            __builder.AddAttribute(149, "class", "btn btn-primary");
            __builder.AddAttribute(150, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 94 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                                                                        e => TestLogIn(accountsCreditentials[buttonNumber].Email, accountsCreditentials[buttonNumber].Password)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(151, "b-iwa005gquj");
            __builder.AddContent(152, "X");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 96 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 99 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 99 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
     
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(153, "<p style=\"color:red\" b-iwa005gquj>Cannot manage accounts without database connection!</p>");
#nullable restore
#line 104 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 107 "C:\Programowanie\Praca\Praktyki Hart Sp. z o.o\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Pages\Accounts.razor"
       
    private List<AccountCreditentials> accountsCreditentials;
    private AccountModel accountModel = new();
    private bool checkingName = false;
    private bool alertClosed = true;
    private bool testSucceded = false;
    private bool? isSortedAscending = null;
    public string ActiveSortColumn { get; set; } = null;

    private async Task HandleValidSubmit()
    {

        if (!(await dbService.CheckIfAccountExistsInDb(accountModel.Email)))
        {
            checkingName = true;
            string name = await dbService.GetAccountName(accountModel.Email, accountModel.Password);
            if (name != "Failed") if (await dbService.InsertAccount(accountModel.Email, accountModel.Password, name, accountModel.Special))
                {
                    accountsCreditentials = await dbService.GetAccountsAsync();
                    testSucceded = true;
                }
                else
                {
                    testSucceded = false;
                }
            //else error prompt about failure
            alertClosed = false;
            checkingName = false;
        }
        else
        {
            await JsRuntime.InvokeAsync<bool>("alert", "Account with that email is already in the database");
        }

    }

    protected override async Task OnInitializedAsync()
    {
        if (Startup.databaseManagerSet)
        {
            accountsCreditentials = await dbService.GetAccountsAsync();
        }

    }

    private async Task RemoveAccount(int accountId)
    {
        bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure you want to remove one of your accounts?"); // Confirm
        if (confirmed && await dbService.RemoveAccountAsync(accountId)) accountsCreditentials = await dbService.GetAccountsAsync();

    }

    private async Task TestLogIn(string email, string password)
    {
        testSucceded = await dbService.TestAccountLogIn(email, password);
        alertClosed = false;
    }

    private void SortTable(string columnName, bool changingSort = true)
    {
        if (columnName != ActiveSortColumn)
        {
            accountsCreditentials = accountsCreditentials.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            isSortedAscending = true;
            ActiveSortColumn = columnName;
        }
        else if (changingSort)
        {
            if (isSortedAscending == true)
            {
                accountsCreditentials = accountsCreditentials.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            }
            else
            {
                accountsCreditentials = accountsCreditentials.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            }
            isSortedAscending = !isSortedAscending;
        }
        else
        {
            if (isSortedAscending == false)
            {
                accountsCreditentials = accountsCreditentials.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            }
            else
            {
                accountsCreditentials = accountsCreditentials.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            }
        }
    }

    private string SetSortIcon(string columnName)
    {
        if (ActiveSortColumn != columnName)
        {
            return string.Empty;
        }
        if (isSortedAscending == true)
        {
            return "fa-sort-up";
        }
        else
        {
            return "fa-sort-down";
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private DatabaseService dbService { get; set; }
    }
}
#pragma warning restore 1591
