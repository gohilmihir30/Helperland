#pragma checksum "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c505ca346fc2ffc29572aec2be98d318f55b4866"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_GetServiceDetail), @"mvc.1.0.view", @"/Views/Customer/GetServiceDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c505ca346fc2ffc29572aec2be98d318f55b4866", @"/Views/Customer/GetServiceDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0b9fc2f8a20f3e798147764669658d69c9ec557", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_GetServiceDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServiceDetailsModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal-header"">
        <h5 class=""modal-title"" id=""serviceDetailLabel"">Service Detail</h5>
        <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
    </div>
    <div class=""modal-body"">
        <div>
            <h5 class=""m-0"">");
#nullable restore
#line 14 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                       Write(Model.ServiceStartTime.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 14 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                                                                      Write(Model.ServiceStartTime.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" -\r\n                ");
#nullable restore
#line 15 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
           Write(Model.ServiceStartTime.AddHours(@Model.ServiceHours).ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <div>\r\n                <b>Duration: </b>\r\n                <span>");
#nullable restore
#line 18 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                 Write(Model.ServiceHours);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Hrs</span>\r\n            </div>\r\n        </div>\r\n        <div>\r\n            <div>\r\n                <b>Service Id: </b>\r\n                <span>");
#nullable restore
#line 24 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                 Write(Model.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n            <div>\r\n                <b>Extra: </b>\r\n");
#nullable restore
#line 28 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                 foreach (var e in Model.extra)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span> ");
#nullable restore
#line 30 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                      Write(e);

#line default
#line hidden
#nullable disable
            WriteLiteral(", </span>\r\n");
#nullable restore
#line 31 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div>\r\n                <b>Net Amount:</b>\r\n                <span class=\"netamount\">");
#nullable restore
#line 35 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                                   Write(Model.TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &#8364;</span>\r\n            </div>\r\n        </div>\r\n        <div>\r\n            <div>\r\n                <b>Service Address: </b>\r\n                <span>");
#nullable restore
#line 41 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                 Write(Model.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" , ");
#nullable restore
#line 41 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                                       Write(Model.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n            <div>\r\n                <b>Billing Address: </b>\r\n                <span>Same as Cleaing address</span>\r\n            </div>\r\n            <div>\r\n                <b>Phone: </b>\r\n                <span>+91 ");
#nullable restore
#line 49 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                     Write(Model.Mobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n            <div>\r\n                <b>Email: </b>\r\n                <span>");
#nullable restore
#line 53 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                 Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 56 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
         if (@Model.FirstNamme != null)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div>
                <b>Service Provider:</b>
                <div class=""serviceprovider"">
                    <div class=""d-flex align-items-center mt-2"">
                        <div class=""d-flex align-items-center justify-content-center rounded-circle"">
                            <img");
            BeginWriteAttribute("src", " src=\"", 2123, "\"", 2143, 1);
#nullable restore
#line 64 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
WriteAttributeValue("", 2129, Model.Profile, 2129, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2144, "\"", 2150, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </div>\r\n                        <div class=\"text-nowrap\">\r\n                            <p class=\"m-0\">");
#nullable restore
#line 67 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                                      Write(Model.FirstNamme);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 67 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                                                        Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <div class=\"d-flex align-items-center\">\r\n                                <div class=\"position-relative rating\">\r\n                                    <span class=\"unfilled position-absolute top-0 end-0\"");
            BeginWriteAttribute("style", "\r\n                                style=\"", 2548, "\"", 2618, 2);
            WriteAttributeValue("", 2589, "--rating:", 2589, 9, true);
#nullable restore
#line 71 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
WriteAttributeValue("", 2598, Model.AverageRating, 2598, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></span>\r\n                                    <span class=\"filled position-relative top-0 start-0\"></span>\r\n                                </div>\r\n                                <span class=\"ms-1\">");
#nullable restore
#line 74 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                                              Write(Math.Round(Model.AverageRating,2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"mt-1 ms-2\">\r\n                        <span>");
#nullable restore
#line 79 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                         Write(Model.TotalCleaning);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> Cleanings\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 83 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"mb-0\">\r\n            <div>\r\n                <b>Comment:</b>\r\n                <div>");
#nullable restore
#line 87 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                Write(Model.Comments);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"modal-footer  justify-content-start\">\r\n");
#nullable restore
#line 92 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
         if (!ViewBag.isHistory)
        {
            var starttime = (double)Model.ServiceStartTime.Hour + (double)Model.ServiceStartTime.Minute / 60;


#line default
#line hidden
#nullable disable
            WriteLiteral("            <button class=\"btn btn-primary reschedule border-0 rounded-pill\" data-id=\"");
#nullable restore
#line 96 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                                                                                 Write(Model.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-time=\"");
#nullable restore
#line 96 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                                                                                                              Write(starttime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n        data-date=\'");
#nullable restore
#line 97 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
              Write(Model.ServiceStartTime.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' data-bs-target=""#reschedule"" data-bs-toggle=""modal"">
                <img src=""/Image/reschedule-icon-small.png"" class=""mb-1"">
                Reschedule
            </button>
            <button class=""btn btn-primary cancle border-0 rounded-pill"" data-id=""");
#nullable restore
#line 101 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
                                                                             Write(Model.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n        data-bs-target=\"#cancleRequest\" data-bs-toggle=\"modal\">\r\n                <img src=\"/Image/close-icon-small.png\" class=\"mb-1\">Cancel\r\n            </button>\r\n");
#nullable restore
#line 105 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 107 "E:\Study\Tatva Soft\Practice\Helperland\Helperland\Helperland\Views\Customer\GetServiceDetail.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceDetailsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
