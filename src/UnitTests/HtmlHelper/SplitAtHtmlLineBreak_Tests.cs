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
    public class SplitAtHtmlLineBreak_Tests
    {
        public static TheoryData<string, string[]> SplitAtHtmlLineBreak_TestData =>
            new TheoryData<string, string[]>
            {
                { "Text<br>with<br>line<br>breaks", new[] { "Text", "with", "line", "breaks" } },
                { "Text<br>with<br> line<br>breaks", new[] { "Text", "with", " line", "breaks" } },
                { "Text<br>with<br> line<br> breaks ", new[] { "Text", "with", " line", " breaks " } },
                { "Text<br>with<br><br> line<br> breaks ", new[] { "Text", "with", "", " line", " breaks " } },
                { "Text<br/>with<br />line<br  />breaks", new[] { "Text", "with", "line", "breaks" } },
                { "Text without line breaks", new[] { "Text without line breaks" } }
            };

        [Theory]
        [MemberData(nameof(SplitAtHtmlLineBreak_TestData))]
        public void SplitAtHtmlLineBreak_ShouldSplitStringAtLineBreaks(string text, string[] expected)
        {
            // Act
            var result = HtmlHelper.SplitAtHtmlLineBreak(text);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
