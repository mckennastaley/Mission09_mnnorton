﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission09_mnnorton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mnnorton.Infrastructure
{
    [HtmlTargetElement("div", Attributes= "page-blah")]
    public class PagenationTagHelpercs : TagHelper
    {
        //dynamically make page links

        private IUrlHelperFactory uhf;

        public PagenationTagHelpercs(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }


        //different from view context:
        public PageInfo PageBlah { get; set; }
        public string PageAction { get; set; }


        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i <= PageBlah.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }

            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
