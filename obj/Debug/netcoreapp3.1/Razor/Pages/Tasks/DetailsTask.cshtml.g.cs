#pragma checksum "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf25943a0cd2a00480e29e72014f6181a338c163"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GrupoESINuevo.Pages.Tasks.Pages_Tasks_DetailsTask), @"mvc.1.0.razor-page", @"/Pages/Tasks/DetailsTask.cshtml")]
namespace GrupoESINuevo.Pages.Tasks
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
#line 1 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\_ViewImports.cshtml"
using GrupoESINuevo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\_ViewImports.cshtml"
using GrupoESINuevo.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf25943a0cd2a00480e29e72014f6181a338c163", @"/Pages/Tasks/DetailsTask.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c05fdf156f84b5850b9a139830f796172b8cbc08", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Tasks_DetailsTask : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("inputPicFile"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "file", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("accept", new global::Microsoft.AspNetCore.Html.HtmlString("image/*"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("checkIfPicIsEmpty()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Picture", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Agregar foto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./EditTask", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/../Quotations/CreateQuotation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>TaskModel</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
       Write(Html.DisplayNameFor(model => model.taskPicVM.taskModel.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
       Write(Html.DisplayFor(model => model.taskPicVM.taskModel.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
       Write(Html.DisplayNameFor(model => model.taskPicVM.taskModel.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
       Write(Html.DisplayFor(model => model.taskPicVM.taskModel.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
       Write(Html.DisplayNameFor(model => model.taskPicVM.taskModel.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
       Write(Html.DisplayFor(model => model.taskPicVM.taskModel.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
       Write(Html.DisplayNameFor(model => model.taskPicVM.taskModel.Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
       Write(Html.DisplayFor(model => model.taskPicVM.taskModel.Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n");
#nullable restore
#line 40 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
 if (Model.taskPicVM.taskModel.Pictures.Count > 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
     for (int i = 0; i < Model.taskPicVM.taskModel.Pictures.Count; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 1341, "\"", 1447, 2);
            WriteAttributeValue("", 1347, "data:image;base64,", 1347, 18, true);
#nullable restore
#line 45 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
WriteAttributeValue("", 1365, System.Convert.ToBase64String(Model.taskPicVM.taskModel.Pictures[i].PictureBytes), 1365, 82, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:400px; height:400px;\" />\r\n            <label class=\"_deletePictureId\" hidden>");
#nullable restore
#line 46 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
                                              Write(Model.taskPicVM.taskModel.Pictures[i].PictureId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            <label class=\"_taskId\" hidden>");
#nullable restore
#line 47 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
                                     Write(Model.taskPicVM.taskModel.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            <label class=\"_orderDetailsId\" hidden>");
#nullable restore
#line 48 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
                                             Write(Model.taskPicVM.taskModel.QuotationModel.OrderDetailsModel.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            <label>Borrar foto </label><input type=\"checkbox\" class=\"_checkbox\" />\r\n        </div>\r\n");
#nullable restore
#line 51 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf25943a0cd2a00480e29e72014f6181a338c16313692", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bf25943a0cd2a00480e29e72014f6181a338c16313959", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 55 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.taskPicVM.taskModel.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <p>Subir foto </p>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bf25943a0cd2a00480e29e72014f6181a338c16315827", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 57 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.taskPicVM.Upload);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bf25943a0cd2a00480e29e72014f6181a338c16317732", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <button onclick=\"OnClickDeletePic()\" value=\"Borrar foto\" class=\"btn btn-danger\">Borrar fotos</button>\r\n</div>\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf25943a0cd2a00480e29e72014f6181a338c16320684", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-taskId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 67 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
                                   WriteLiteral(Model.taskPicVM.taskModel.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["taskId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-taskId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["taskId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf25943a0cd2a00480e29e72014f6181a338c16322878", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-orderDetailsId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
                                                               WriteLiteral(Model.taskPicVM.taskModel.QuotationModel.OrderDetailsModel.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["orderDetailsId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-orderDetailsId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["orderDetailsId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 71 "C:\Users\Gonzo\source\repos\GrupoESINuevo\GrupoESINuevo\Pages\Tasks\DetailsTask.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <script src=""https://unpkg.com/sweetalert/dist/sweetalert.min.js""></script>
    <script>
        function checkIfPicIsEmpty()
        {
            if (document.getElementById(""inputPicFile"").files.length == 0) {
                swal(""Error!"", ""no files selected"", ""error"");
                evt.preventDefault();
            } else
            {

            }

        }
        function OnClickDeletePic() {
            var checkBoxes = document.getElementsByClassName('_checkbox');
            var pictureIds = document.getElementsByClassName('_deletePictureId');
            var taskId = document.getElementsByClassName('_taskId');
            var orderDetailsId = document.getElementsByClassName('_orderDetailsId');
            var listaIds = {
                listaIds: """"
            };
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].checked == true) {
                    listaIds.listaIds += pictureIds[i].innerText;
                    lista");
                WriteLiteral(@"Ids.listaIds += "","";
                }
            }
            listaIds.listaIds = listaIds.listaIds.substring(0, listaIds.listaIds.length - 1);
            console.log(listaIds);
            console.log(checkBoxes);
            console.log(pictureIds);
            var json = {
                deletePicturesId: listaIds.listaIds,
                taskId: taskId[0].innerText,
                orderDetailsId: orderDetailsId[0].innerText
            };
            console.log(json.deletePicturesId);
            if (json.deletePicturesId != """") {
                $.ajax({
                    type: ""POST"",
                    url: ""/api/ManageOrders/PostDeletePictures"",
                    contentType: ""application/json"",
                    datatype: ""json"",
                    data: JSON.stringify(json)
                }).then(() => { windows.location.href = ""/Tasks/DetailsTask?taskId="" + taskId[0].innerText });
            }
            else
            {
                swal(""error!"", ""s");
                WriteLiteral(@"eleccione una foto"", ""error"");
            }

            if (listaIds.count > 0) {

            }
        }
        $(function () {
            $('#submit').on('click', function (evt) {
                //evt.preventDefault();
                var checkBoxes = document.getElementsByClassName('_checkbox');
                var pictureIds = document.getElementsByClassName('_deletePictureId');
                var taskId = document.getElementsByClassName('_taskId');
                var orderDetailsId = document.getElementsByClassName('_orderDetailsId');

                var listaIds = {
                    listaIds: """"
                };
                for (var i = 0; i < checkBoxes.length; i++) {
                    if (checkBoxes[i].checked == true) {
                        listaIds.listaIds += pictureIds[i].innerText;
                        listaIds.listaIds += "","";
                    }
                }
                listaIds.listaIds = listaIds.listaIds.substring(0, listaIds.lista");
                WriteLiteral(@"Ids.length - 1);
                console.log(listaIds);
                console.log(checkBoxes);
                console.log(pictureIds);
                var json = {
                    deletePicturesId: listaIds.listaIds,
                    taskId: taskId[0].innerText,
                    orderDetailsId: orderDetailsId[0].innerText
                };
                console.log(json.deletePicturesId);
                if (json.deletePicturesId != """") {
                    $.ajax({
                        type: ""POST"",
                        url: ""/api/ManageOrders/PostDeletePictures"",
                        contentType: ""application/json"",
                        datatype: ""json"",
                        data: JSON.stringify(json)
                    }).then(() => { windows.location.href = ""/Tasks/DetailsTask?taskId="" + taskId[0].innerText });
                }
            });
        });
    </script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GrupoESINuevo.DetailsTaskModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GrupoESINuevo.DetailsTaskModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GrupoESINuevo.DetailsTaskModel>)PageContext?.ViewData;
        public GrupoESINuevo.DetailsTaskModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
