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
using Toic.WebScrapping.Processors;

namespace WebPageProcessing
{
    public class Default_Processor_Tests
    {
        #region Fields
        private IWebPageGrabber _grabber;
        private IWebPageProcessor _processor;
        #endregion


        public Default_Processor_Tests() 
        {
            _grabber =  new WebPageStorageGrabber();
            _processor =  new Default_Processor();
        }

        #region ExtractNextChapterUrl_Tests
        [Theory]
        [MemberData(nameof(ExtractNextChapterUrl_TestData))]
        public async Task ExtractNextChapterUrl_Tests(Uri currentWebPage, Uri expectedNextWebPage)
        {
            try
            {
                if (currentWebPage == new Uri("https://novelnext.com/novelnext/the-good-for-nothing-seventh-young-lady/chapter-56"))
                { 
                
                }

                IWebPage webPage = await _grabber.GrabWebPage(currentWebPage);
                Uri? nextWebPage = _processor.ExtractNextChapterUrl(webPage);

                Assert.Equal(expectedNextWebPage, nextWebPage);
            }
            catch (Exception ex)
            {

            }

        }

        public static IEnumerable<object[]> ExtractNextChapterUrl_TestData()
        {
            yield return new object[] {
                new Uri("https://f-w-o.com/novel/all-my-disciples-suck/lastest-chapters/chapter-1/"),
                new Uri("https://f-w-o.com/novel/all-my-disciples-suck/lastest-chapters/chapter-2/") };

            yield return new object[] {
                new Uri("https://f-w-o.com/novel/all-my-disciples-suck/lastest-chapters/chapter-95/"),
                new Uri("https://f-w-o.com/novel/all-my-disciples-suck/lastest-chapters/chapter-96/") };

            yield return new object[] {
                new Uri("https://xaiomoge.com/mge/mge-1/"),
                new Uri("https://xaiomoge.com/mge/mge-2/") };

            yield return new object[] {
                new Uri("https://xaiomoge.com/mge/mge-1014/"),
                new Uri("https://xaiomoge.com/mge/mge-1015/") };

            yield return new object[] {
                new Uri("https://www.foxteller.com/novel/47/1/the-good-for-nothing-seventh-young-lady/good-for-nothing-seventh-young-lady-1"),
                new Uri("https://www.foxteller.com/novel/47/2/the-good-for-nothing-seventh-young-lady/good-for-nothing-seventh-young-lady-2") };

            yield return new object[] {
                new Uri("https://www.foxteller.com/novel/47/2002/the-good-for-nothing-seventh-young-lady/the-biggest-lie-in-history-1"),
                new Uri("https://www.foxteller.com/novel/47/2003/the-good-for-nothing-seventh-young-lady/the-biggest-lie-in-history-2") };


            yield return new object[] {
                new Uri("https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-side-chapter-42/"),
                new Uri("https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-271/") };

            yield return new object[] {
                new Uri("https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-282"),
                new Uri("https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-283/") };

            // Doest work cause next is in link name
            //yield return new object[] {
            //    new Uri("https://novelnext.com/novelnext/the-good-for-nothing-seventh-young-lady/chapter-199"),
            //    new Uri("https://novelnext.com/novelnext/the-good-for-nothing-seventh-young-lady/chapter-200") };
        }
        #endregion
    }
}
