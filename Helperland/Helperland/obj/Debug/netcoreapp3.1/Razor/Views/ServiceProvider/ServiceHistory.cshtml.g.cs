#pragma checksum "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6ec62a51e40c2b068f7641ff87e63e2a9d4973c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_ServiceHistory), @"mvc.1.0.view", @"/Views/ServiceProvider/ServiceHistory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6ec62a51e40c2b068f7641ff87e63e2a9d4973c", @"/Views/ServiceProvider/ServiceHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0b9fc2f8a20f3e798147764669658d69c9ec557", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_ServiceHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FetchServiceDetails>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
  
    Layout = "_LayoutAfterLogin";
    ViewData["Title"] = "Service History";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""modal fade"" id=""serviceDetail"" aria-hidden=""true"" aria-labelledby=""serviceDetailLabel"" tabindex=""-1"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"" style=""min-height: 400px;"">
            <div id=""loaderContainer"" style=""display: block; position: absolute; height:100%"">
                <div class=""loader rounded-circle""></div>
            </div>
        </div>
    </div>
</div>

<div class=""alert"" style=""display: none;"" role=""alert""></div>
<div class=""heading mb-2 mb-sm-0"">
    <div class=""sort d-inline-block d-md-none"">
        <img src=""/Image/filter.png""");
            BeginWriteAttribute("alt", " alt=\"", 785, "\"", 791, 0);
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
            <input class=""form-check-input"" type=""radio"" name=""exampleRadios"" id=""servisProviderAsc"" onclick=sort(2,""asc"")>
            <label class=""form-check-l");
            WriteLiteral(@"abel"" for=""servisProviderAsc"">
                Service Provider: A to Z
            </label>
        </div>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""radio"" name=""exampleRadios"" id=""servisProviderDesc"" onclick=sort(2,""desc"")>
            <label class=""form-check-label"" for=""servisProviderDesc"">
                Service Provider: Z to A
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
            <");
            WriteLiteral(@"/label>
        </div>' />
    </div>
</div>
<div class=""data-table position-relative"">
    <table id=""example"">
        <thead>
            <tr>
                <th class=""text-nowrap"">Service Id</th>
                <th>Service Date</th>
                <th>Customer Details</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 73 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
             if (Model != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                 foreach (var data in Model.Details)
                {
                    var st = data.ServiceStartTime.ToString("HH:mm");
                    var et = data.ServiceStartTime.AddHours(data.ServiceHours).ToString("HH:mm");

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            <a class=\"showdetail\" data-serviceid=\"");
#nullable restore
#line 81 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                             Write(data.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-bs-target=\"#serviceDetail\"\r\n                        data-bs-toggle=\"modal\" data-postalcode=\"");
#nullable restore
#line 82 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                           Write(data.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 82 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                                             Write(data.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </td>\r\n                        <td class=\"datetime\">\r\n                            <div class=\"showdetail\" data-postalcode=\"");
#nullable restore
#line 85 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                                Write(data.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-serviceid=\"");
#nullable restore
#line 85 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                                                                  Write(data.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                        data-bs-target=\"#serviceDetail\" data-bs-toggle=\"modal\">\r\n                                <div class=\"d-flex align-items-center mb-1\">\r\n                                    <img class=\"me-2\" src=\"/Image/calculator.png\"");
            BeginWriteAttribute("alt", " alt=\"", 4192, "\"", 4198, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    <strong>");
#nullable restore
#line 89 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                       Write(data.ServiceStartTime.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                </div>\r\n                                <div class=\"d-flex align-items-center\">\r\n                                    <img class=\"me-2\" src=\"/Image/Layer 712.png\"");
            BeginWriteAttribute("alt", " alt=\"", 4497, "\"", 4503, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                    <span class=\"text-nowrap\">");
#nullable restore
#line 93 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                         Write(st);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 93 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                               Write(et);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                            </div>\r\n                        </td>\r\n                        <td class=\"customer\">\r\n                            <span>");
#nullable restore
#line 98 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                             Write(data.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 98 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                             Write(data.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            <div class=\"d-flex align-item-center mt-1\">\r\n                                <img src=\"/Image/Layer 719.png\"");
            BeginWriteAttribute("alt", " alt=\"", 4952, "\"", 4958, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <span>");
#nullable restore
#line 101 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                 Write(data.Address1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 101 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                Write(data.Address2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                            </div>\r\n                            <span> ");
#nullable restore
#line 103 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                              Write(data.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 103 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                               Write(data.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 106 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 106 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                 

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
            DefineSection("css", async() => {
                WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css\" />\r\n<link rel=\"stylesheet\" href=\"/CSS/_commonlogdedin.css\" />\r\n<link rel=\"stylesheet\" href=\"/CSS/SP-upcoming.css\" />\r\n");
            }
            );
            DefineSection("JavaScript", async() => {
                WriteLiteral(@"
<script src=""https://code.jquery.com/ui/1.13.0/jquery-ui.min.js""
    integrity=""sha256-hlKLmzaRlE8SCJC1Kw8zoUbU8BxA+8kR3gseuKfMjxA="" crossorigin=""anonymous""></script>
<script src=""/JS/_commonlogdedin.js""></script>
<script>
    var table = $(""#example"").DataTable({
        dom: 'Bt<""table-bottom d-flex justify-content-between align-items-center flex-column flex-md-row""<""table-bottom-inner d-flex flex-column flex-md-row""li>p>',
        pagingType: ""full_numbers"",
        columnDefs: [
            { type: ""serviceDate"", targets: 1 },
            { orderable: false, targets: 2 }
        ],
        buttons: [
            {
                extend: ""excel"",
                text: ""Export"",
            },
        ],
        language: {
            paginate: {
                first: '<img src=""/Image/Group 36.png"" alt="""">',
                last: '<img src=""/Image/Group 36.png"" style=""transform:rotate(180deg)"" alt="""">',
                previous: '<img src=""/Image/keyboard-right-arrow-button copy.p");
                WriteLiteral(@"ng"" alt="""">',
                next: '<img src=""/Image/keyboard-right-arrow-button copy.png"" style=""transform:rotate(180deg)"" alt="""">',
            },
            info: ""Total Record: _MAX_"",
            lengthMenu: ""Show_MENU_Entries"",
            emptyTable: ""No service request Found"",
        },
    });


    $("".verticle-menu ul li"")[3].classList.add(""current_section"");
    $(""#serviceDetail"").on(""show.bs.modal"", ($event) => {
        var postalcode = $($event.relatedTarget).attr(""data-PostalCode"");
        $(""#serviceDetail .modal-content"").load(`/sp/getServiceDetail?page=0&serviceid=` + $($event.relatedTarget).attr(""data-serviceid""), () => {
            $.ajax({
                url:
                    `https://api.mapbox.com/geocoding/v5/mapbox.places/` +
                    postalcode +
                    `.json?country=de&limit=1&types=postcode&access_token=pk.eyJ1IjoiY2hpbnRhbjgxNjkiLCJhIjoiY2tvZWNiaTdhMDljeDJwbGoxdTV6eW9ocyJ9.ZTVOwDvOJqnfEKpBWgUvbg`,
                success: (res");
                WriteLiteral(@"ult) => {
                    var coordinates = result.features[0].geometry.coordinates;
                    $("".modal-body>div:last-child"").html(
                        `<iframe src=""http://maps.google.com/maps?q=` +
                        coordinates[1] +
                        `,` +
                        coordinates[0] +
                        `&z=16&output=embed"" height=""100%"" width=""100%"" style=""border:0px;""></iframe>`
                    );
                },
            });
        });
    });
</script>
");
            }
            );
            DefineSection("ajaxrequest", async() => {
                WriteLiteral("\r\n<script\r\n    src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery-ajax-unobtrusive/3.2.6/jquery.unobtrusive-ajax.min.js\"></script>\r\n");
            }
            );
            DefineSection("validation", async() => {
                WriteLiteral(@"
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.3/jquery.validate.min.js""
    integrity=""sha512-37T7leoNS06R80c8Ulq7cdCDU5MNQBwlYoy1TX/WUsLFC2eYNqtKlV0QjH7r8JpG/S0GUMZwebnVFLPd6SU5yg==""
    crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
<script
    src=""https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.12/jquery.validate.unobtrusive.min.js""
    integrity=""sha512-o6XqxgrUsKmchwy9G5VRNWSSxTS4Urr4loO6/0hYdpWmFUfHqGzawGxeQGMDqYzxjY9sbktPbNlkIQJWagVZQg==""
    crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
");
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
