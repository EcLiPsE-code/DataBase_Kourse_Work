#pragma checksum "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7976cedae04beefb37ad9ae7a4def20dbadedc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UnitValuationPlans_Index), @"mvc.1.0.view", @"/Views/UnitValuationPlans/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UnitValuationPlans/Index.cshtml", typeof(AspNetCore.Views_UnitValuationPlans_Index))]
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
#line 1 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\_ViewImports.cshtml"
using Company;

#line default
#line hidden
#line 2 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\_ViewImports.cshtml"
using Company.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7976cedae04beefb37ad9ae7a4def20dbadedc8", @"/Views/UnitValuationPlans/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7476266b3089f8d281ffba0e0ee7fc97e38e65ee", @"/Views/_ViewImports.cshtml")]
    public class Views_UnitValuationPlans_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CompanyASP.Models.UnitValuationPlan>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(57, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(147, 16, true);
            WriteLiteral("    <html>\r\n    ");
            EndContext();
            BeginContext(163, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ef9bdc4f7b54e73905dc809453df566", async() => {
                BeginContext(169, 64, true);
                WriteLiteral("\r\n        <title>Плановые показатели подразделений</title>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(240, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(246, 1211, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4580ee4b668540b599dfe6613e30ddfe", async() => {
                BeginContext(252, 386, true);
                WriteLiteral(@"
        <h3>Плановые показатели</h3>
        <table>
            <tr>
                <td>Код плановых показателей</td>
                <td>Название подразделения</td>
                <td>Затраты на подразделения</td>
                <td>Доходы от подразделения</td>
                <td>Фактические затраты</td>
                <td>Фактические доходы</td>
            </tr>
");
                EndContext();
#line 22 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
             foreach (var plan in Model)
            {

#line default
#line hidden
                BeginContext(695, 46, true);
                WriteLiteral("                <tr>\r\n                    <td>");
                EndContext();
                BeginContext(742, 24, false);
#line 25 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
                   Write(plan.UnitValuationPlanID);

#line default
#line hidden
                EndContext();
                BeginContext(766, 31, true);
                WriteLiteral("</td>\r\n                    <td>");
                EndContext();
                BeginContext(798, 13, false);
#line 26 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
                   Write(plan.FullName);

#line default
#line hidden
                EndContext();
                BeginContext(811, 31, true);
                WriteLiteral("</td>\r\n                    <td>");
                EndContext();
                BeginContext(843, 11, false);
#line 27 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
                   Write(plan.Profit);

#line default
#line hidden
                EndContext();
                BeginContext(854, 31, true);
                WriteLiteral("</td>\r\n                    <td>");
                EndContext();
                BeginContext(886, 11, false);
#line 28 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
                   Write(plan.Salary);

#line default
#line hidden
                EndContext();
                BeginContext(897, 31, true);
                WriteLiteral("</td>\r\n                    <td>");
                EndContext();
                BeginContext(929, 29, false);
#line 29 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
                   Write(plan.UnitValuationFact.Profit);

#line default
#line hidden
                EndContext();
                BeginContext(958, 31, true);
                WriteLiteral("</td>\r\n                    <td>");
                EndContext();
                BeginContext(990, 29, false);
#line 30 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
                   Write(plan.UnitValuationFact.Salary);

#line default
#line hidden
                EndContext();
                BeginContext(1019, 57, true);
                WriteLiteral("</td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(1076, 79, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a91898e6f75e413da5fb80e4c1171667", async() => {
                    BeginContext(1138, 13, true);
                    WriteLiteral("Редактировать");
                    EndContext();
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
#line 32 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
                                               WriteLiteral(plan.UnitValuationPlanID);

#line default
#line hidden
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
                EndContext();
                BeginContext(1155, 28, true);
                WriteLiteral(" |\r\n                        ");
                EndContext();
                BeginContext(1183, 75, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "762d905fd8784271bebac58220b8baab", async() => {
                    BeginContext(1248, 6, true);
                    WriteLiteral("Детали");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 33 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
                                                  WriteLiteral(plan.UnitValuationPlanID);

#line default
#line hidden
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
                EndContext();
                BeginContext(1258, 28, true);
                WriteLiteral(" |\r\n                        ");
                EndContext();
                BeginContext(1286, 75, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9e7099cd6e7465eb5605d84f40185c1", async() => {
                    BeginContext(1350, 7, true);
                    WriteLiteral("Удалить");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 34 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
                                                 WriteLiteral(plan.UnitValuationPlanID);

#line default
#line hidden
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
                EndContext();
                BeginContext(1361, 52, true);
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
                EndContext();
#line 37 "D:\Learning\DataBase_KourseWork\DataBase_Kourse_Work\Company\Company\Views\UnitValuationPlans\Index.cshtml"
            }

#line default
#line hidden
                BeginContext(1428, 22, true);
                WriteLiteral("        </table>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1457, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CompanyASP.Models.UnitValuationPlan>> Html { get; private set; }
    }
}
#pragma warning restore 1591
