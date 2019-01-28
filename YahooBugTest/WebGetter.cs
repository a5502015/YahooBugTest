using System.IO;
using System.Net;

namespace YahooBugTest
{
    class WebGetter
    {
        /// <summary>
        /// 建構函式就是輸入要爬的網頁的網址
        /// 
        /// setMethod 決定用哪種方法取得資料 get post 目前應該只有post有用
        /// webReader 讀取網頁拉~ 以字串方式回傳結果
        /// </summary>
        string www;
        //string method;
        WebRequest requ;
        //WebResponse respo;
        public WebGetter(string w)
        {
            www = w;
            requ = WebRequest.Create(www);
        }
        public void setMethod(string m)
        {
            requ.Method = m;
        }
        public string webReader()
        {
            string html = "";
            WebResponse respon = requ.GetResponse();
            StreamReader sr = new StreamReader(respon.GetResponseStream());

            html = sr.ReadToEnd();
            sr.Close();

            return html;
        }


    }
}
