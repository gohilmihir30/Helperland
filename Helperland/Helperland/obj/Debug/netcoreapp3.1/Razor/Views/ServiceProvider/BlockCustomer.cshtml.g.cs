#pragma checksum "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4c51063ec63b899694630566897c685572cadee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_BlockCustomer), @"mvc.1.0.view", @"/Views/ServiceProvider/BlockCustomer.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4c51063ec63b899694630566897c685572cadee", @"/Views/ServiceProvider/BlockCustomer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0b9fc2f8a20f3e798147764669658d69c9ec557", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_BlockCustomer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FavoriteAndBlockeModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-url", new global::Microsoft.AspNetCore.Html.HtmlString("/blockcustomer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-loading", new global::Microsoft.AspNetCore.Html.HtmlString("#loaderContainer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("blockCustomerSuccess"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("blockCustomerError"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
  
    Layout = "_LayoutAfterLogin";
    ViewData["Title"] = "Blocked Customer";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""data-table position-relative"">
    <div class=""alert alert-danger"" style=""display: none;"" role=""alert""></div>
    <table id=""example"">
        <thead class=""d-none"">
            <tr>
                <th>Customer Details</th>
                <th class=""text-center"">Action</th>
            </tr>
        </thead>
        <tbody class=""d-flex flex-wrap"">
");
#nullable restore
#line 17 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
             foreach (var block in Model.blocked)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <tr class=""d-flex flex-column px-5 py-3 me-3"">
                    <td>
                        <div class=""profilepic d-flex align-items-center justify-content-center rounded-circle"">
                            <img src=""/Image/avtar.png"" alt=""Profile"">
                        </div>
                        <p class=""text-center mt-2 customername mb-0"">");
#nullable restore
#line 24 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
                                                                 Write(block.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 24 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
                                                                                  Write(block.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </td>\r\n                    <td class=\"text-center\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4c51063ec63b899694630566897c685572cadee7616", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 30 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
                             if (block.isBlocked != null && block.isBlocked == true)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <input type=\"hidden\" name=\"customerid\"");
                BeginWriteAttribute("value", " value=\"", 1508, "\"", 1535, 1);
#nullable restore
#line 32 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
WriteAttributeValue("", 1516, block.TargetUserId, 1516, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <button class=\"btn rounded-pill\" type=\"submit\">UnBlock</button>\r\n");
#nullable restore
#line 34 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <input type=\"hidden\" name=\"customerid\"");
                BeginWriteAttribute("value", " value=\"", 1802, "\"", 1829, 1);
#nullable restore
#line 37 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
WriteAttributeValue("", 1810, block.TargetUserId, 1810, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <button class=\"btn rounded-pill block\" type=\"submit\">Block</button>\r\n");
#nullable restore
#line 39 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 43 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
            DefineSection("css", async() => {
                WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css\" />\r\n<link rel=\"stylesheet\" href=\"/CSS/_commonlogdedin.css\" />\r\n<link rel=\"stylesheet\" href=\"/CSS/blockcustomer.css\" />\r\n");
            }
            );
            DefineSection("JavaScript", async() => {
                WriteLiteral(@"
<script src=""https://code.jquery.com/ui/1.13.0/jquery-ui.min.js""
    integrity=""sha256-hlKLmzaRlE8SCJC1Kw8zoUbU8BxA+8kR3gseuKfMjxA="" crossorigin=""anonymous""></script>
<script src=""/JS/_commonlogdedin.js""></script>
<script src=""/JS/blockcustomer.js""></script>
<script>
    $("".verticle-menu ul li"")[5].classList.add(""current_section"");
    var table = $(""#example"").DataTable({
        dom: 't<""table-bottom d-flex justify-content-between align-items-center flex-column flex-md-row""<""table-bottom-inner d-flex flex-column flex-md-row""li>p>',
        pagingType: ""full_numbers"",
        columnDefs: [
            { orderable: false, targets: 0 },
            { orderable: false, targets: 1 }
        ],
        language: {
            paginate: {
                first: '<img src=""/Image/Group 36.png"" alt="""">',
                last: '<img src=""/Image/Group 36.png"" style=""transform:rotate(180deg)"" alt="""">',
                previous: '<img src=""/Image/keyboard-right-arrow-button copy.png"" alt="""">',
     ");
                WriteLiteral(@"           next: '<img src=""/Image/keyboard-right-arrow-button copy.png"" style=""transform:rotate(180deg)"" alt="""">',
            },
            info: ""Total Record: _MAX_"",
            lengthMenu: ""Show_MENU_Entries"",
            emptyTable: ""No Customer Found"",
        },
    });
</script>
");
            }
            );
            DefineSection("ajaxrequest", async() => {
                WriteLiteral("\r\n<script\r\n    src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery-ajax-unobtrusive/3.2.6/jquery.unobtrusive-ajax.min.js\"></script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FavoriteAndBlockeModel> Html { get; private set; }
    }
}
#pragma warning restore 1591