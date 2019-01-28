using System;
using System.IO;
using System.Collections.Generic;
using JiebaNet.Segmenter;

namespace YahooBugTest
{
    class Program
    {
        static void Main(string[] args)
        {

            WebGetter wg = new WebGetter(@"https://tw.news.yahoo.com/most-popular");
            wg.setMethod("GET");
            string html = wg.webReader();
            Console.WriteLine(html);
            WebDecoder wd =  new WebDecoder();
            wd.setRule(@"//ul[@id='stream-container-scroll-template']/li/div/div/div/div/div/img");
            List<string> list =  wd.htmlDecode(html);
            int i = 0;
            var segmenter = new JiebaSegmenter();
            //segmenter.LoadUserDict(@"myDic.txt");
            //segmenter.AddWord("陳菊",3,"nr");
            //segmenter.AddWord("後果", 3, "n");
            //segmenter.AddWord("高雄", 3);
            //segmenter.AddWord("陳致中",3,"nr");
            //segmenter.AddWord("這件事", 3);
            //segmenter.AddWord("身材照",3,"n");
            //segmenter.AddWord("道盡",3);
            segmenter.AddWord("韓國瑜", 3, "nr");
            segmenter.AddWord("台灣人", 3, "n");
            List<string> words = new List<string>();
            //segmenter.AddWord("市長", 3, "n");
            StreamWriter sw = new StreamWriter("test.txt");
            //var segments;
            foreach (var tmp in list)
            {
                Console.WriteLine(i+ ": " + tmp);
                sw.WriteLine(i + ": " + tmp);
                var segments = segmenter.Cut(tmp);
                //foreach(var tmp2 in segments)
                //{
                //    Console.WriteLine("\t" + tmp2);
                //    sw.WriteLine("\t" + tmp2);
                //    words.Add(tmp2);
                //}
                i++;
            }
            sw.Close();
            words.Sort();
            //foreach(var tmp in words)
            //{
            //    Console.WriteLine(tmp);
            //}
            Console.ReadKey(true);
        }
        
    }
}
