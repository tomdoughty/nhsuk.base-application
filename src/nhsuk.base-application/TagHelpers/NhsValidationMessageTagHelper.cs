using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace nhsuk.base_application.TagHelpers
{
    [HtmlTargetElement("span", Attributes = CustomAttribute.NhsValidationFor)]
    public class NhsValidationMessageTagHelper : ValidationMessageTagHelper
    {
        private const string DataValidationForAttributeName = "data-nhs-valmsg-for";

        public NhsValidationMessageTagHelper(IHtmlGenerator generator)
          : base(generator)
        {
        }

        public override int Order => -1000;

        [HtmlAttributeName(CustomAttribute.NhsValidationFor)]
        public new ModelExpression For { get; set; }

        [DebuggerStepThrough]
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            if (For != null)
            {
                IDictionary<string, object> htmlAttributes = null;
                if (string.IsNullOrEmpty(For.Name) &&
                    string.IsNullOrEmpty(ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix) &&
                    output.Attributes.ContainsName(DataValidationForAttributeName))
                {
                    htmlAttributes = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                    {
                        { DataValidationForAttributeName, "-non-empty-value-" },
                    };
                }

                string message = null;
                if (!output.IsContentModified)
                {
                    var tagHelperContent = await output.GetChildContentAsync();

                    if (!tagHelperContent.IsEmptyOrWhiteSpace)
                    {
                        message = tagHelperContent.GetContent();
                    }
                }
                var tagBuilder = Generator.GenerateValidationMessage(
                    ViewContext,
                    For.ModelExplorer,
                    For.Name,
                    message,
                    null,
                    htmlAttributes);

                if (tagBuilder != null)
                {
                    output.MergeAttributes(tagBuilder);

                    // Do not update the content if another tag helper targeting this element has already done so.
                    if (!output.IsContentModified && tagBuilder.HasInnerHtml)
                    {
                        output.AddClass("nhsuk-error-message", HtmlEncoder.Default);

                        var content = new DefaultTagHelperContent()
                            .AppendHtml(new HtmlString("<span class=\"nhsuk-u-visually-hidden\">Error:</span>"))
                            .AppendHtml(tagBuilder.InnerHtml);

                        output.Content.SetHtmlContent(content);
                    }
                }
            }
        }
    }
}
