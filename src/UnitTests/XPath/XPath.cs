//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using System.Globalization;
//using System.IO;
//using System.Collections;
//using HtmlAgilityPack;

//namespace XPath
//{
//    public class XPathElu
//    {

//        //what is the xpath for THIS in <div id = "DIV_ID" >< p >< p > THIS </ p ></ p ></ div >

//        [Fact]
//        public void Text()
//        {
//            ////string html = "<span class=\"regin0.04400024118443002\">SPAM1</span>CONTENT<span class=\"eloun0.2557322793140162\">SPAM2</span>";
//            //string html = "<span>SPAM1</span>CONTENT<span>SPAM2</span>";
//            //string html = "<p><span>SPAM1</span>CONTENT<span>SPAM2</span></p>";
//            string html = "<p><span><span>SPAM1</span>CONTENT<span>SPAM2</span></span></p>" +
//                            "<p><span>CONTENT2</span></p>" +
//                            "<p><span>CONTENT3</span></p>";

//            HtmlDocument htmlDocument = new HtmlDocument();
//            htmlDocument.LoadHtml(html);

//            var selectedNodes = htmlDocument.DocumentNode.SelectNodes("//p/*");

//            foreach ( var node in selectedNodes ) 
//            {
//                var textnodes = node.SelectNodes("text()");
//                //string content = node.InnerText;
//                string content = textnodes.First().InnerText;

//            }

//            //var textnodes = node.DescendantsAndSelf("text()");
//            //var textnodes = node.DescendantsAndSelf("//p/*");


//            //var node = htmlDocument.DocumentNode;

//            //webPage.SelectNodes("")

//            //string? result = text.DeleteLine(index);
//            //Assert.Equal(expected, result);
//        }

//        [Fact]
//        public void Text2()
//        {
//            string html = "<span class=\"regin0.04400024118443002\">SPAM1</span>CONTENT<span class=\"eloun0.2557322793140162\">SPAM2</span>";
//            //string html = "<span>SPAM1</span>CONTENT<span>SPAM2</span>";

//            HtmlDocument htmlDocument = new HtmlDocument();
//            htmlDocument.LoadHtml(html);

//            var node = htmlDocument.DocumentNode.SelectSingleNode("text()");

//            string content = node.InnerHtml;
//        }

//        [Fact]
//        public void Text3()
//        {
//            string html = File.ReadAllText(@"C:\LightNovelStorage\lightnovelbastion.com\novel\death-mage\volume-12\death-mage-side-chapter-42.txt");

//            HtmlDocument htmlDocument = new HtmlDocument();
//            htmlDocument.LoadHtml(html);

//            // Select all <div class="selected-view" subnodes
//            var nodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='select-view']/*");


//            nodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='select-view']//option[@selected='selected']/text()");
//            //div[@class='page-header']


//            string nodeText;
//            string nodeHtml;
//            foreach (var node in nodes)
//            {
//                nodeText = node.InnerText;
//                nodeHtml = node.OuterHtml;
//            }


//            //var nodes = webPage.SelectNodes("//div[@class='selected-view']//option[@selected='selected']");


//            ////string html = "<div class=\"select - view\"> </div>";
//            //string html = "<div class=\"select-view\">\r\n\t\t\t\t\t\r\n                    <!-- select chapter -->\r\n                    <div class=\"c-selectpicker selectpicker_chapter\">\r\n                        <label>\r\n                            <select class=\"selectpicker single-chapter-select\">\r\n                                                                        <option class=\"short\" data-limit=\"40\" value=\"death-mage-299\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-299\">Death Mage 299 - The goddess’s revival and the Great Demon King who carries the names of the champions</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-298\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-298\">Death Mage 298 - Time for food</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-297\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-297\">Death Mage 297 - The second stage begins</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-296\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-296\">Death Mage 296 - An all-purpose Pandemonium and a broken war horn</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-295\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-295\">Death Mage 295 - A distraction, but a fierce battle nonetheless</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-294\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-294\">Death Mage 294 - The one who spreads death through muscles</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-293\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-293\">Death Mage 293 - The first stage begins</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-292\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-292\">Death Mage 292 - The back-shield with phantom thorns</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-side-chapter-45\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-side-chapter-45\">Death Mage Side Chapter 45 - A peaceful moment before a certain storm</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-291\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-291\">Death Mage 291 - A moment after battle, and cannibalism</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-290\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-290\">Death Mage 290 - The horseman of the apocalypse decides not to ride</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-289\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-289\">Death Mage 289 - With Five Sins</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-side-chapter-44\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-side-chapter-44\">Death Mage Side Chapter 44 - The various gods</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-288\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-288\">Death Mage 288 - Perseus and Skanda</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-287\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-287\">Death Mage 287 - Firstborn child</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-286\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-286\">Death Mage 286 - The Dragon Emperor God</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-285\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-285\">Death Mage 285 - A peaceful tea-time</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-284\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-284\">Death Mage 284 - Those who are nurtured between attacks</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-283\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-283\">Death Mage 283 - Another Guider and shaken gods</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-282\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-282\">Death Mage 282 - A thrilling battle</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-281\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-281\">Death Mage 281 - One statue is canceled, another is built</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-280\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-280\">Death Mage 280 - The empire of law is burned by the storm</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-279\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-279\">Death Mage 279 - The Gartland Concert</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-278\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-278\">Death Mage 278 - A rematch… or rather, observation</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-277\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-277\">Death Mage 277 - Things are hard for former members of the Demon King’s army</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-276\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-276\">Death Mage 276 - The Saint of Darkness</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-side-chapter-43\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-side-chapter-43\">Death Mage Side Chapter 43 - In the absence of their natural enemy</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-275\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-275\">Death Mage 275 - The barrier that wounds the Demon King, and an underground world</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-274\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-274\">Death Mage 274 - The escaping Demon King’s party and the reinforcements that were not in time</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-273\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-273\">Death Mage 273 - The battle to defend the Demon King’s continent</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-272\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-272\">Death Mage 272 - A lively day in Alcrem and the sneaky Demon King</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-271\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-271\">Death Mage 271 - Honorary Countess Darcia Zakkart</option>\r\n\r\n                                                                            <option class=\"short\" data-limit=\"40\" value=\"death-mage-side-chapter-42\" data-redirect=\"https://lightnovelbastion.com/novel/death-mage/volume-12/death-mage-side-chapter-42\" selected=\"selected\">Death Mage Side Chapter 42 - Heinz returns</option>\r\n\r\n                                                                </select>\r\n\t\t\t\t\t\t\t\r\n                        </label>\r\n                    </div>\r\n\t\t\t\t\t                </div>\r\n";
//            ////string html = "<span>SPAM1</span>CONTENT<span>SPAM2</span>";



//            //string content = node.InnerHtml;
//        }

       
        
//    }
//}
