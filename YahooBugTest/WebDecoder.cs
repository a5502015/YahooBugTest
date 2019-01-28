using HtmlAgilityPack;
using System.Collections.Generic;

namespace YahooBugTest
{
    class WebDecoder
    {
        private string rule;
        public void setRule(string r)
        {
            rule = r;
        }
        public List<string> htmlDecode(string html)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            List<string> list = new List<string>();
            doc.LoadHtml(html);
            HtmlNodeCollection node = doc.DocumentNode.SelectNodes(rule);
            HtmlNodeCollection node2 = doc.DocumentNode.SelectNodes("//ul[@id='stream-container-scroll-template']/li/div/div/div/div/h3/a");
       
            foreach (var tmp in node)
            {
                //Console.WriteLine(tmp.Attributes["alt"].Value);
                list.Add(tmp.Attributes["alt"].Value);
                
            }

            return list;
        }

    }
}
