#pragma checksum "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9be92bc3c1d72a9ce4b8f137b34561dedfd480b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__BasketPartial), @"mvc.1.0.view", @"/Views/Shared/_BasketPartial.cshtml")]
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
#line 1 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\_ViewImports.cshtml"
using Mejuri_Back_end;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\_ViewImports.cshtml"
using Mejuri_Back_end.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\_ViewImports.cshtml"
using Mejuri_Back_end.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\_ViewImports.cshtml"
using Mejuri_Back_end.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9be92bc3c1d72a9ce4b8f137b34561dedfd480b", @"/Views/Shared/_BasketPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7222ccf4b11389339ddcb95f3e4018a84485339b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__BasketPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BasketItemViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("delete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "deletefrombasket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
  
    Layout = null;
    double totalCount = 0;
    foreach (var item in Model)
    {
        totalCount += item.Price * item.Count;
    }

    double itemTotalCount = 0;
    foreach (var item in Model)
    {
        itemTotalCount += item.Price * item.Count;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"basket\">\r\n    <div>\r\n        <div class=\"basket-header\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 407, "\"", 414, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fas fa-chevron-left close-basket\"></i>\r\n            </a>\r\n            <span>You\'re Basket</span>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 556, "\"", 563, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                <svg width=""20"" height=""20"" xmlns=""http://www.w3.org/2000/svg""
                     viewBox=""0 0 512 512"">
                    <path d=""M422.2 484.9H90L37.6 189.6h130.3c-4.7 25.5-7.9 48-9.7 62.5-.9 6.9 3.9 13.2 10.8 14.1.5.1 1.1.1 1.7.1 6.2 0 11.6-4.6 12.4-10.9 2.8-22 6.5-44.1 10.5-65.7h126.7c3.7 22.6 6.6 45 8.5 65.2.6 7 6.9 12.1 13.6 11.4 7-.6 11.9-6.7 11.4-13.7-1-11.3-3.6-34.8-7.9-62.9h128.4l-52.1 295.2zM255.5 27.1c25 0 46.7 66.2 60.5 137.3H198.7c16.1-75.7 38.2-137.3 56.8-137.3zm243.6 141.8c-2.4-2.8-6-4.4-9.7-4.4H341.7C328.3 91 302.3 2 255.5 2c-40.8 0-67.4 87.6-82.8 162.4H22.6c-3.7 0-7.2 1.7-9.7 4.4-2.4 2.8-3.4 6.6-2.7 10.3l57 320.4c1 6 6.2 10.4 12.3 10.4h353.2c6.1 0 11.3-4.3 12.3-10.4l56.8-320.4c.7-3.6-.3-7.3-2.7-10.2z"">
                    </path>
                </svg>
        </div>
        <div class=""basket-body"" id=""favorite"" data-favorite-count=""");
#nullable restore
#line 33 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                                                               Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n            <div class=\"container\">\r\n                <div class=\"row\">\r\n");
#nullable restore
#line 36 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"basket-item\">\r\n                            <div class=\"basket-item-content\">\r\n                                <div class=\"col-md-3\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b9be92bc3c1d72a9ce4b8f137b34561dedfd480b8228", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1834, "~/uploads/product/", 1834, 18, true);
#nullable restore
#line 41 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
AddHtmlAttributeValue("", 1852, item.Image, 1852, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"col-md-9\">\r\n                                    <div class=\"name-icon\">\r\n                                        <h2>\r\n                                            ");
#nullable restore
#line 47 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </h2>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b9be92bc3c1d72a9ce4b8f137b34561dedfd480b10471", async() => {
                WriteLiteral("\r\n                                            <i class=\"fas fa-times\"></i>\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                                                              Write(item.ProductColorId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                                                                                                                                                  WriteLiteral(item.ProductColorId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"count-price\">\r\n                                        <div class=\"count\">\r\n                                            <span>");
#nullable restore
#line 55 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                                             Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        </div>\r\n                                        <div>\r\n                                            <span class=\"price\">\r\n                                                $ ");
#nullable restore
#line 59 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                                                   if (item.Count == 1)
                                                {
                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                                               Write(item.Price);

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                                                               
                                                }
                                                else
                                                {
                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                                               Write(itemTotalCount);

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                                                                   
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </span>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 73 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>

            <div class=""basket-footer"">
                <div class=""basket-footer-content"">
                    <h3>
                        Total price
                    </h3>
                    <span>
                        $");
#nullable restore
#line 83 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Shared\_BasketPartial.cshtml"
                    Write(totalCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </span>
                </div>
                <div class=""checkout"">
                    <a class=""button button-secondary"" href=""./checkout.html"">
                        Continue to Checkout
                    </a>
                </div>
            </div>
        </div>
    </div>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BasketItemViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
