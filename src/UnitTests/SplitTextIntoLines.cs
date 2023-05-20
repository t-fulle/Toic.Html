using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Globalization;
using System.IO;
using System.Collections;
using Toic.WebScrapping;
using Toic.Html;

namespace StringExtensions
{
    public class SplitTextIntoLinesTests
    {
        public static IEnumerable<object[]> SplitTextIntoLinesData()
        {
            #region Empty Lines
            yield return new object[] { "", new string[] { "" } };
            yield return new object[] { "\n", new string[] { "", "" } };
            yield return new object[] { "\n\n", new string[] { "", "", "" } };
            yield return new object[] { "\n\n\n", new string[] { "", "", "", "" } };

            yield return new object[] { "", new string[] { "" } };
            yield return new object[] { "\r", new string[] { "", "" } };
            yield return new object[] { "\r\r", new string[] { "", "", "" } };
            yield return new object[] { "\r\r\r", new string[] { "", "", "", "" } };

            yield return new object[] { "", new string[] { "" } };
            yield return new object[] { "\r\n", new string[] { "", "" } };
            yield return new object[] { "\r\n\r\n", new string[] { "", "", "" } };
            yield return new object[] { "\r\n\r\n\r\n", new string[] { "", "", "", "" } };

            // Fails
            //yield return new object[] { "\n\r\n", new string[] { "", "" } };
            //yield return new object[] { "\r\n\r", new string[] { "", "" } };

            // Fails
            //yield return new object[] { "\n\r\r", new string[] { "", "", "" } };
            //yield return new object[] { "\n\r\r\n", new string[] { "", "", "" } };
            #endregion

            yield return new object[] { "Line1\nLine2", new[] { "Line1", "Line2" } };
            yield return new object[] { "Line1\rLine2", new[] { "Line1", "Line2" } };
            yield return new object[] { "Line1\r\nLine2", new[] { "Line1", "Line2" } };
            yield return new object[] { "Line1\n\nLine2", new[] { "Line1", "", "Line2" } };
        }

        [Theory]
        [MemberData(nameof(SplitTextIntoLinesData))]
        public void SplitTextIntoLines(string text, string[] expected)
        {
            var result = text.SplitTextIntoLines();
            Assert.Equal(expected, result);
        }

        //yield return new object[] { "", 0, "" };
    //yield return new object[] { "", 1, "" };
    //yield return new object[] { "", -1, "" };

    //yield return new object[] { "\n", 0, "" };
    //yield return new object[] { "\r", 0, "" };
    //yield return new object[] { "\r\n", 0, "" };

    //yield return new object[] { "\n\n", 0, "\n" };
    //yield return new object[] { "\r\r", 0, "\r" };
    //yield return new object[] { "\r\n\r\n", 0, "\r\n" };

    //yield return new object[] { "\n\n", 1, "\n" };
    //yield return new object[] { "\r\r", 1, "\r" };
    //yield return new object[] { "\r\n\r\n", 1, "\r\n" };

    //yield return new object[] { "\n\n", -1, "\n" };
    //yield return new object[] { "\r\r", -1, "\r" };
    //yield return new object[] { "\r\n\r\n", -1, "\r\n" };
}
}
