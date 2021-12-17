#pragma checksum "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e2730711cf1bdd249c364e99f90e3f6396900b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Company_Index), @"mvc.1.0.view", @"/Views/Company/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e2730711cf1bdd249c364e99f90e3f6396900b6", @"/Views/Company/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7222ccf4b11389339ddcb95f3e4018a84485339b", @"/Views/_ViewImports.cshtml")]
    public class Views_Company_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CompanyViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
  
    ViewData["Title"] = "Company";
   
    


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main class=""row"">
    <div class=""col-lg-3 left-side company-left"">
        <aside class=""company-aside"">
            <div class=""sidebar-company"">
                <div class=""container"">
                    <div class=""row"">
                        <div class=""sidebar-items"">
                            <div class=""sidebar-item"">
                                <ul>
");
#nullable restore
#line 20 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
                                     foreach (var category in Model.CompanyCategories)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li><a");
            BeginWriteAttribute("href", " href=\"", 640, "\"", 647, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 22 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
                                                  Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 23 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </aside>
    </div>
    <!--Info-->
    <div class=""col-lg-9 col-md-12"">
        <!--Dropdown-->
        <section id=""dropdown"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""company-category"">
                        <div class=""company-category-head"">
                            <h5>Companies</h5>
                            <img src=""./assets/images/arrow-down.svg""");
            BeginWriteAttribute("alt", " alt=\"", 1339, "\"", 1345, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </div>\r\n                        <ul class=\"drop-menu\" style=\"display: none;\">\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1486, "\"", 1493, 0);
            EndWriteAttribute();
            WriteLiteral(">All Company</a></li>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1551, "\"", 1558, 0);
            EndWriteAttribute();
            WriteLiteral(">Personalized Company</a></li>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1625, "\"", 1632, 0);
            EndWriteAttribute();
            WriteLiteral(">The Silver Company</a></li>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1697, "\"", 1704, 0);
            EndWriteAttribute();
            WriteLiteral(">Company Under $150</a></li>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1769, "\"", 1776, 0);
            EndWriteAttribute();
            WriteLiteral(">Company Under $250</a></li>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1841, "\"", 1848, 0);
            EndWriteAttribute();
            WriteLiteral(">Company Under $500</a></li>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1913, "\"", 1920, 0);
            EndWriteAttribute();
            WriteLiteral(">Company Over $500</a></li>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1984, "\"", 1991, 0);
            EndWriteAttribute();
            WriteLiteral(@">Company for Him</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>
        <!--Section Info-->
        <section id=""info"">
            <div class=""container-fluid"">
                <div class=""row"">
                    <div class=""col-lg-12"">
                        <div class=""company-info"">
                            <div class=""info-img"">
                                <img src=""./assets/images/company-head.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 2502, "\"", 2508, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </section>\r\n        <!--Personilazed Company-->\r\n\r\n");
#nullable restore
#line 74 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
         for (int i = 0; i < Model.Companies.Count; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <section id=\"favory\">\r\n                <div class=\"favory-title\">\r\n                    <h2>");
#nullable restore
#line 78 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
                   Write(Model.Companies[i].CompanyCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                </div>
                <div class=""container"">
                    <div class=""row"">
                        <div class=""col-md-4"">
                            <div class=""favory-item"">
                                <div class=""card-image"">
                                    <div class=""img-product"">
                                        <div class=""content-colors""");
            BeginWriteAttribute("id", " id=\"", 3325, "\"", 3352, 1);
#nullable restore
#line 86 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
WriteAttributeValue("", 3330, Model.Companies[i].Id, 3330, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 87 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
                                             for (int j = 0; j < Model.Companies[i].Product.ProductColors.Count; j++)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <div");
            BeginWriteAttribute("class", " class=\"", 3574, "\"", 3615, 2);
            WriteAttributeValue("", 3582, "content-color", 3582, 13, true);
#nullable restore
#line 89 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
WriteAttributeValue(" ", 3595, j==0?"active":"", 3596, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 3616, "\"", 3676, 1);
#nullable restore
#line 89 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
WriteAttributeValue("", 3621, Model.Companies[i].Product.ProductColors[j].Color.Name, 3621, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                    <a href=\"./detail.html\">\r\n                                                        <img");
            BeginWriteAttribute("src", " src=\"", 3818, "\"", 3950, 2);
            WriteAttributeValue("", 3824, "./assets/images/", 3824, 16, true);
#nullable restore
#line 91 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
WriteAttributeValue("", 3840, Model.Companies[i].Product.ProductColors[j].ProductColorImages.FirstOrDefault(x=>x.PosterStatus==true)?.Image, 3840, 110, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-responsive\">\r\n                                                        <img");
            BeginWriteAttribute("src", " src=\"", 4037, "\"", 4170, 2);
            WriteAttributeValue("", 4043, "./assets/images/", 4043, 16, true);
#nullable restore
#line 92 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
WriteAttributeValue("", 4059, Model.Companies[i].Product.ProductColors[j].ProductColorImages.FirstOrDefault(x=>x.PosterStatus==false)?.Image, 4059, 111, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                                             class=\"img-responsive-hov\">\r\n                                                    </a>\r\n                                                </div>\r\n");
#nullable restore
#line 96 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </div>
                                    </div>
                                    <div class=""hover-btns"">
                                        <a class=""single-btn add-basket"">
                                            <i class=""fas fa-shopping-basket""></i>
                                        </a>
                                        <a href=""wishlist.html"" class=""single-btn"">
                                            <i class=""far fa-heart""></i>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class=""fav-info"">
                                <a");
            BeginWriteAttribute("href", " href=\"", 5194, "\"", 5201, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <h2 class=\"basket-head\">");
#nullable restore
#line 111 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
                                                       Write(Model.Companies[i].Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                                </a>\r\n                                <p>\r\n                                    <span>$</span>\r\n                                    ");
#nullable restore
#line 115 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
                               Write(Model.Companies[i].Product.SalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n                            </div>\r\n                            <div class=\"fav-color\">\r\n                                <div class=\"color-items\" data-id=\"");
#nullable restore
#line 119 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
                                                             Write(Model.Companies[i].Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n");
#nullable restore
#line 120 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
                                     for (int d = 0; d < Model.Companies[i].Product.ProductColors.Count; d++)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"color-item\">\r\n                                            <a");
            BeginWriteAttribute("class", " class=\"", 5987, "\"", 6024, 2);
            WriteAttributeValue("", 5995, "tab-color", 5995, 9, true);
#nullable restore
#line 123 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
WriteAttributeValue(" ", 6004, d==0?"active":"", 6005, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-target=\"");
#nullable restore
#line 123 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
                                                                                             Write(Model.Companies[i].Product.ProductColors[d].Color.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                                <img");
            BeginWriteAttribute("src", " src=\"", 6150, "\"", 6234, 2);
            WriteAttributeValue("", 6156, "./assets/images/color/", 6156, 22, true);
#nullable restore
#line 124 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"
WriteAttributeValue("", 6178, Model.Companies[i].Product.ProductColors[d].Color.Image, 6178, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 6235, "\"", 6241, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            </a>\r\n                                        </div>\r\n");
#nullable restore
#line 127 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n");
            WriteLiteral("                            </div>\r\n                        </div>\r\n\r\n                    </div>\r\n                </div>\r\n            </section>\r\n");
#nullable restore
#line 137 "C:\Users\LENOVO\Desktop\Final-Back-end-project\Mejuri-Back-end\Mejuri-Back-end\Views\Company\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n</main>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CompanyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
