using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using nhuk.base_application.Extensions;

namespace nhsuk.base_application.TagHelpers
{
    [HtmlTargetElement("input", Attributes = CustomAttribute.ErrorClassToggle, TagStructure = TagStructure.WithoutEndTag)]
    public class ErrorClassToggleTagHelper : TagHelper
    {
        [HtmlAttributeName(CustomAttribute.ErrorClassToggle)]
        public string Class { get; set; }

        [HtmlAttributeName(CustomAttribute.ErrorOr)]
        public bool? Or { get; set; }

        [HtmlAttributeName(CustomAttribute.AspFor)]
        public ModelExpression For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Class != null && (Or == true || For != null && ViewContext!.ViewData.ModelState.HasError(For?.Name)))
            {
                output.AddClass(Class, HtmlEncoder.Default);
            }
        }
    }
}
