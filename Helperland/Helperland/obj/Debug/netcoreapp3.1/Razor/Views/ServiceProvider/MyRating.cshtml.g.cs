#pragma checksum "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b80a73735bdb37a1e42d215ebcffa021c8364e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_MyRating), @"mvc.1.0.view", @"/Views/ServiceProvider/MyRating.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b80a73735bdb37a1e42d215ebcffa021c8364e8", @"/Views/ServiceProvider/MyRating.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0b9fc2f8a20f3e798147764669658d69c9ec557", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_MyRating : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SPRatingModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml"
  
    Layout = "_LayoutAfterLogin";
    ViewData["Title"] = "Service History";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"data-table position-relative\">\r\n    <div class=\"heading mb-2 text-end me-2\">\r\n        <span class=\"d-inline-block\">Sorting </span>\r\n        <div class=\"sort d-inline-block\">\r\n            <img src=\"/Image/filter.png\"");
            BeginWriteAttribute("alt", " alt=\"", 335, "\"", 341, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""sortData"" data-bs-toggle=""popover"" data-bs-container=""body""
                data-bs-placement=""bottom"" data-bs-trigger=""focus"" tabindex=""0"" data-bs-html=""true""
                data-bs-custom-class=""sortOption"" data-bs-offset=""-80,17"" data-bs-content='<div class=""form-check"">
            <input class=""form-check-input"" type=""radio"" name=""exampleRadios"" id=""serviceAsc"" onclick=sort(1,""asc"")>
            <label class=""form-check-label"" for=""serviceAsc"">
                Service Date: Oldest
            </label>
        </div>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""radio"" name=""exampleRadios"" id=""serviceDesc"" onclick=sort(1,""desc"")>
            <label class=""form-check-label"" for=""serviceDesc"">
                Service Date: Latest
            </label>
        </div>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""radio"" name=""exampleRadios"" id=""servisIdAsc"" onclick=sort(0,""asc"")>
            <label class=""form-check");
            WriteLiteral(@"-label"" for=""servisIdAsc"">
                Service Id: Low to High
            </label>
        </div>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""radio"" name=""exampleRadios"" id=""servisIdDesc"" onclick=sort(0,""desc"")>
            <label class=""form-check-label"" for=""servisIdDesc"">
                Service Id: High to low
            </label>
        </div>' />
        </div>
    </div>

    <table id=""example"">
        <thead class=""d-none"">
            <tr>
                <th>Service Id</th>
                <th>Service Date</th>
                <th>Rating</th>
                <th>Comments</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 49 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml"
             foreach (var rating in Model.spRatingModel)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"row mb-3 w-100 mx-0 px-3 py-2\">\r\n                    <td class=\"d-block col-12 col-md-2 p-0 py-2 py-md-0\">\r\n                        <span> ");
#nullable restore
#line 53 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml"
                          Write(rating.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br>\r\n                        <b> ");
#nullable restore
#line 54 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml"
                       Write(rating.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 54 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml"
                                         Write(rating.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </b>\r\n                    </td>\r\n                    <td class=\"d-block col-12 col-md-8 p-0 py-2 py-md-0\">\r\n                        <div class=\"d-flex align-items-center mb-1\">\r\n                            <img class=\"me-2\" src=\"/Image/calculator.png\"");
            BeginWriteAttribute("alt", " alt=\"", 2663, "\"", 2669, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <strong>");
#nullable restore
#line 59 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml"
                               Write(rating.ServiceStartDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                        </div>\r\n                        <div class=\"d-flex align-items-center\">\r\n                            <img class=\"me-2\" src=\"/Image/Layer 712.png\"");
            BeginWriteAttribute("alt", " alt=\"", 2938, "\"", 2944, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <span class=\"text-nowrap\">");
#nullable restore
#line 63 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml"
                                                 Write(rating.ServiceStartDate.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" -\r\n                                ");
#nullable restore
#line 64 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml"
                           Write(rating.ServiceStartDate.AddHours(rating.ServiceHours).ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </span>
                        </div>
                    </td>
                    <td class=""d-block col-12 col-md-2 p-0 py-2 py-md-0"">
                        <p class=""m-0"">Ratings</p>
                        <div class=""position-relative rating d-inline-block"">
                            <span class=""unfilled position-absolute top-0 end-0""");
            BeginWriteAttribute("style", "\r\n                            style=\"", 3538, "\"", 3612, 2);
            WriteAttributeValue("", 3575, "--rating:", 3575, 9, true);
#nullable restore
#line 72 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml"
WriteAttributeValue("", 3584, Math.Round(rating.Rating,2), 3584, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"></span>
                            <span class=""filled position-relative top-0 start-0""></span>
                        </div>
                    </td>
                    <td class=""d-block col-12 p-0"">
                        <hr class=""d-none d-md-block"">
                        <b class=""d-block"">Customer Comment</b>
                        <span>");
#nullable restore
#line 79 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml"
                         Write(rating.Comments);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 82 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\MyRating.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
            DefineSection("css", async() => {
                WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css\" />\r\n<link rel=\"stylesheet\" href=\"/CSS/_commonlogdedin.css\" />\r\n<link rel=\"stylesheet\" href=\"/CSS/myrating.css\" />\r\n");
            }
            );
            DefineSection("JavaScript", async() => {
                WriteLiteral(@"
<script src=""https://code.jquery.com/ui/1.13.0/jquery-ui.min.js""
    integrity=""sha256-hlKLmzaRlE8SCJC1Kw8zoUbU8BxA+8kR3gseuKfMjxA="" crossorigin=""anonymous""></script>
<script src=""/JS/_commonlogdedin.js""></script>
<script>
    $("".verticle-menu ul li"")[4].classList.add(""current_section"");
    var table = $(""#example"").DataTable({
        dom: 't<""table-bottom d-flex justify-content-between align-items-center flex-column flex-md-row""<""table-bottom-inner d-flex flex-column flex-md-row""li>p>',
        pagingType: ""full_numbers"",
        columnDefs: [
            { orderable: false, targets: 2 }
        ],
        language: {
            paginate: {
                first: '<img src=""/Image/Group 36.png"" alt="""">',
                last: '<img src=""/Image/Group 36.png"" style=""transform:rotate(180deg)"" alt="""">',
                previous: '<img src=""/Image/keyboard-right-arrow-button copy.png"" alt="""">',
                next: '<img src=""/Image/keyboard-right-arrow-button copy.png"" style=""transform:rot");
                WriteLiteral("ate(180deg)\" alt=\"\">\',\r\n            },\r\n            info: \"Total Record: _MAX_\",\r\n            lengthMenu: \"Show_MENU_Entries\",\r\n            emptyTable: \"No service request Found\",\r\n        },\r\n    });\r\n\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SPRatingModel> Html { get; private set; }
    }
}
#pragma warning restore 1591