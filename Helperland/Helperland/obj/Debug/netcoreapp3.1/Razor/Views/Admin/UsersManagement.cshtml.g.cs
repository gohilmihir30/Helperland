#pragma checksum "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbae6888e03badf9dd440316aacc06de2fddaf4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UsersManagement), @"mvc.1.0.view", @"/Views/Admin/UsersManagement.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.Models.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbae6888e03badf9dd440316aacc06de2fddaf4f", @"/Views/Admin/UsersManagement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0b9fc2f8a20f3e798147764669658d69c9ec557", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_UsersManagement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdminUserManagement>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Service Provider", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row gy-2 gx-3 align-items-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("activationFrom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-url", new global::Microsoft.AspNetCore.Html.HtmlString("/activation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-loading", new global::Microsoft.AspNetCore.Html.HtmlString("#loaderContainer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("activationSuccess"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("activationError"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
  
    Layout = "_AdminLayout";
    ViewBag.title = "User Management";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"right\">\r\n    <div class=\"heading d-flex align-items-center justify-content-between\">\r\n        <h2>User Management</h2>\r\n        <button><img src=\"/Image/add.png\"");
            BeginWriteAttribute("alt", " alt=\"", 278, "\"", 284, 0);
            EndWriteAttribute();
            WriteLiteral("> Add New user</button>\r\n    </div>\r\n    <div class=\"filter\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbae6888e03badf9dd440316aacc06de2fddaf4f8230", async() => {
                WriteLiteral("\r\n            <div class=\"col-2\">\r\n                <label class=\"visually-hidden\" for=\"username\">User name</label>\r\n                <select class=\"form-select\" id=\"username\" placeholder=\"User name\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbae6888e03badf9dd440316aacc06de2fddaf4f8724", async() => {
                    WriteLiteral("User name");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 17 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                     foreach (var username in Model.UserNameList){

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbae6888e03badf9dd440316aacc06de2fddaf4f10574", async() => {
#nullable restore
#line 18 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                                         Write(username);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                       WriteLiteral(username);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 19 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </select>
            </div>
            <div class=""col-2"">
                <label class=""visually-hidden"" for=""userrole"">User role</label>
                <select class=""form-select"" id=""userrole"" placeholder=""User roel"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbae6888e03badf9dd440316aacc06de2fddaf4f12979", async() => {
                    WriteLiteral("User role");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbae6888e03badf9dd440316aacc06de2fddaf4f14549", async() => {
                    WriteLiteral("Customer");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbae6888e03badf9dd440316aacc06de2fddaf4f15795", async() => {
                    WriteLiteral("Service Provider");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbae6888e03badf9dd440316aacc06de2fddaf4f17049", async() => {
                    WriteLiteral("Admin");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </select>
            </div>
            <div class=""col-2"" style=""min-width: 200px;"">
                <label class=""visually-hidden"" for=""mobile"">Mobile</label>
                <div class=""input-group"">
                    <div class=""input-group-text"">+49</div>
                    <input type=""tel"" class=""form-control"" id=""mobile"" placeholder=""Phone Number"">
                </div>
            </div>
            <div class=""col-auto"" style=""width: 135px;"">
                <label class=""visually-hidden"" for=""zipcode"">Zipcode</label>
                <input type=""text"" class=""form-control"" id=""zipcode"" placeholder=""Zipcode"">
            </div>
            <div class=""col-auto position-relative"">
                <label class=""visually-hidden"" for=""fromdate"">From Date</label>
                <input type=""text"" class=""form-control date"" id=""fromdate"" placeholder=""From Date"">
                <img class=""position-absolute"" src=""/Image/calender.svg""");
                BeginWriteAttribute("alt", " alt=\"", 2326, "\"", 2332, 0);
                EndWriteAttribute();
                WriteLiteral(@">
            </div>
            <div class=""col-auto position-relative"">
                <label class=""visually-hidden"" for=""todate"">To Date</label>
                <input type=""text"" class=""form-control date"" id=""todate"" placeholder=""To Date"">
                <img class=""position-absolute"" src=""/Image/calender.svg""");
                BeginWriteAttribute("alt", " alt=\"", 2656, "\"", 2662, 0);
                EndWriteAttribute();
                WriteLiteral(@">
            </div>
            <div class=""col-auto"">
                <button type=""button"" id=""search"" class=""btn"">Search</button>
            </div>
            <div class=""col-auto"">
                <button type=""reset"" id=""clear"" class=""btn"">Clear</button>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbae6888e03badf9dd440316aacc06de2fddaf4f21343", async() => {
                WriteLiteral(" \r\n        <input type=\"hidden\" name=\"userid\">\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <div class=""data-table"">
        <table id=""user"">
            <thead>
                <tr>
                    <th class=""text-nowrap"">User Name</th>
                    <th>Date of Registration</th>
                    <th class=""text-nowrap"">User Type</th>
                    <th class=""text-nowrap"">Phone</th>
                    <th class=""text-nowrap"">Postal Code</th>
                    <th>City</th>
                    <th class=""text-nowrap text-center"">User Status</th>
                    <th class=""text-center"">Action</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 78 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                 foreach (var user in Model.User)
                {
                    string[] usertype = { "Customer", "Service Provider", "Admin" };

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 82 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                       Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><img src=\"/Image/calculator.png\"");
            BeginWriteAttribute("alt", " alt=\"", 4165, "\"", 4171, 0);
            EndWriteAttribute();
            WriteLiteral("> <span class=\"mt-1 ms-1\"> ");
#nullable restore
#line 83 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                                                                                         Write(user.RegistrationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </td>\r\n                        <td>");
#nullable restore
#line 85 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                       Write(usertype[user.UserType-1]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 86 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                       Write(user.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 87 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                       Write(user.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 88 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                       Write(user.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\">\r\n");
#nullable restore
#line 90 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                              
                                var status = (user.IsActive) ? "Active" : "Inactive";
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <button");
            BeginWriteAttribute("class", " class=\"", 4699, "\"", 4714, 1);
#nullable restore
#line 93 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
WriteAttributeValue("", 4707, status, 4707, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 93 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                                               Write(status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n\r\n                        </td>\r\n                        <td class=\'text-center\'>\r\n");
#nullable restore
#line 97 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                              
                                var popoverContent = (user.IsActive) ? "<a href='#' title='Edit' class='userInfoItem d-block'>Edit</a><a href='#' title='Deactivate' class='userInfoItem d-block activation'  id='"+user.UserId+"'>Deactivate</a><a href='#' title='Service History' class='userInfoItem d-block'>Service History</a>" : "<a href='#' class='userInfoItem d-block' title='Edit'>Edit</a><a href='#' class='userInfoItem d-block activation' title='Activate' id='"+user.UserId+"'>Activate</a><a href='#' class='userInfoItem d-block' title='Service History'>Service History</a>";
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"popover-menu rounded-circle mx-auto\">\r\n                                <img src=\"/Image/menu.png\"");
            BeginWriteAttribute("alt", " alt=\"", 5595, "\"", 5601, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"popoverTrigger\" data-status=");
#nullable restore
#line 101 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                                                                                                Write(user.IsActive);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" data-bs-container=""body""
                                data-bs-custom-class=""pop"" data-bs-toggle=""popover"" data-bs-placement=""bottom""
                                data-bs-offset='-25,8'  tabindex=""0"" data-bs-trigger=""focus""
                                data-bs-content=""");
#nullable restore
#line 104 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                                            Write(popoverContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                                data-bs-html=\"true\">\r\n                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 109 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Admin\UsersManagement.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <footer>\r\n        ??2018 Helperland. All rights reserved.\r\n    </footer>\r\n</div>\r\n");
            DefineSection("CSS", async() => {
                WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css\" />\r\n");
            }
            );
            DefineSection("JavaScript", async() => {
                WriteLiteral("\r\n<script src=\"https://code.jquery.com/ui/1.13.0/jquery-ui.min.js\"\r\n    integrity=\"sha256-hlKLmzaRlE8SCJC1Kw8zoUbU8BxA+8kR3gseuKfMjxA=\" crossorigin=\"anonymous\"></script>\r\n<script src=\"/JS/admin-user-management.js\"></script>\r\n");
            }
            );
            DefineSection("ajaxrequest", async() => {
                WriteLiteral("\r\n<script\r\n    src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery-ajax-unobtrusive/3.2.6/jquery.unobtrusive-ajax.min.js\"></script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdminUserManagement> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
