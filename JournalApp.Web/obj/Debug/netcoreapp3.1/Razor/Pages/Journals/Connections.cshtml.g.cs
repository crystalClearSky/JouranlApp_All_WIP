#pragma checksum "C:\Code\Projects\JournalAppProject\JournalApp.Web\Pages\Journals\Connections.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "409dd27c77595f81c97499048bf58cc891bfe2db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(JournalApp.Web.Pages.Journals.Pages_Journals_Connections), @"mvc.1.0.razor-page", @"/Pages/Journals/Connections.cshtml")]
namespace JournalApp.Web.Pages.Journals
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
#line 1 "C:\Code\Projects\JournalAppProject\JournalApp.Web\Pages\_ViewImports.cshtml"
using JournalApp.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{connectionId:int}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"409dd27c77595f81c97499048bf58cc891bfe2db", @"/Pages/Journals/Connections.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d634af4fcafe35eae944122a87ed70949e662be", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Journals_Connections : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Code\Projects\JournalAppProject\JournalApp.Web\Pages\Journals\Connections.cshtml"
  
    ViewData["Title"] = "Connections";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Connections</h1>\r\n");
#nullable restore
#line 8 "C:\Code\Projects\JournalAppProject\JournalApp.Web\Pages\Journals\Connections.cshtml"
 if (Model.People != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Code\Projects\JournalAppProject\JournalApp.Web\Pages\Journals\Connections.cshtml"
     foreach (var person in Model.People)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>");
#nullable restore
#line 12 "C:\Code\Projects\JournalAppProject\JournalApp.Web\Pages\Journals\Connections.cshtml"
        Write(person.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <br />\r\n");
#nullable restore
#line 14 "C:\Code\Projects\JournalAppProject\JournalApp.Web\Pages\Journals\Connections.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Code\Projects\JournalAppProject\JournalApp.Web\Pages\Journals\Connections.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No connections found!</p>\r\n");
#nullable restore
#line 19 "C:\Code\Projects\JournalAppProject\JournalApp.Web\Pages\Journals\Connections.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JournalApp.Web.Pages.Journals.ConnectionsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<JournalApp.Web.Pages.Journals.ConnectionsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<JournalApp.Web.Pages.Journals.ConnectionsModel>)PageContext?.ViewData;
        public JournalApp.Web.Pages.Journals.ConnectionsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
