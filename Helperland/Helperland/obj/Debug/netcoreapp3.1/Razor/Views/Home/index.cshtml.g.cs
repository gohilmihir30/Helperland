#pragma checksum "E:\Study\Tatva Soft\Helperland\Helperland\Helperland\Views\Home\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2765d32336034934f4acd8df0c65c1928da9baa2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_index), @"mvc.1.0.view", @"/Views/Home/index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2765d32336034934f4acd8df0c65c1928da9baa2", @"/Views/Home/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "userRegistration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "UserRegistration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Create an account"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex justify-content-center align-items-center flex-wrap"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- ...................Modal......................... -->
<div class=""modal fade"" id=""loginModalToggle"" aria-hidden=""true"" aria-labelledby=""loginModalToggleLabel""
     tabindex=""-1"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""loginModalToggleLabel"">Login to your account</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2765d32336034934f4acd8df0c65c1928da9baa25324", async() => {
                WriteLiteral(@"
                    <div class=""mb-3"">
                        <input type=""email"" class=""form-control"" id=""loginInputEmail1"" placeholder=""Email""
                               aria-describedby=""emailHelp"">
                    </div>
                    <div class=""mb-3"">
                        <input type=""password"" class=""form-control"" id=""loginInputPassword1"" placeholder=""Password"">
                    </div>
                    <div class=""mb-3 form-check"">
                        <input type=""checkbox"" class=""form-check-input"" id=""rememberMe"">
                        <label class=""form-check-label"" for=""rememberMe"">Remember Me</label>
                    </div>
                    <button type=""submit"" class=""btn btn-primary rounded-pill"" disabled>Login</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""mt-4"">
                    <p class=""m-0 text-center"">
                        <a title=""Forget Password"" data-bs-target=""#forgetPassModalToggle2""
                           data-bs-toggle=""modal"">Forget Password?</a>
                    </p>
                    <p class=""m-0 text-center"">
                        Don't have account?");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2765d32336034934f4acd8df0c65c1928da9baa27778", async() => {
                WriteLiteral("Create an account");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""forgetPassModalToggle2"" aria-hidden=""true"" aria-labelledby=""forgetPassModalToggleLabel2""
     tabindex=""-1"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""forgetPassModalToggleLabel2"">Forget Password</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2765d32336034934f4acd8df0c65c1928da9baa29919", async() => {
                WriteLiteral(@"
                    <div class=""mb-3"">
                        <input type=""email"" class=""form-control"" id=""forgetPassEmail1"" placeholder=""Email""
                               aria-describedby=""emailHelp"">
                    </div>
                    <button type=""submit"" class=""btn btn-primary rounded-pill"" disabled>Send</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""mt-4"">
                    <p class=""m-0 text-center"">
                        <a title=""Login Page"" data-bs-target=""#loginModalToggle""
                           data-bs-toggle=""modal"">Login Page</a>
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- ....................Modal end........................ -->

<section class='container-fluid banner'>
    <div class=""banner-main-contain"">
        <h1>Do not feel like housework?</h1>
        <p>Great! Book now for Helperland and enjoy the benefits</p>
        <ul>
            <li>Certified & insured helper</li>
            <li>Easy booking procedure</li>
            <li>Friendly customer service</li>
            <li>Secure online payment method</li>
        </ul>
    </div>
    <div class=""btn d-block text-center"">
        <a href=""#"" target=""_blank"" class=""rounded-pill"" rel=""noopener noreferrer"">Let's Book a Cleaner</a>
    </div>
    <div class=""box d-");
            WriteLiteral("flex align-items-center justify-content-center\">\r\n        <div class=\"inner-box\">\r\n            <img src=\"./Image/Forma 1 copy.png\"");
            BeginWriteAttribute("alt", " alt=\"", 4088, "\"", 4094, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <p>Enter your postcode</p>\r\n        </div>\r\n        <div class=\"inner-box arrow\">\r\n            <img src=\"./Image/step-arrow1.png\"");
            BeginWriteAttribute("alt", " alt=\"", 4239, "\"", 4245, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n        <div class=\"inner-box\">\r\n            <img src=\"./Image/Group 22.png\"");
            BeginWriteAttribute("alt", " alt=\"", 4341, "\"", 4347, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <p>Select your plan</p>\r\n        </div>\r\n        <div class=\"inner-box arrow\">\r\n            <img src=\"./Image/step-arrow1 copy.png\"");
            BeginWriteAttribute("alt", " alt=\"", 4494, "\"", 4500, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n        <div class=\"inner-box\">\r\n            <img src=\"./Image/Forma 1_2.png\"");
            BeginWriteAttribute("alt", " alt=\"", 4597, "\"", 4603, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <p>Pay securely online</p>\r\n        </div>\r\n        <div class=\"inner-box arrow\">\r\n            <img src=\"./Image/step-arrow1.png\"");
            BeginWriteAttribute("alt", " alt=\"", 4748, "\"", 4754, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n        <div class=\"inner-box\">\r\n            <img src=\"./Image/Forma 1.png\"");
            BeginWriteAttribute("alt", " alt=\"", 4849, "\"", 4855, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <p>Enjoy amazing service</p>\r\n        </div>\r\n    </div>\r\n    <div class=\"scroll-down rounded-circle\">\r\n        <a href=\"#why_section\"><img src=\"./Image/Shape 1@2x.png\"");
            BeginWriteAttribute("alt", " alt=\"", 5039, "\"", 5045, 0);
            EndWriteAttribute();
            WriteLiteral(@"></a>
    </div>
</section>
<section class=""container-fluid"">
    <div class=""why d-flex justify-content-center align-items-center flex-column"" id='why_section'>
        <h2 class=""text-center"">Convince yourself!</h2>
        <div class=""card-wraper row justify-content-center text-center"">
            <div class=""cart-item col-lg-4 col-sm-6"">
                <img src=""./Image/Group 21.png""");
            BeginWriteAttribute("alt", " alt=\"", 5446, "\"", 5452, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                <h3 style=""height: 72px;"">Friendly & Certified Helpers</h3>
                <p>We want you to be completely satisfied with our service and feel comfortable at home. In order to guarantee this, our helpers go through a test procedure. Only when the cleaners meet our high standards, they may call themselves Helper.</p>
            </div>
            <div class=""cart-item col-lg-4 col-sm-6 text-center"">
                <img src=""./Image/Group 23.png""");
            BeginWriteAttribute("alt", " alt=\"", 5927, "\"", 5933, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                <h3 style=""height: 72px;"">Transparent and secure payment</h3>
                <p>We have transparent prices, you do not have to scratch money or money on the sideboard Leave it: Pay your helper easily and securely via the online payment method. You will also receive an invoice for each completed cleaning.</p>
            </div>
            <div class=""cart-item col-lg-4 col-sm-6 text-center"">
                <img src=""./Image/Group 24.png""");
            BeginWriteAttribute("alt", " alt=\"", 6400, "\"", 6406, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                <h3 style=""height: 72px;"">We're here for you</h3>
                <p>You have a question or need assistance with the booking process? Our customer service is happy to help and advise you. How you can reach us you will find out when you look under ""Contact"". We look forward to hearing from you or reading.</p>
            </div>
        </div>
    </div>
</section>
<section class=""container-fluid blog position-relative "">
    <div class=""d-flex align-items-center justify-content-center flex-column"">
        <div class=""blog-item row flex-nowrap align-items-center"">
            <div class=""left col-lg-7 col-12 m-sm-0"">
                <h4>We do not know what makes you happy, but ... </h4>
                <p>If it's not dusting off, our friendly helpers will free you from this burden - do not worry anymore about spending valuable time doing housework, but savour life, you're well worth your time with beautiful experiences. Free yourself and enjoy the gained time: Go celebrate, relax,");
            WriteLiteral(@" play with your children, meet friends or dare to jump on the bungee. Other leisure ideas and exclusive events can be found in our blog - guaranteed free from dust and cleaning tips!</p>
            </div>
            <div class=""right col-lg-5 col-12"">
                <div>
                    <img src=""./Image/blog-decription-image.png""");
            BeginWriteAttribute("alt", " alt=\"", 7775, "\"", 7781, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
            </div>
        </div>
        <div class=""blog-item"">
            <h2 class=""text-center"">Our Blog</h2>
            <div class=""blog-card-wrap row align-items-center justify-content-center"">
                <div class=""blog-card col-lg-4 col-sm-12 "">
                    <img src=""./Image/Group 28.png""");
            BeginWriteAttribute("alt", " alt=\"", 8129, "\"", 8135, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""cart-list-item"">
                        <h4>Lorem ipsum dolor sit amet.</h4>
                        <small>January 28, 2019</small>
                        <p>
                            Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatum a amet reiciendis
                            quidem?
                        </p>
                        <a href=""#"">Read the Post<img src=""./Image/Shape 2.png""");
            BeginWriteAttribute("alt", " alt=\"", 8598, "\"", 8604, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                    </div>\r\n                </div>\r\n                <div class=\"blog-card col-lg-4 col-sm-12 \">\r\n                    <img src=\"./Image/Group 29.png\"");
            BeginWriteAttribute("alt", " alt=\"", 8776, "\"", 8782, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""cart-list-item"">
                        <h4>Lorem ipsum dolor sit amet.</h4>
                        <small>January 28, 2019</small>
                        <p>
                            Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatum a amet reiciendis
                            quidem?
                        </p>
                        <a href=""#"">Read the Post<img src=""./Image/Shape 2.png""");
            BeginWriteAttribute("alt", " alt=\"", 9245, "\"", 9251, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                    </div>\r\n                </div>\r\n                <div class=\"blog-card col-lg-4 col-sm-12 \">\r\n                    <img src=\"./Image/Group 30.png\"");
            BeginWriteAttribute("alt", " alt=\"", 9423, "\"", 9429, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""cart-list-item"">
                        <h4>Lorem ipsum dolor sit amet.</h4>
                        <small>January 28, 2019</small>
                        <p>
                            Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatum a amet reiciendis
                            quidem?
                        </p>
                        <a href=""#"">Read the Post<img src=""./Image/Shape 2.png""");
            BeginWriteAttribute("alt", " alt=\"", 9892, "\"", 9898, 0);
            EndWriteAttribute();
            WriteLiteral(@"></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section class=""container-fluid customers"">
    <div class=""d-flex align-items-center flex-column"">
        <h2 class=""text-center"">What Our Customers Say</h2>
        <div class=""cust-card-wraper justify-content-center row align-items-center"">
            <div class=""cust-card-item position-relative"">
                <img src=""./Image/message.png""");
            BeginWriteAttribute("alt", " alt=\"", 10373, "\"", 10379, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"message-symbol\">\r\n                <div class=\"grid-container\">\r\n                    <div class=\"item1\"><img src=\"./Image/Group 31.png\"");
            BeginWriteAttribute("alt", " alt=\"", 10522, "\"", 10528, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div>
                    <div class=""item2"">
                        <h3>Lary Watson</h3><small>Manchester</small>
                    </div>
                </div>
                <p>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Veniam quos culpa minus laboriosam, sit
                    ea
                    ipsam modi at!
                </p>
                <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nihil, molestiae?</p>
                <a href=""#"">Read the Post<img src=""./Image/Shape 2.png""");
            BeginWriteAttribute("alt", " alt=\"", 11094, "\"", 11100, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n            </div>\r\n            <div class=\"cust-card-item position-relative\">\r\n                <img src=\"./Image/message.png\"");
            BeginWriteAttribute("alt", " alt=\"", 11234, "\"", 11240, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"message-symbol\">\r\n                <div class=\"grid-container\">\r\n                    <div class=\"item1\"><img src=\"./Image/Group 32.png\"");
            BeginWriteAttribute("alt", " alt=\"", 11383, "\"", 11389, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div>
                    <div class=""item2"">
                        <h3>John Smit</h3><small>Manchester</small>
                    </div>
                </div>
                <p>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Veniam quos culpa minus laboriosam, sit
                    ea
                    ipsam modi at!
                </p>
                <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nihil, molestiae?</p>
                <a href=""#"">Read the Post<img src=""./Image/Shape 2.png""");
            BeginWriteAttribute("alt", " alt=\"", 11953, "\"", 11959, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n            </div>\r\n            <div class=\"cust-card-item position-relative\">\r\n                <img src=\"./Image/message.png\"");
            BeginWriteAttribute("alt", " alt=\"", 12093, "\"", 12099, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"message-symbol\">\r\n                <div class=\"grid-container\">\r\n                    <div class=\"item1\"><img src=\"./Image/Group 33.png\"");
            BeginWriteAttribute("alt", " alt=\"", 12242, "\"", 12248, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div>
                    <div class=""item2"">
                        <h3>lars Johnson</h3><small>Manchester</small>
                    </div>
                </div>
                <p>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Veniam quos culpa minus laboriosam, sit
                    ea
                    ipsam modi at!
                </p>
                <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nihil, molestiae?</p>
                <a href=""#"">Read the Post<img src=""./Image/Shape 2.png""");
            BeginWriteAttribute("alt", " alt=\"", 12815, "\"", 12821, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n            </div>\r\n        </div>\r\n        <div class=\"newsletter\">\r\n            <h4>GET OUR NEWSLETTER</h4>\r\n            <div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2765d32336034934f4acd8df0c65c1928da9baa225496", async() => {
                WriteLiteral("\r\n                    <input type=\"email\" name=\"email\" placeholder=\"YOUR EMAIL\" class=\"rounded-pill\">\r\n                    <input type=\"submit\" value=\"Submit\" id=\"submit\" class=\"rounded-pill\">\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</section>
<div class=""scroll-top"">
    <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""20"" height=""10"">
        <Image width=""20"" height=""10""
               xlink:href=""data:img/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAwAAAAHCAQAAACWu2SvAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAAAmJLR0QA/4ePzL8AAAAHdElNRQflCxILOC+3huDXAAAAa0lEQVQI103NoQoCYQDD8VkMggYRLYLFt7rmI10ziMVkEs6m2ZcwWQQRsdh/huM73dL+jC0qjYn8eaSxijNu5h2euuISA0c8LUUs3HEybFt7fMyMvXEQKQMbvDywa8nvsgbrknvSaZt+qhK+nGpkpn2sFJAAAAAASUVORK5CYII="" />
    </svg>
</div>
<div class=""fixed-button"">
    <div class=""message"">
        <img src=""./Image/Layer 598.png""");
            BeginWriteAttribute("alt", " alt=\"", 14027, "\"", 14033, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n    </div>\r\n</div>\r\n");
            DefineSection("policy", async() => {
                WriteLiteral(@"
    <div class=""footer-policy justify-content-center align-items-center position-sticky"">
        <p>
            Lorem ipsum dolor, sit amet consectetur adipisicing elit. Earum blanditiis officiis, doloremque unde harum
            nobis porro non!<a href=""#"">Privacy Policy</a>
        </p>
        <button id=""policy_btn"">OK!</button>
    </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
