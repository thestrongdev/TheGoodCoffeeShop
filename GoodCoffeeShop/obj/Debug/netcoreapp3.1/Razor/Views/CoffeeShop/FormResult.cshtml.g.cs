#pragma checksum "C:\Users\goods\source\repos\GoodCoffeeShop\GoodCoffeeShop\Views\CoffeeShop\FormResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf473527ee7a840761696a72293cb7e979e58e63"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CoffeeShop_FormResult), @"mvc.1.0.view", @"/Views/CoffeeShop/FormResult.cshtml")]
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
#line 1 "C:\Users\goods\source\repos\GoodCoffeeShop\GoodCoffeeShop\Views\_ViewImports.cshtml"
using GoodCoffeeShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\goods\source\repos\GoodCoffeeShop\GoodCoffeeShop\Views\_ViewImports.cshtml"
using GoodCoffeeShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf473527ee7a840761696a72293cb7e979e58e63", @"/Views/CoffeeShop/FormResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"affe43ffa6f701d5b42caa75927584d2f88ca1a2", @"/Views/_ViewImports.cshtml")]
    public class Views_CoffeeShop_FormResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GoodCoffeeShop.Models.CoffeeShop.FormResultViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1>Welcome ");
#nullable restore
#line 9 "C:\Users\goods\source\repos\GoodCoffeeShop\GoodCoffeeShop\Views\CoffeeShop\FormResult.cshtml"
       Write(Model.theUser.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</h1>\r\n<h3>Please see your submission below. Sensitive information such as your password has been omitted.</h3>\r\n<br />\r\n\r\n<p>First Name: ");
#nullable restore
#line 13 "C:\Users\goods\source\repos\GoodCoffeeShop\GoodCoffeeShop\Views\CoffeeShop\FormResult.cshtml"
          Write(Model.theUser.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Last Name: ");
#nullable restore
#line 14 "C:\Users\goods\source\repos\GoodCoffeeShop\GoodCoffeeShop\Views\CoffeeShop\FormResult.cshtml"
         Write(Model.theUser.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Email: ");
#nullable restore
#line 15 "C:\Users\goods\source\repos\GoodCoffeeShop\GoodCoffeeShop\Views\CoffeeShop\FormResult.cshtml"
     Write(Model.theUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Phone Number: ");
#nullable restore
#line 16 "C:\Users\goods\source\repos\GoodCoffeeShop\GoodCoffeeShop\Views\CoffeeShop\FormResult.cshtml"
            Write(Model.theUser.PhoneNum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GoodCoffeeShop.Models.CoffeeShop.FormResultViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591