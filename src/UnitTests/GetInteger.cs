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
    public class FactTests
    {
        #region GetIntegerTest
        [Theory]
        [MemberData(nameof(GetIntegerTestData))]
        public void GetIntegerTest(string input, int index, int? expected)
        {
            var result = input.GetInteger(index);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GetIntegerTestData =>
            new List<object[]>
            {
                new object[] { "abc 123", 0, 123 },
                new object[] { "abc 123", 1, null },
                new object[] { "abc 123", -1, 123 },
                new object[] { "abc 123", -2, null },
                new object[] { "123", 0, 123 },
                new object[] { "123", 1, null },
                new object[] { "123", -1, 123 },
                new object[] { "123", -2, null },
                new object[] { "abc123", 0, 123 },
                new object[] { "abc123", 1, null },
                new object[] { "abc123", -1, 123 },
                new object[] { "abc123", -2, null },
                new object[] { "abc123def456", 0, 123 },
                new object[] { "abc123def456", 1, 456 },
                new object[] { "abc123def456", 2, null },
                new object[] { "abc123def456", -1, 456 },
                new object[] { "abc123def456", -2, 123 },
                new object[] { "abc123def456", -3, null },
                new object[] { "abc", 0, null },
                new object[] { "abc", -1, null },
                new object[] { "Some random string.", 0, null },
                new object[] { "Some random string.", -1, null },
                new object[] { "Another random string with number 42 inside to be found", 0, 42 },
                new object[] { "Another random string with number 42 inside to be found", 1, null },
                new object[] { "Another random string with number 42 inside to be found", -1, 42 },
                new object[] { "Another random string with number 42 inside to be found", -2, null },
                new object[] { "Chapter 1: Crimson Colored Night [Volume 3 - Between Daybreak and Evernight]", 0, 1 },
                new object[] { "Chapter 1: Crimson Colored Night [Volume 3 - Between Daybreak and Evernight]", 1, 3 },
                new object[] { "Chapter 1: Crimson Colored Night [Volume 3 - Between Daybreak and Evernight]", 2, null },
                new object[] { "Chapter 1: Crimson Colored Night [Volume 3 - Between Daybreak and Evernight]", -1, 3 },
                new object[] { "Chapter 1: Crimson Colored Night [Volume 3 - Between Daybreak and Evernight]", -2, 1 },
                new object[] { "Chapter 1: Crimson Colored Night [Volume 3 - Between Daybreak and Evernight]", -3, null },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", 0, 1 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", 1, 2 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", 2, 3 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", 3, 4 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", 4, 55 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", 5, 666 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", 6, 777 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", 7, null },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", -1, 777 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", -2, 666 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", -3, 55 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", -4, 4 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", -5, 3 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", -6, 2 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", -7, 1 },
                new object[] { "St1ring 2 with\nmul3tiple\r\nLin4es in 55 diffe666rent Lineendings\rand s777o on", -8, null },
                new object[] { "String with\nmultiple\r\nLines in different Lineendings\rand so on", 0, null },
                new object[] { "String with\nmultiple\r\nLines in different Lineendings\rand so on", 1, null },
                new object[] { "String with\nmultiple\r\nLines in different Lineendings\rand so on", 2, null },
                new object[] { "String with\nmultiple\r\nLines in different Lineendings\rand so on", 4, null },
                new object[] { "String with\nmultiple\r\nLines in different Lineendings\rand so on", -1, null },
                new object[] { "String with\nmultiple\r\nLines in different Lineendings\rand so on", -2, null },
                new object[] { "String with\nmultiple\r\nLines in different Lineendings\rand so on", -4, null },
            };
        #endregion
    }
}
