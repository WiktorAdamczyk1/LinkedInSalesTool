#pragma checksum "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92a8d580f17bb9ba414aea1df4eb05e7d3c7ed1c"
// <auto-generated/>
#pragma warning disable 1591
namespace LinkedInSalesToolGUI.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using LinkedInSalesToolGUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\_Imports.razor"
using LinkedInSalesToolGUI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Shared\MainLayout.razor"
using LinkedInSalesToolGUI.Data;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-23vfntsx8t");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "sidebar");
            __builder.AddAttribute(5, "b-23vfntsx8t");
            __builder.OpenComponent<LinkedInSalesToolGUI.Shared.NavMenu>(6);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n\r\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "main");
            __builder.AddAttribute(10, "b-23vfntsx8t");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "top-row px-4");
            __builder.AddAttribute(13, "b-23vfntsx8t");
#nullable restore
#line 12 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Shared\MainLayout.razor"
             if (Startup.lastSyncDateTime != DateTime.MinValue)
            {

                

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(14, "\r\n                    Last sync: ");
            __builder.AddContent(15, 
#nullable restore
#line 16 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Shared\MainLayout.razor"
                                Startup.lastSyncDateTime.ToString("dd.MM.yyyy   H:mm:ss")

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 17 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Shared\MainLayout.razor"
                       

            }
            else
            {

                

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(16, "\r\n                    Last sync: n/a\r\n                ");
#nullable restore
#line 25 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Shared\MainLayout.razor"
                       

            }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "style", " justify-content: flex-end; float: right; margin-left:auto; padding: 3px");
            __builder.AddAttribute(19, "b-23vfntsx8t");
#nullable restore
#line 29 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Shared\MainLayout.razor"
                 if (Startup.databaseManagerSet)
                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(20, "<p style=\"color:limegreen\" b-23vfntsx8t><em b-23vfntsx8t>You have a valid database connection</em></p>");
#nullable restore
#line 32 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Shared\MainLayout.razor"
                }
                else if (_navManager.Uri.Contains("accounts") || _navManager.Uri.Contains("settings") || _navManager.Uri.Contains("clients") || _navManager.Uri.Contains("messages"))
                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(21, "<em b-23vfntsx8t><a href=\"/Settings\" style=\"color:red\" b-23vfntsx8t>\r\n                            Couldn\'t establish a connection to the database!\r\n                            Resolve this issue on the settings page.\r\n                        </a></em>");
#nullable restore
#line 41 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Shared\MainLayout.razor"
                }
                else
                {

                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n\r\n            ");
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "class", "content px-4");
            __builder.AddAttribute(25, "b-23vfntsx8t");
            __builder.AddContent(26, 
#nullable restore
#line 50 "C:\Programming\Projects\LinkedInLib\LinkedInSalesToolGUI\LinkedInSalesToolGUI\Shared\MainLayout.razor"
                 Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navManager { get; set; }
    }
}
#pragma warning restore 1591
