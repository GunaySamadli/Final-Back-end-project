#pragma checksum "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0096ea13c5d42043508e95f711dd3375f9a7a17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Order_Index), @"mvc.1.0.view", @"/Areas/Manage/Views/Order/Index.cshtml")]
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
#line 1 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\_ViewImports.cshtml"
using Mejuri_Back_end.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\_ViewImports.cshtml"
using Mejuri_Back_end.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0096ea13c5d42043508e95f711dd3375f9a7a17", @"/Areas/Manage/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04be6ebb9a944239226d38f178164dca8cb70475", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("pd-setting-ed"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background:orange;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link-custom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Previous"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:white;font-size:18px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Next"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Index";
    int index = (ViewBag.SelectedPage - 1) * 4;
    int selectedPage = ViewBag.SelectedPage;
    decimal totalPage = ViewBag.TotalPage;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""content-wrapper"" style=""min-height: 1604.71px;"">
    <!-- Content Header (Page header) -->
    <section class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1>Projects</h1>
                </div>
                <div class=""col-sm-6"">
                    <ol class=""breadcrumb float-sm-right"">
                        <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                        <li class=""breadcrumb-item active"">Projects</li>
                    </ol>
                </div>
            </div>
        </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class=""content"">

        <!-- Default box -->
        <div class=""card"">
            <div class=""card-head"">
                <h4>Products List</h4>
            </div>

            <table class=""table table-striped projects"">
                <tbody>
                 ");
            WriteLiteral(@"   <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Full Name</th>
                        <th scope=""col"">Email</th>
                        <th scope=""col"">Item count</th>
                        <th scope=""col"">Total Amount</th>
                        <th scope=""col"">Date</th>
                        <th scope=""col"">Status</th>
                        <th scope=""col"">Setting</th>
                    </tr>
");
#nullable restore
#line 48 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                     foreach (var order in Model)
                    {
                        index++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <th scope=\"row\">");
#nullable restore
#line 52 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                                       Write(index);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <td>");
#nullable restore
#line 53 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                           Write(order.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 54 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                           Write(order.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 55 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                           Write(order.OrderItems.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 56 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                           Write(order.TotalAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 57 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                           Write(order.CreatedAt.AddHours(4).ToString("HH:mm dd MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <h5>\r\n                                    <span");
            BeginWriteAttribute("class", " class=\"", 2319, "\"", 2498, 3);
            WriteAttributeValue("", 2327, "badge", 2327, 5, true);
            WriteAttributeValue(" ", 2332, "badge-", 2333, 7, true);
#nullable restore
#line 60 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
WriteAttributeValue("", 2339, order.Status== Mejuri_Back_end.Models.Enums.OrderStatus.Accepted?"success":order.Status == Mejuri_Back_end.Models.Enums.OrderStatus.Rejected?"danger":"info", 2339, 159, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
#nullable restore
#line 61 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                                    Write(order.Status== Mejuri_Back_end.Models.Enums.OrderStatus.Accepted?"accepted":order.Status == Mejuri_Back_end.Models.Enums.OrderStatus.Rejected?"rejected":"pending");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </span>\r\n                                </h5>\r\n                            </td>\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0096ea13c5d42043508e95f711dd3375f9a7a1712387", async() => {
                WriteLiteral("<i class=\"fas fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                                                       WriteLiteral(order.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 69 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n            <div class=\"d-flex justify-content-center\" style=\"margin-top:3rem;\">\r\n                <nav aria-label=\"Page navigation example\">\r\n                    <ul class=\"pagination align-items-center\">\r\n");
#nullable restore
#line 74 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                         if (selectedPage > 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"page-item \">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0096ea13c5d42043508e95f711dd3375f9a7a1715739", async() => {
                WriteLiteral(@"
                                    <span style=""outline: none; background: none; font-size: 30px; color: black;margin-right:8px; "" aria-hidden=""true"">&laquo;</span>
                                    <span class=""sr-only"">Previous</span>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 77 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                                                                                    WriteLiteral(selectedPage - 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </li>\r\n");
#nullable restore
#line 82 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                          
                            int startPage = (selectedPage == 1 || totalPage <= 3) ? 1 : selectedPage < totalPage ? selectedPage - 1 : selectedPage - 2;
                            int endPage = totalPage > 2 ? startPage + 2 : (int)totalPage;
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 88 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                         for (int i = startPage; i <= endPage; i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li style=\"width: 40px; height: 40px; background-color: #4f5962; border-radius: 50%; margin-right: 5px; display: flex; align-items: center; justify-content: center; \"");
            BeginWriteAttribute("class", " class=\"", 4540, "\"", 4578, 1);
#nullable restore
#line 90 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
WriteAttributeValue("", 4548, i==selectedPage?"active":"", 4548, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0096ea13c5d42043508e95f711dd3375f9a7a1720164", async() => {
#nullable restore
#line 90 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 90 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                                                                                                                                                                                                                                                                    WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 90 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                                                                                                                                                                                                                                                                                          WriteLiteral(ViewBag.CurrentSearch);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["search"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-search", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["search"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 91 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                         if (selectedPage < totalPage)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"page-item-custom\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0096ea13c5d42043508e95f711dd3375f9a7a1724948", async() => {
                WriteLiteral(@"
                                    <span style=""outline: none; background: none; font-size: 30px; color: black; margin-left:3px; "" aria-hidden=""true"">&raquo;</span>
                                    <span class=""sr-only"">Next</span>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 95 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                                                                                    WriteLiteral(selectedPage+1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </li>\r\n");
#nullable restore
#line 100 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Areas\Manage\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </ul>\r\n                </nav>\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <!-- /.card -->\r\n\r\n    </section>\r\n    <!-- /.content -->\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
