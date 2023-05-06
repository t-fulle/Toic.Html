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
    public class SplitAtHtmlParagraphBreak_Tests
    {
        public static TheoryData<string, string[]> SplitAtHtmlParagraphBreak_TestData =>
            new TheoryData<string, string[]>
            {
                { "Text<br/><br/>with<br/><br/>paragraph<br/><br/>breaks", new[] { "Text", "with", "paragraph", "breaks" } },
                { "Text<br/><br/>with<br/><br/>paragraph<br/>breaks", new[] { "Text", "with", "paragraph<br/>breaks" } },
                { "Text<br/><br/>with<br/><br/>paragraph <br/> breaks", new[] { "Text", "with", "paragraph <br/> breaks" } },
                { "Text<br />< br />with< br/>< br/>paragraph < br /> breaks", new[] { "Text", "with", "paragraph < br /> breaks" } },
                //{ "Text<p>with<p> paragraph<p>breaks", new[] { "Text", "with", " paragraph", "breaks" } },
                //{ "Text<p>with<p> paragraph<p> breaks ", new[] { "Text", "with", " paragraph", " breaks " } },
                //{ "Text<p>with<p><p> paragraph<p> breaks ", new[] { "Text", "with", "", " paragraph", " breaks " } },
                //{ "Text<p/>with<p />paragraph<p  />breaks", new[] { "Text", "with", "paragraph", "breaks" } },
                //{ "Text without paragraph breaks", new[] { "Text without paragraph breaks" } }
            };

        [Theory]
        [MemberData(nameof(SplitAtHtmlParagraphBreak_TestData))]
        public void SplitAtHtmlParagraphBreak_Test(string text, string[] expected)
        {
            // Act
            var result = HtmlHelper.SplitAtHtmlParagraphBreak(text);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
