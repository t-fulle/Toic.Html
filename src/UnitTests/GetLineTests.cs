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

namespace StringExtensions
{
    public class GetLineTests
    {
        public static IEnumerable<object?[]> GetLineData()
        {
            yield return new object?[] { "Line 1\nLine 2\r\nLine 3", 0, "Line 1" };
            yield return new object?[] { "Line 1\nLine 2\r\nLine 3", 1, "Line 2" };
            yield return new object?[] { "Line 1\nLine 2\r\nLine 3", 2, "Line 3" };
            yield return new object?[] { "Line 1\nLine 2\r\nLine 3", 3, null };
            yield return new object?[] { "Line 1\nLine 2\r\nLine 3", -1, "Line 3" };
            yield return new object?[] { "Line 1\nLine 2\r\nLine 3", -2, "Line 2" };
            yield return new object?[] { "Line 1\nLine 2\r\nLine 3", -3, "Line 1" };
            yield return new object?[] { "Line\t1\n Line\t2 \r\n Line\t3 ", -4, null };
            yield return new object?[] { " Line\t1 \n Line\t2 \r\n Line\t3 ", -5, null };
            yield return new object?[] { " Line\t1 \n Line\t2 \r\n Line\t3 ", -6, null };
            yield return new object?[] { "", -1, null };
            yield return new object?[] { "", -1000, null };
            yield return new object?[] { null, 0, null };

            // Additional test cases with \r as a line separator
            yield return new object?[] { "Line 1\rLine 2\rLine 3", 0, "Line 1" };
            yield return new object?[] { "Line 1\rLine 2\rLine 3", 1, "Line 2" };
            yield return new object?[] { "Line 1\rLine 2\rLine 3", -1, "Line 3" };
            yield return new object?[] { " Line\t1 \r Line\t2 \r Line\t3 ", -4, null };

            // Additional test cases with mixed line separators
            yield return new object?[] { " Line\t1 \n Line\t2 \r Line\t3 \r\n Line\t4 ", 2, " Line\t3 " };

            // Test cases with all three line separators
            yield return new object[] { "Line 1\nLine 2\rLine 3\r\nLine 4", 0, "Line 1" };
            yield return new object[] { "Line 1\nLine 2\rLine 3\r\nLine 4", 1, "Line 2" };
            yield return new object[] { "Line 1\nLine 2\rLine 3\r\nLine 4", 2, "Line 3" };
            yield return new object[] { "Line 1\nLine 2\rLine 3\r\nLine 4", -1, "Line 4" };
            yield return new object[] { " Line\t1 \n Line\t2 \r Line\t3 \r\n Line\t4 ", -5, null };

            // Test cases with different orders of line separators
            // Order: \n \r \r\n
            yield return new object[] { "A\nB\rC\r\nD", -1, "D" };
            yield return new object[] { "A\nB\rC\r\nD", -2, "C" };
            yield return new object[] { "A\nB\rC\r\nD", -3, "B" };
            yield return new object[] { "A\nB\rC\r\nD", -4, "A" };

            // Order: \n \r\n \r
            yield return new object[] { "E\nF\r\nG\rH", -1, "H" };
            yield return new object[] { "E\nF\r\nG\rH", -2, "G" };
            yield return new object[] { "E\nF\r\nG\rH", -3, "F" };
            yield return new object[] { "E\nF\r\nG\rH", -4, "E" };

            // Order: \r \n \r\n
            yield return new object[] { "I\rJ\nK\r\nL", -1, "L" };
            yield return new object[] { "I\rJ\nK\r\nL", -2, "K" };
            yield return new object[] { "I\rJ\nK\r\nL", -3, "J" };
            yield return new object[] { "I\rJ\nK\r\nL", -4, "I" };

            // Order: \r \r\n \n
            yield return new object[] { "M\rN\r\nO\nP", -1, "P" };
            yield return new object[] { "M\rN\r\nO\nP", -2, "O" };
            yield return new object[] { "M\rN\r\nO\nP", -3, "N" };
            yield return new object[] { "M\rN\r\nO\nP", -4, "M" };

            // Order: \r\n \n \r
            yield return new object[] { "Q\r\nR\nS\rT", -1, "T" };
            yield return new object[] { "Q\r\nR\nS\rT", -2, "S" };
            yield return new object[] { "U\r\nV\rW\nX", -1, "X" };
            yield return new object[] { "U\r\nV\rW\nX", -2, "W" };
            yield return new object[] { "U\r\nV\rW\nX", -3, "V" };
            yield return new object[] { "U\r\nV\rW\nX", -4, "U" };
        }

        [Theory]
        [MemberData(nameof(GetLineData))]
        public void GetLineTest(string? text, int index, string? expected)
        {
            string? result = text?.GetLine(index);
            Assert.Equal(expected, result);
        }
    }
}
