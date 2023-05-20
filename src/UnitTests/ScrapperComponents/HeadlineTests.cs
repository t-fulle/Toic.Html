using Toic.WebScrapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ScrapperComponents
{
    public class HeadlineTests
    {
        #region ExtractHeadLine_Test
        public static IEnumerable<object[]> HeadlineTestData()
        {
            yield return new object[] { "1 &#8211; 3796", new Headline(1, "3796") };
            yield return new object[] { "589 &#8211; The Ten Great Sects Are No More", new Headline(589, "The Ten Great Sects Are No More") };
            yield return new object[] { "549 - My Headline", new Headline(549, "My Headline") };
            yield return new object[] { "Ch. 1811: Even If You're An Undead, You Can’t Be So Shameless (4)", new Headline(1811, "Even If You're An Undead, You Can’t Be So Shameless (4)") };
            yield return new object[] { "Ch. 700.5: Fanart Contest: 700 Chapters Milestone", new Headline(700.5, "Fanart Contest: 700 Chapters Milestone") };
            yield return new object[] { "24 &#8211; Fernandro Principality&#8217;s Decision", new Headline(24, "Fernandro Principality's Decision") };
            yield return new object[] { "12 – As though Crushing Dry Weeds and Smashing Rotten Wood", new Headline(12, "As though Crushing Dry Weeds and Smashing Rotten Wood") };
            yield return new object[] { "899 &#8211;&nbsp; Fighting the Stone Monarch", new Headline(899, "Fighting the Stone Monarch") };
            yield return new object[] { "The Gilded Cage - Chapter 1", new Headline(1, null) }; // resultint Title is null = not set
            yield return new object[] { "The Gilded Cage - Chapter 18", new Headline(18, null) }; // resultint Title is null = not set
            
            //yield return new object[] { "Death Mage Side Chapter 42 - Heinz returns", new Headline(SE ? 42, "Heinz returns") };

            // NovelNext.com
            //yield return new object[] { " Chapter 133rd Guinea Pigs (3)", new Headline(133, "Guinea Pigs (3)") };
            //yield return new object[] { " Chapter 138th Say Nothing in Everything (2)", new Headline(138, "Say Nothing in Everything (2)") };
        }

        [Theory]
        [MemberData(nameof(HeadlineTestData))]
        public void ExtractHeadLineTest(string rawHeadline, Headline expectedHeadline)
        {
            var headline = new Headline(rawHeadline);

            Assert.Equal(expectedHeadline.ChapterNumber, headline.ChapterNumber);
            Assert.Equal(expectedHeadline.Title, headline.Title);
        }
        #endregion

        #region IsHeadline_Test
        public static IEnumerable<object[]> IsHeadline_TestData()
        {
            yield return new object[] { "Ch. 1811: Even If You're An Undead, You Can’t Be So Shameless (4)", true };
            yield return new object[] { "Ch. 700.5: Fanart Contest: 700 Chapters Milestone", true };
            yield return new object[] { "The Gilded Cage - Chapter 1", true }; // resultint Title is null = not set
            yield return new object[] { "The Gilded Cage - Chapter 18", true }; // resultint Title is null = not set

            //yield return new object[] { "Death Mage Side Chapter 42 - Heinz returns", new Headline(SE ? 42, "Heinz returns") };

            // NovelNext.com
            //yield return new object[] { " Chapter 133rd Guinea Pigs (3)", new Headline(133, "Guinea Pigs (3)") };
            //yield return new object[] { " Chapter 138th Say Nothing in Everything (2)", new Headline(138, "Say Nothing in Everything (2)") };
        }

        public static IEnumerable<object[]> IsHeadline_False_TestData()
        {
            yield return new object[] { "select chapter" };
            yield return new object[] { "About This Book" };
            yield return new object[] { "Lastest chapters" };
        }

        [Theory]
        [MemberData(nameof(HeadlineTestData))]
        public void IsHeadline_True_Test(string rawHeadline, Headline expectedHeadline)
        {
            Assert.True(Headline.IsHeadline(rawHeadline));
        }

        [Theory]
        [MemberData(nameof(IsHeadline_False_TestData))]
        public void IsHeadline_False_Test(string rawHeadline)
        {
            Assert.False(Headline.IsHeadline(rawHeadline));
        }
        #endregion

    }
}
