using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Globalization;
using System.IO;
using System.Collections;
using Negatic.WebScrapping;
using HtmlAgilityPack;

namespace HtmlAgilityPack_Elu
{
    public class HtmlAgilityPack_Elu
    {

        [Fact]
        public void Text()
        {
            string html = "<p><strong><em><b><i>Thuck!</i></b></em></strong><strong><em><b><i><br> </i></b></em></strong><strong><em><b><i><br> </i></b></em></strong>After the bone spear missed, it killed a player who had no time to evade.</p>";

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var selectedNodes = htmlDocument.DocumentNode.SelectNodes("//p");

            foreach (var node in selectedNodes)
            {
                var textnodes = node.SelectNodes("text()");
                //string content = node.InnerText;
                string content = textnodes.First().InnerText;

            }

            //var textnodes = node.DescendantsAndSelf("text()");
            //var textnodes = node.DescendantsAndSelf("//p/*");


            //var node = htmlDocument.DocumentNode;

            //webPage.SelectNodes("")

            //string? result = text.DeleteLine(index);
            //Assert.Equal(expected, result);
        }

        

    }
}
