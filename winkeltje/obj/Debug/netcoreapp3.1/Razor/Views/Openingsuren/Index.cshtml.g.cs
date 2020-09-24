#pragma checksum "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e5a975cf09b07864d3bbeb40ced07a8973e03c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Openingsuren_Index), @"mvc.1.0.view", @"/Views/Openingsuren/Index.cshtml")]
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
#line 1 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\_ViewImports.cshtml"
using winkeltje;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\_ViewImports.cshtml"
using winkeltje.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
using Domain;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e5a975cf09b07864d3bbeb40ced07a8973e03c0", @"/Views/Openingsuren/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6969ca3e9e70af329da65138d8278c3da22288d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Openingsuren_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OpeningsurenModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
  
    ViewBag.Title = "Openingsuren";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 9 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<br/>\r\n");
#nullable restore
#line 11 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
  
    if (Model.HeeftVakantie)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>");
#nullable restore
#line 14 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
      Write(Model.Vakantie.GetVakantieString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 15 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
    }else if (Model.IsGeopend)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>De winkel is geopend!</p>\r\n");
#nullable restore
#line 18 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>De winkel is gesloten!</p>\r\n");
#nullable restore
#line 22 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\" id=\"table\">\r\n    <tr>\r\n        <th>Dag van de week</th>\r\n        <th style=\"text-align: center\">Voormiddag</th>\r\n        <th></th>\r\n        <th style=\"text-align: center\">Namiddag</th>\r\n    </tr>\r\n    \r\n");
#nullable restore
#line 32 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
      
        foreach (OpeningsUur openingsUur in @Model.OpeningsUren)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 36 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
               Write(openingsUur.Dag);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            \r\n                <td style=\"text-align: center\">");
#nullable restore
#line 38 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
                                          Write(openingsUur.getVoormiddagString(openingsUur.Dag));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td></td>\r\n                <td style=\"text-align: center\">");
#nullable restore
#line 40 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
                                          Write(openingsUur.getNamiddagString(openingsUur.Dag));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 42 "E:\Jens\Documents\GitHub\Matthi\winkeltje\Views\Openingsuren\Index.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OpeningsurenModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
