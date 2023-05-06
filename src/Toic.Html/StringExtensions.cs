using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Toic.Html
{
    /// <summary>
    /// RString contains advanced regex string manipulation methods.
    /// RString is a class for extracting specific data from a given string using regex.
    /// </summary>
    public static class StringExtensions
    {
        #region Constants
        /// <summary>
        /// A compiled regular expression for matching integer values.
        /// </summary>
        private static readonly Regex IS_INTEGER = new Regex(@"(-|\+)?\d+", RegexOptions.Compiled);

        /// <summary>
        /// A compiled regular expression for matching double values.
        /// </summary>
        private static readonly Regex IS_DOUBLE = new Regex(@"(-|\\+)?(\\d+[\\.,]?\\d*)|([\\.,]?\\d+)", RegexOptions.Compiled);
        private static readonly Regex INTEGERS = new Regex("\\d+", RegexOptions.Compiled);
        
        //private static readonly Regex LINEENDINGS = new Regex("(\r\n|\r|\n)", RegexOptions.Compiled);
        private static readonly Regex LINEENDINGS = new Regex("(\r\n|\r|\n)", RegexOptions.Compiled);
        //private static readonly Regex LINEENDINGS = new Regex("(?<=(\r?\n\r?)|(\r)).*$", RegexOptions.Compiled);


        //string text = "\n\r\n";
        //string pattern = "(?<=(\r?\n\r?)|(\r)).*$";
        //string[] result = Regex.Split(text, pattern);
        #endregion

        #region IsInteger
        /// <summary>
        /// Determines whether the specified string represents an integer value.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>true if the specified string represents an integer value; otherwise, false.</returns>
        public static bool IsInteger(this string str) => IS_INTEGER.IsMatch(str);
        #endregion

        #region IsDouble
        /// <summary>
        /// Determines whether the specified string represents a double value.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>true if the specified string represents a double value; otherwise, false.</returns>
        public static bool IsDouble(this string str) => IS_DOUBLE.IsMatch(str);
        #endregion

        #region GetInteger
        /// <summary>
        /// Extracts the integer at the specified index from the given string.
        /// </summary>
        /// <param name="str">The string to extract the integer from.</param>
        /// <param name="index">The index of the integer to extract.<br/> If negative, counts from the end of the <paramref name="str"/>.</param>
        /// <returns>The integer at the specified index, or null if no such integer exists.</returns>
        public static int? GetInteger(this string str, int index)
        {
            if (str is null)
                return null;

            var matches = INTEGERS.Matches(str);

            if (index < 0)
            {
                if (matches.Count + 1 > -index)
                    return int.Parse(matches[matches.Count + index].Value);
            }
            else if (matches.Count > index)
                return int.Parse(matches[index].Value);

            return null;
        }

        /// <summary>
        /// Extracts the first integer from the given string.
        /// </summary>
        /// <param name="text">The string to extract the integer from.</param>
        /// <returns>The first integer in the given string, or null if no such integer exists.</returns>
        public static int? GetFirstInteger(this string text) => GetInteger(text, 0);

        /// <summary>
        /// Extracts the last integer from the given string.
        /// </summary>
        /// <param name="text">The string to extract the integer from.</param>
        /// <returns>The last integer in the given string, or null if no such integer exists.</returns>
        public static int? GetLastInteger(this string text) => GetInteger(text, -1);
        #endregion

        #region GetLine
        /// <summary>
        /// Gets the specified line of text from a string.
        /// </summary>
        /// <param name="text">The input string.</param>
        /// <param name="index">The index of the line to get. If the index is negative, it counts from the end of the string.</param>
        /// <returns>The specified line of text, or null if the index is out of range.</returns>
        public static string? GetLine(this string text, int index)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            if (index >= 0)
            {
                if (index >= lines.Length)
                    return null;
                else
                    return lines[index];
            }
            else
            {
                if (Math.Abs(index) > lines.Length)
                    return null;
                else
                    return lines[lines.Length + index];
            }
        }

        /// <summary>
        /// Gets the first line of text from a string.
        /// </summary>
        /// <param name="text">The input string.</param>
        /// <returns>The first line of text, or null if the string is empty.</returns>
        public static string? GetFirstLine(this string text) => text.GetLine(0);

        /// <summary>
        /// Gets the last line of text from a string.
        /// </summary>
        /// <param name="text">The input string.</param>
        /// <returns>The last line of text, or null if the string is empty.</returns>
        public static string? GetLastLine(this string text) => text.GetLine(-1);
        #endregion

        /// <summary>
        /// Deletes the specified line of text from a string.
        /// </summary>
        /// <param name="text">The input string.</param>
        /// <param name="index">The index of the line to delete. If the index is negative, it counts from the end of the string.</param>
        /// <returns>The modified string with the specified line deleted, or null if the index is out of range.</returns>
        public static string? DeleteLine(this string text, int index)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            if (index >= 0)
            {
                if (index >= lines.Length)
                    return text;
                else
                    return string.Join(Environment.NewLine, lines.Where((line, i) => i != index));
            }
            else
            {
                if (Math.Abs(index) > lines.Length)
                    return text;
                else
                    return string.Join(Environment.NewLine, lines.Where((line, i) => i != lines.Length + index));
            }
        }

        /// <summary>
        /// Splits the given text into an array of lines.
        /// </summary>
        /// <param name="text">The text to split.</param>
        /// <returns>An array of strings representing the lines in the text.</returns>
        public static string[] SplitTextIntoLines(this string text)
            => text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        //=> text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        //=> text.Split(new[] { "\n", "\r\n", "\r" }, StringSplitOptions.None);
        //=> LINEENDINGS.Split(text);// text.Split(new[] { "\n", "\r\n", "\r" }, StringSplitOptions.None);


        //"(?<=(\r?\n\r?)|(\r)).*$"


        ///// <summary>
        ///// cuts given regex out of rstring
        ///// Searches the given regex expression and if it finds
        ///// a match it will cut it out (remove it) from string_ 
        ///// and return it.
        ///// </summary>
        ///// <param name="regex">expression as string</param>
        ///// <returns>found string and null if there are no matches</returns>
        //public string Extract(Regex regex)
        //{
        //    string tmp = null;

        //    // regex for first number in a string (?=[^\d]*)(\d+)
        //    Regex pattern = new Regex(regex);
        //    Match match = pattern.Match(string_);
        //    if (match.Success)
        //    {
        //        tmp = match.Value;
        //        string_ = pattern.Replace(string_, "", 1);
        //    }
        //    return tmp;
        //}


        //      /**
        //* @brief removes the first occurrence of the given string
        //* @param string to remove
        //* @return true if something was removed and false else
        //*/
        //      public boolean Cut(String regex)
        //      {

        //          int size = GetLength();

        //          SetString(GetString().replaceFirst(regex, ""));

        //          return size != GetLength();
        //      }

        //      public String GetFirstLine()
        //      {


        //          // regex for first number in a string (?=[^\d]*)(\d+)
        //          Pattern pattern = Pattern.compile(".*?(?=(\r?\n\r?)|(\r)|$)");
        //          //Pattern pattern = Pattern.compile( ".*?(?=$)" );

        //          Matcher matcher = pattern.matcher(string_);


        //          if (matcher.find()) { return matcher.group(); }
        //          return null;
        //      }


        //      public void DeleteString(String string)
        //      {

        //          // TODO maybe dont use trim?? think about this part
        //          SetString(GetString().replace(string, "").trim());
        //      }



        //      public void DeleteFirstLine()
        //      {

        //          DeleteString(GetFirstLine());


        //          //       // Pattern pattern = Pattern.compile( "(?<=(\r?\n\r?)|(\r)).*$" );
        //          //        Pattern pattern = Pattern.compile( ".*$" );
        //          //
        //          //        Matcher matcher = pattern.matcher( string_ );
        //          //
        //          //        System.out.println(matcher.group());
        //          //
        //          //        //System.out.println("Still to implement");
        //          //        
        //          //        if( matcher.find() ){ return matcher.group(); }
        //          //        return null;

        //      }
    }
}
