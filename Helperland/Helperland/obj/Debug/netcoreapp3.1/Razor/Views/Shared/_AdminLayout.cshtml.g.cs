#pragma checksum "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Shared\_AdminLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3592c9790c56753b8a5f5290d0356254af3d253"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AdminLayout), @"mvc.1.0.view", @"/Views/Shared/_AdminLayout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3592c9790c56753b8a5f5290d0356254af3d253", @"/Views/Shared/_AdminLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0b9fc2f8a20f3e798147764669658d69c9ec557", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AdminLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ServiceRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UsersManagement", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3592c9790c56753b8a5f5290d0356254af3d2534397", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <link rel=""shortcut icon"" href=""/Image/favicon_img.png"" type=""image/x-icon"" />
    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css"" rel=""stylesheet""
        integrity=""sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3"" crossorigin=""anonymous"" />
    <link rel=""stylesheet"" href=""//cdn.datatables.net/1.11.3/css/jquery.dataTables.min.css"" />
    ");
#nullable restore
#line 12 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Shared\_AdminLayout.cshtml"
Write(RenderSection("CSS",false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"/CSS/admin.css\" />\r\n    <title>");
#nullable restore
#line 14 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Shared\_AdminLayout.cshtml"
      Write(ViewBag.title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3592c9790c56753b8a5f5290d0356254af3d2536547", async() => {
                WriteLiteral(@"
    <nav class=""navbar"">
        <div class=""d-flex align-items-center"">
            <div class=""hamburger d-lg-none d-flex"">
                <span></span>
                <span></span>
                <span></span>
            </div>
            <h1 class=""navbar-brand"">helperland</h1>
        </div>
        <div class=""user d-flex align-items-center"">
            <img src=""/Image/user.png""");
                BeginWriteAttribute("alt", " alt=\"", 1165, "\"", 1171, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            <p>");
#nullable restore
#line 29 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Shared\_AdminLayout.cshtml"
          Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            <a href=\"/logout\"><img src=\"/Image/logout.png\"");
                BeginWriteAttribute("alt", " alt=\"", 1275, "\"", 1281, 0);
                EndWriteAttribute();
                WriteLiteral(@" /></a>
        </div>
        <div class=""backblack""></div>
    </nav>
    <div id=""loaderContainer"">
        <div class=""loader rounded-circle""></div>
    </div>
    <section class=""d-flex"">
        <aside class=""left"">
            <ul>
                <li><a href=""#""> Service Management </a></li>
                <li><a href=""#""> Role Management </a></li>
                <li class=""position-relative"">
                    <button class=""btn trigger text-start w-100"">Coupon Code Management</button>
                    <img src=""/Image/Forma 1_1_3.png"" class=""position-absolute""");
                BeginWriteAttribute("alt", " alt=\"", 1879, "\"", 1885, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                    <div class=""collapse"">
                        <a href=""#"">Coupon Codes</a>
                        <a href=""#"">Usage History</a>
                    </div>
                </li>
                <li><a href=""#""> Escalation Management </a></li>
                <li class=""active"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3592c9790c56753b8a5f5290d0356254af3d2538952", async() => {
                    WriteLiteral(" Service Requests ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n                <li><a href=\"#\"> Service Providers </a></li>\r\n                <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3592c9790c56753b8a5f5290d0356254af3d25310488", async() => {
                    WriteLiteral(" User Management ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n                <li class=\"position-relative\">\r\n                    <button class=\"btn trigger text-start w-100\">Finance Module</button>\r\n                    <img src=\"/Image/Forma 1_1_3.png\" class=\"position-absolute\"");
                BeginWriteAttribute("alt", " alt=\"", 2661, "\"", 2667, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                    <div class=""collapse"">
                        <a href=""#"">All Transactions</a>
                        <a href=""#"">Generate Payment</a>
                        <a href=""#"">Customer Invoice</a>
                    </div>
                </li>
                <li><a href=""#""> Zip Code Management </a></li>
                <li><a href=""#""> Rating Management </a></li>
                <li><a href=""#""> Inquiry Management </a></li>
                <li><a href=""#""> Newsletter Management </a></li>
                <li class=""position-relative"">
                    <button class=""btn trigger text-start w-100"" id=""coupon"">Content Management</button>
                    <img src=""/Image/Forma 1_1_3.png"" class=""position-absolute""");
                BeginWriteAttribute("alt", " alt=\"", 3430, "\"", 3436, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <div class=\"collapse\">\r\n                        <a href=\"#\">Blog</a>\r\n                        <a href=\"#\">FAQs</a>\r\n                    </div>\r\n                </li>\r\n            </ul>\r\n        </aside>\r\n        ");
#nullable restore
#line 77 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Shared\_AdminLayout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </section>\r\n    <script src=\"https://code.jquery.com/jquery-3.5.1.js\"></script>\r\n    ");
#nullable restore
#line 80 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Shared\_AdminLayout.cshtml"
Write(RenderSection("validation", false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 81 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Shared\_AdminLayout.cshtml"
Write(RenderSection("ajaxrequest", false));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js""
        integrity=""sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p""
        crossorigin=""anonymous""></script>
    <script src=""https://cdn.datatables.net/1.11.3/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/responsive/2.2.9/js/dataTables.responsive.min.js""></script>
    <script>
        var isAuthenticated = '");
#nullable restore
#line 88 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Shared\_AdminLayout.cshtml"
                          Write(User.Identity.IsAuthenticated);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
        if (isAuthenticated == 'True') {
            setInterval(() => {
                $.get(""/Home/IsLoggedin"", (isAuthenticated, status) => {
                    if (!isAuthenticated) {
                        window.location.href = ""/?logoutModal=true""
                    }
                })
            }, 1000)
        }
        $(window).on('load', () => {
            $(""#loaderContainer"").hide()
        })
    </script>
    ");
#nullable restore
#line 102 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Shared\_AdminLayout.cshtml"
Write(RenderSection("JavaScript"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591