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
using System.Text.RegularExpressions;

namespace RegexTests
{
    /// <summary>
    /// <see cref="StringBuilderExtensions.HTML_LINEBREAK"/>
    /// </summary>
    public class HTML_LINEBREAK_Tests
    {
        #region ContainsHtmlLineBreak
        public static readonly Regex HTML_LINEBREAK = new Regex(@"<\s*/?\s*br\s*/?>", RegexOptions.Compiled);
        private static bool ContainsHtmlLineBreak(string text) => HTML_LINEBREAK.Matches(text).Any();


        public static IEnumerable<object?[]> HTML_LINEBREAK_TestData()
        {
            yield return new object[] { "<br /> Huu …<br /> He Yiming let out a long breath and got up with satisfaction. Yesterday, he had first refined a weapon and then refined a pill. He had consumed quite a bit of energy.<br /> In addition to the fact that he had refined hundreds of pills in one go, He Yiming had consumed a great deal of his Heartforce. He took a rest for a day, and then he took the opportunity to comprehend his alchemical experiences.<br /> He Yiming felt that his alchemy skills had improved greatly.<br /> After all, in Haotian Academy, how could he have the chance to refine several hundred pills at once? How could Haotian Academy allow him to spend so many Spirit Herbs?<br /> &#8220;Yes, in a day, there should be a few players who can refine a Qi Gathering Pill!&#8221; He Yiming guessed in his heart as he slowly walked out of the hall.<br /> A new day had arrived. He Yiming&#8217;s first choice was to sign in.<br /> Ding &#8230;<br />", true };
            yield return new object[] { "Line 1\nLine 2\r\n<br /> Line 3", true };
            yield return new object[] { "Line 1\n<br /> Line 2\r\n<br /> Line 3", true };
            yield return new object[] { "Line 1\n<br /> Line 2\r\n<br /> Line 3<br /> ", true };
            yield return new object[] { "Line 1\nLine 2\r\nLine</br>  3", true };
            yield return new object[] { "Line 1\nLine 2\r\nLine</br >  3", true };
            yield return new object[] { "Line 1\nLine 2\r\nLine< /br>  3", true };
            yield return new object[] { "Line 1\nLine 2\r\nLine< br />  3", true };


            yield return new object[] { "Line 1\nLine 2\r\nLine 3", false };
            yield return new object[] { "Line 1\nLine 2\r\nLine 3", false };
            yield return new object[] { "Line 1\nLine 2\r\nLine 3", false };
            yield return new object[] { "Line 1\nLine 2\r\nLine 3", false };
        }

        [Theory]
        [MemberData(nameof(HTML_LINEBREAK_TestData))]
        public void HTML_LINEBREAK_Test(string text, bool containsHtmlLinebreak)
        {
            Assert.Equal(containsHtmlLinebreak, ContainsHtmlLineBreak(text));
        }
        #endregion
    }
}
