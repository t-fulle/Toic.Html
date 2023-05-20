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
    public class DeleteLineTests
    {
        public static IEnumerable<object[]> DeleteLineData()
        {
            yield return new object[] { "", 0, "" };
            yield return new object[] { "", 1, "" };
            yield return new object[] { "", -1, "" };

            yield return new object[] { "\n", 0, "" };
            yield return new object[] { "\r", 0, "" };
            yield return new object[] { "\r\n",0, "" };

            yield return new object[] { "\n\n", 0, "\n" };
            yield return new object[] { "\r\r", 0, "\r" };
            yield return new object[] { "\r\n\r\n", 0, "\r\n" };

            yield return new object[] { "\n\n", 1, "\n" };
            yield return new object[] { "\r\r", 1, "\r" };
            yield return new object[] { "\r\n\r\n", 1, "\r\n" };

            yield return new object[] { "\n\n", -1, "\n" };
            yield return new object[] { "\r\r", -1, "\r" };
            yield return new object[] { "\r\n\r\n", -1, "\r\n" };

            //yield return new object?[] { "Line 1\nLine 2\r\nLine 3", 0, "Line 2\r\nLine 3" };
            //yield return new object?[] { "Line 1\nLine 2\r\nLine 3", 1, "Line 1\nLine 3" };
            //yield return new object?[] { "Line 1\nLine 2\r\nLine 3", 2, "Line 1\nLine 2" };
            //yield return new object?[] { "Line 1\nLine 2\r\nLine 3", -1, "Line 1\nLine 2" };
            //yield return new object?[] { "Line 1\nLine 2\r\nLine 3", -2, "Line 1\nLine 3" };
            //yield return new object?[] { "Line\t1\n Line\t2 \r\n Line\t3 ", -3, " Line\t2 \r\n Line\t3 " };
            //yield return new object?[] { " Line\t1 \n Line\t2 \r\n Line\t3 ", -4, " Line\t1 \n Line\t2 \r\n Line\t3 " };
            //yield return new object?[] { "", -1, "" };
            //yield return new object?[] { "", -1000, "" };

            //// Additional test cases with \r as a line separator
            //yield return new object?[] { "Line 1\rLine 2\rLine 3", 0, "Line 2\rLine 3" };
            //yield return new object?[] { "Line 1\rLine 2\rLine 3", -1, "Line 1\rLine 2" };
            //yield return new object?[] { " Line\t1 \r Line\t2 \r Line\t3 ", -4, " Line\t1 \r Line\t2 \r Line\t3 " };

            //// Additional test cases with mixed line separators
            //yield return new object?[] { " Line\t1 \n Line\t2 \r Line\t3 \r\n Line\t4 ", 2, " Line\t1 \n Line\t2 \r Line\t4 " };

            //// Test cases with all three line separators
            //yield return new object[] { "Line 1\nLine 2\rLine 3\r\nLine 4", 0, "Line 2\rLine 3\r\nLine 4" };
            //yield return new object[] { "Line 1\nLine 2\rLine 3\r\nLine 4", 1, "Line 1\nLine 3\r\nLine 4" };
            //yield return new object[] { "Line 1\nLine 2\rLine 3\r\nLine 4", 2, "Line 1\nLine 2\r\nLine 4" };
            //yield return new object[] { "Line 1\nLine 2\rLine 3\r\nLine 4", -1, "Line 1\nLine 2\rLine 3" };
            //yield return new object[] { " Line\t1 \n Line\t2 \r Line\t3 \r\n Line\t4 ", -5, " Line\t1 \n Line\t2 \r Line\t3 \r\n Line\t4 " };

            //// Test cases with different orders of line separators
            //// Order: \n \r \r\n
            //yield return new object[] { "A\nB\rC\r\nD", -1, "A\nB\rC" };
            //yield return new object[] { "A\nB\rC\r\nD", -2, "A\nB\rD" };
            //yield return new object[] { "A\nB\rC\r\nD", -3, "A\nC\r\nD" };
            //yield return new object[] { "A\nB\rC\r\nD", -4, "B\rC\r\nD" };

        }

        [Theory]
        [MemberData(nameof(DeleteLineData))]
        public void DeleteLine(string text, int index, string expected)
        {
            string? result = text.DeleteLine(index);
            Assert.Equal(expected, result);
        }
    }
}
