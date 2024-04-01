using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toic.Html
{
    /// <summary>
    /// </summary>
    public static class HtmlNodeExtensions
    {
        public static HtmlNodeCollection SelectParagraphNodes(this HtmlNode node)
            => node.SelectNodes("//p[not(.//p)]");
        //=> node.SelectNodes("//p[not(.//p)]");




        //The XPath to the innermost<p> element would be //p[not(.//p)]. This selects all <p> elements that do not have any <p> elements as descendants. Is there anything else you would like to know about XPath?

            //=> node.SelectNodes("//p"); // Selects all paragraph nodes and selects them double for paragraph in paragraph
    }
}
