using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Globalization;
using System.IO;
using System.Collections;
using HtmlAgilityPack;
using Toic.Html;

namespace HtmlNodeExtensions
{
    public class SelectParagraphNodes_Tests
    {
        public static TheoryData<string, string[]> SelectParagraphNodes_TestData =>
            new TheoryData<string, string[]>
            {
                // Html, outer html of the paragraphs
                { "<p></p>", new string[] { "<p></p>" } },
                { "", new string[] { } },
                { "<p></p><p></p>", new string[] { "<p></p>", "<p></p>" } },
                { "<p>Text One</p><p>Text Two</p>", new string[] { "<p>Text One</p>", "<p>Text Two</p>" } },
                { "<p>Text One</p><p>Text Two</p><p>Text Three</p>", new string[] { "<p>Text One</p>", "<p>Text Two</p>", "<p>Text Three</p>" } },
                { "<div><p>Text One</p><p>Text Two</p><p>Text Three</p></div>", new string[] { "<p>Text One</p>", "<p>Text Two</p>", "<p>Text Three</p>" } },
                { "<div><p>Text One</p></div><div><p>Text Two</p><p>Text Three</p></div>", new string[] { "<p>Text One</p>", "<p>Text Two</p>", "<p>Text Three</p>" } },
            };

        //            string html = "<p><strong><em><b><i>Thuck!</i></b></em></strong><strong><em><b><i><br> </i></b></em></strong><strong><em><b><i><br> </i></b></em></strong>After the bone spear missed, it killed a player who had no time to evade.</p>";


        //"<p><span><span>SPAM1</span>CONTENT<span>SPAM2</span></span></p>"

        //public static IEnumerable<object[]> SelectParagraphNodes_TestData2()
        //{
        //    yield return new object[] {
        //        // Html, outer html of the paragraphs
        //        "<p></p>", new string[] { "<p></p>" }};
        //    yield return new object[] {
        //        "", new string[] { },
        //    };
        //    //yield return new object[] { "some string", 16, false };
        //    //yield return new object[] { 17, 17, false };
        //    //yield return new object[] { new object(), 19, false };
        //}

        // remove nodes with empty content
        // remove nodes with spam content
        // keep nodes with content like <i> or <b>

        [Theory]
        [MemberData(nameof(SelectParagraphNodes_TestData))]
        public void SelectParagraphNodes_Test(string html, string[] outerHtmls)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var paragraphNodes = htmlDocument.DocumentNode.SelectParagraphNodes();

            if (paragraphNodes is null)
                Assert.Empty(outerHtmls);
            else
            {
                Assert.Equal(outerHtmls.Length, paragraphNodes.Count());

                for (int i = 0; i < outerHtmls.Length; i++)
                    Assert.Equal(outerHtmls[i], paragraphNodes[i].OuterHtml);
            }
        }
    }
}
