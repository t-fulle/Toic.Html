using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Toic.Html
{
    public static class StringBuilderExtensions
    {
        public static readonly Regex HTML_LINEBREAK = new Regex(@"<\s*/?\s*br\s*/?>", RegexOptions.Compiled);

        ///// <summary>
        ///// Adds a paragraph of text to the <paramref name="stringBuilder"/> if the text is neither null nor whitespace
        ///// </summary>
        ///// <param name="stringBuilder"></param>
        ///// <param name="text"></param>
        //public static void AppendParagraph(this StringBuilder stringBuilder, HtmlNode? paragraphNode)
        //{
        //    CheckParagraphNode(paragraphNode);

        //    if (false == string.IsNullOrWhiteSpace(paragraphNode.InnerText))
        //    {
        //        // appendline for every <br>
        //        // appendparagraph for every <p>

        //        stringBuilder.Append(text.Trim());
        //        stringBuilder.AppendLine("<br/><br/>");
        //    }
        //}


        // split into paragraphs <br/> <br/>
        // split into linebreaks

        // add lines
        // add paragraphs

        private static bool IsValidParagraphNode(this HtmlNode? paragraphNode)
        {
            if (paragraphNode is null ||
                paragraphNode.Name != "p" ||
                string.IsNullOrWhiteSpace(paragraphNode.InnerText))
                return false;

            return true;
        }

        private static void CheckParagraphNode(this HtmlNode? paragraphNode)
        {
            if (paragraphNode is null)
                throw new ArgumentNullException(nameof(paragraphNode));

            if (paragraphNode.Name != "p")
                throw new ArgumentException("Given node is not a paragraph node (<p>)!");
        }
    }
}
