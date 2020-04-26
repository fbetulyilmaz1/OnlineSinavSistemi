using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinavSistemi.UI.CustomTagHelpers
{
    [HtmlTargetElement("my-s-o")]
    public class MySOTagHelper :TagHelper
    {

        [HtmlAttributeName("lst-for")]
        public List<Brans> BransList { get; set; }

        public ModelExpression AspFor { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {   
            output.TagName = "select";
            output.TagMode = TagMode.StartTagAndEndTag;
            if(!String.IsNullOrEmpty(this.AspFor.Name))
            {
                output.Attributes.Add("name", this.AspFor.Name);
                output.Attributes.Add("class", "form-control");
            }

            var sb = new StringBuilder();
            this.BransList.ForEach(x => sb.AppendFormat("<option value='"+x.Id+"'>"+x.Ad+"</option>"));
            output.PreContent.SetHtmlContent(sb.ToString());
        }
    }
}
