#pragma checksum "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d9360f02298f9001462a7b9c4ef2105e7e26007"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_Dashboard), @"mvc.1.0.view", @"/Views/ServiceProvider/Dashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d9360f02298f9001462a7b9c4ef2105e7e26007", @"/Views/ServiceProvider/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0b9fc2f8a20f3e798147764669658d69c9ec557", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FetchServiceDetails>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
  
    Layout = "_LayoutAfterLogin";
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"<div class=""modal fade"" id=""serviceDetail"" aria-hidden=""true"" aria-labelledby=""serviceDetailLabel"" tabindex=""-1"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content""></div>
    </div>
</div>

<div class=""modal fade"" id=""conflictservice"" aria-hidden=""true"" aria-labelledby=""conflictserivelabel"" tabindex=""-1"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h3 class=""modal-title"">Conflict Service</h3>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body mb-3"">
                <div class=""conflictserviceid"">
                    <b>Service Id: </b>
                    <span></span>
                </div>
                <div class=""conflictservicetime"">
                    <b>Service Time: </b>
                    <span></span>
                </div>
   ");
            WriteLiteral(@"             <div class=""errormsg text-center""></div>
            </div>
        </div>
    </div>

</div>
<div class=""data-table position-relative"">
    <div class=""alert"" style=""display: none;"" role=""alert""></div>
    <div class=""heading mb-2 mb-sm-0"">
        <h3 class=""d-inline-block"">New Service Requests</h3>
        <div class=""sort d-inline-block d-md-none"">
            <img src=""/Image/filter.png""");
            BeginWriteAttribute("alt", " alt=\"", 1594, "\"", 1600, 0);
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
                Service Id: High to Low
            </label>
        </div>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""radio"" name=""exampleRadios"" id=""paymentAsc""
                   onclick=sort(3,""asc"")>
            <label class=""form-check-label"" for=""paymentAsc"">
                Payment: Low to High
            </label>
        </div>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""radio"" name=""exampleRadios"" id=""paymentDesc""
                   onclick=sort(3,""desc"")>
            <label class=""form-check-label"" for=""paymentDesc"">
                Payment: High to Low
            </label>
        <");
            WriteLiteral(@"/div>' />
        </div>
    </div>
    <table id=""example"">
        <thead>
            <tr>
                <th class=""text-nowrap"">Service Id</th>
                <th>Service Date</th>
                <th class=""text-nowrap"">Service Address</th>
                <th class=""text-center"">Payment</th>
                <th class=""text-center"">Time Conflict</th>
                <th class=""text-center"">Action</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 96 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
             if (Model != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                 foreach (var data in Model.Details)
                {

                    var st = data.ServiceStartTime.ToString("HH:mm");
                    var et = data.ServiceStartTime.AddHours(data.ServiceHours).ToString("HH:mm");


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            <a class=\"showdetail\" data-serviceid=\"");
#nullable restore
#line 106 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                             Write(data.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-bs-target=\"#serviceDetail\"\r\n                        data-bs-toggle=\"modal\" data-postalcode=\"");
#nullable restore
#line 107 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                           Write(data.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 107 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                                             Write(data.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </td>\r\n                        <td class=\"datetime\">\r\n                            <div class=\"showdetail\" data-postalcode=\"");
#nullable restore
#line 110 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                                Write(data.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-serviceid=\"");
#nullable restore
#line 110 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                                                                  Write(data.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                        data-bs-target=\"#serviceDetail\" data-bs-toggle=\"modal\">\r\n                                <div class=\"d-flex align-items-center mb-1\">\r\n                                    <img class=\"me-2\" src=\"/Image/calculator.png\"");
            BeginWriteAttribute("alt", " alt=\"", 5137, "\"", 5143, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    <strong>");
#nullable restore
#line 114 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                       Write(data.ServiceStartTime.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                </div>\r\n                                <div class=\"d-flex align-items-center\">\r\n                                    <img class=\"me-2\" src=\"/Image/Layer 712.png\"");
            BeginWriteAttribute("alt", " alt=\"", 5442, "\"", 5448, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    <span class=\"text-nowrap\">");
#nullable restore
#line 118 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                         Write(st);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 118 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                               Write(et);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                            </div>\r\n                        </td>\r\n                        <td class=\"customer\">\r\n");
#nullable restore
#line 123 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                             if (data.FirstName != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>");
#nullable restore
#line 125 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                 Write(data.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 125 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                 Write(data.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <div class=\"d-flex align-item-center mt-1\">\r\n                                    <img src=\"/Image/Layer 719.png\"");
            BeginWriteAttribute("alt", " alt=\"", 5998, "\"", 6004, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <span>");
#nullable restore
#line 128 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                     Write(data.Address1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 128 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                    Write(data.Address2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                                </div>\r\n                                <span class=\"text-nowrap\"> ");
#nullable restore
#line 130 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                      Write(data.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 130 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                                       Write(data.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 131 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td class=\"payment text-center\"><span>");
#nullable restore
#line 133 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                         Write(data.TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> &#8364;</td>\r\n                        <td class=\"text-center\"><button class=\"btn rounded-pill conflict\" data-id=\"");
#nullable restore
#line 134 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                                                              Write(data.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                        data-bs-target=\"#conflictservice\" data-bs-toggle=\"modal\">Show\r\n                                Conflict</button></td>\r\n                        <td class=\"action text-center\">\r\n");
#nullable restore
#line 138 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                              
                                var starttime = (double)@data.ServiceStartTime.Hour + (double)@data.ServiceStartTime.Minute / 60;
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <button class=\"btn rounded-pill acceptservice\"\r\n                        data-date=\'");
#nullable restore
#line 142 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                              Write(data.ServiceStartTime.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' data-id=\"");
#nullable restore
#line 142 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                                                      Write(data.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                        data-record=\"");
#nullable restore
#line 143 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                Write(data.RecordVersion);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-time=\"");
#nullable restore
#line 143 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                                                                Write(starttime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-bs-target=\"#reschedule\"\r\n                        data-bs-toggle=\"modal\">\r\n                                Accept\r\n                            </button>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 149 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 149 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\Dashboard.cshtml"
                 

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
            DefineSection("css", async() => {
                WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css\" />\r\n<link rel=\"stylesheet\" href=\"/CSS/_commonlogdedin.css\" />\r\n<link rel=\"stylesheet\" href=\"/CSS/SP-dashboard.css\" />\r\n");
            }
            );
            DefineSection("JavaScript", async() => {
                WriteLiteral(@"
<script src=""https://code.jquery.com/ui/1.13.0/jquery-ui.min.js""
    integrity=""sha256-hlKLmzaRlE8SCJC1Kw8zoUbU8BxA+8kR3gseuKfMjxA="" crossorigin=""anonymous""></script>
<script src=""/JS/_commonlogdedin.js""></script>
<script src=""/JS/sp-dashboard.js""></script>
<script>
    var table = $(""#example"").DataTable({
        dom: 't<""table-bottom d-flex justify-content-between align-items-center flex-column flex-md-row""<""table-bottom-inner d-flex flex-column flex-md-row""li>p>',
        pagingType: ""full_numbers"",
        columnDefs: [
            { type: ""serviceDate"", targets: 1 },
            { orderable: false, targets: 2 },
            { orderable: false, targets: 4 },
            { orderable: false, targets: 5 },
        ],
        language: {
            paginate: {
                first: '<img src=""/Image/Group 36.png"" alt="""">',
                last: '<img src=""/Image/Group 36.png"" style=""transform:rotate(180deg)"" alt="""">',
                previous: '<img src=""/Image/keyboard-right-arrow-butt");
                WriteLiteral(@"on copy.png"" alt="""">',
                next: '<img src=""/Image/keyboard-right-arrow-button copy.png"" style=""transform:rotate(180deg)"" alt="""">',
            },
            info: ""Total Record: _MAX_"",
            lengthMenu: ""Show_MENU_Entries"",
            emptyTable: ""No service request Found"",
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FetchServiceDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
