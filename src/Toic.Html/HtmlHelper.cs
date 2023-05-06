using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Toic.Html
{
    /// <summary>
    /// Provides helper methods for working with HTML.
    /// </summary>
    public static class HtmlHelper
    {
        #region Constants

        /// <summary>
        /// Regular expression for matching HTML line breaks.
        /// </summary>
        public static readonly Regex HTML_LINE_BREAK = new Regex(@"<\s*/?\s*br\s*/?>", RegexOptions.Compiled);

        /// <summary>
        /// Regular expression for matching HTML paragraph breaks.
        /// </summary>
        public static readonly Regex HTML_PARAGRAPH = new Regex(@"(?:<\s*/?\s*br\s*/?>){2,}", RegexOptions.Compiled);

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the specified text contains an HTML line break.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <returns><c>true</c> if the text contains an HTML line break; otherwise, <c>false</c>.</returns>
        public static bool ContainsHtmlLineBreak(string text) => HTML_LINE_BREAK.Matches(text).Any();

        /// <summary>
        /// Determines whether the specified text contains an HTML paragraph break.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <returns><c>true</c> if the text contains an HTML paragraph break; otherwise, <c>false</c>.</returns>
        public static bool ContainsHtmlParagraphBreak(string text) => HTML_PARAGRAPH.Matches(text).Any();

        /// <summary>
        /// Splits the specified text at each occurrence of an HTML line break.
        /// </summary>
        /// <param name="text">The text to split.</param>
        /// <returns>An array of strings that were split at each occurrence of an HTML line break.</returns>
        public static string[] SplitAtHtmlLineBreak(string text) => HTML_LINE_BREAK.Split(text);

        /// <summary>
        /// Splits the specified text at each occurrence of an HTML paragraph break.
        /// </summary>
        /// <param name="text">The text to split.</param>
        /// <returns>An array of strings that were split at each occurrence of an HTML paragraph break.</returns>
        public static string[] SplitAtHtmlParagraphBreak(string text) => HTML_PARAGRAPH.Split(text);

        #endregion
    }
}
