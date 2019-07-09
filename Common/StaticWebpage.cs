using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Maticsoft.Common
{
    public class StaticWebpage
    {
        #region 获取html网页
        /// <summary>
        /// 获取html网页
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static string HtmlCodeRequest(string Url)
        {
            if (string.IsNullOrEmpty(Url))
            {
                return "";
            }
            try
            {
                //创建一个请求
                HttpWebRequest httprequst = (HttpWebRequest)WebRequest.Create(Url);
                //不建立持久性链接
                httprequst.KeepAlive = true;
                //设置请求的方法
                httprequst.Method = "GET";
                //设置标头值
                httprequst.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
                httprequst.Accept = "*/*";
                httprequst.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
                httprequst.ServicePoint.Expect100Continue = false;
                httprequst.Timeout = 5000;
                httprequst.AllowAutoRedirect = true;//是否允许302
                ServicePointManager.DefaultConnectionLimit = 30;
                //获取响应
                HttpWebResponse webRes = (HttpWebResponse)httprequst.GetResponse();
                //获取响应的文本流
                string content = string.Empty;
                using (System.IO.Stream stream = webRes.GetResponseStream())
                {
                    using (System.IO.StreamReader reader = new StreamReader(stream, System.Text.Encoding.GetEncoding("utf-8")))
                    {
                        content = reader.ReadToEnd();
                    }
                }
                //取消请求
                httprequst.Abort();
                //返回数据内容
                return content;
            }
            catch (Exception)
            {

                return "";
            }
        }
        #endregion


        #region 得到网页中正则匹配到的图片和链接字符串
        /// <summary>
        /// 得到网页中正则匹配到的图片和链接字符串
        /// </summary>
        /// <param name="url">链接</param>
        /// <param name="Reg">要匹配的正则表达式</param>
        /// <returns></returns>
        public static string GetHtmlUrlString(string url, string Reg)
        {
            string all_code = "";
            HttpWebRequest all_codeRequest = (HttpWebRequest)WebRequest.Create(url);
            WebResponse all_codeResponse = all_codeRequest.GetResponse();
            StreamReader the_Reader = new StreamReader(all_codeResponse.GetResponseStream());
            all_code = the_Reader.ReadToEnd();
            the_Reader.Close();
            ArrayList my_list = new ArrayList();
            string p = Reg;

            Regex re = new Regex(p, RegexOptions.IgnoreCase);
            MatchCollection mc = re.Matches(all_code);

            for (int i = 0; i <= mc.Count - 1; i++)
            {

                bool _foo = false;
                string name = mc[i].ToString();
                if (p == @"(?i)<a\s[^>]*?href=(['""]?)(?!javascript|__doPostBack)(?<url>[^'""\s*#<>]+)[^>]*>")
                {
                    name = GetHtmlAHref(name);
                    name = GetHtmlAHrefLinkDiZhi(name);
                }
                
                foreach (string list in my_list)
                {
                    if (name == list)
                    {
                        _foo = true;
                        break;
                    }
                }//过滤

                if (!_foo)
                {
                    all_code += name + ",";
                }
            }
            return all_code;
        }
        #endregion

        #region 获取img标签的src
        /// <summary>
        ///获取img标签的src
        /// </summary>
        /// <param name="Image"></param>
        /// <returns></returns>
        public static string GetHtmlImageSrc(string Image)
        {
            Match m = Regex.Match(Image, "<img[^<>]*?\\ssrc=['\"]?(.*?)['\"].*?>");
            if (m.Groups.Count > 1)
            {
                return m.Groups[1].Value;
            }
            return "";
        }
        #endregion

        #region a标签中的herf中的连接地址
        /// <summary>
        /// a标签中的herf中的连接地址
        /// </summary>
        /// <param name="href"></param>
        /// <returns></returns>
        public static string GetHtmlAHref(string href)
        {
            Match m = Regex.Match(href, @"(?is)<a[^>]*?href=(['""\s]?)(?<href>[^'""\s]*)\1[^>]*?>");
            if (m.Groups.Count > 1)
            {
                return m.Groups["href"].Value;
            }
            return "";
        }
        #endregion

        #region 判断真实href链接
        /// <summary>
        /// 判断真实href链接
        /// </summary>
        /// <param name="href"></param>
        /// <returns></returns>

        public static string GetHtmlAHrefLinkDiZhi(string href)
        {
            if (Regex.IsMatch(href, @"^/vod/(\d+).html$"))
            {
                return href;
            }
            return "";
        }
        #endregion

        #region 得到网页中正则匹配到的连接字符串的title符串
        /// <summary>
        /// 得到网页中正则匹配到图片和链接字符串
        /// </summary>
        /// <param name="url">链接</param>
        /// <param name="Reg">要匹配的正则表达式</param>
        /// <returns></returns>
        public static string GetHtmlUrlTitleString(string url, string Reg)
        {
            string all_code = "";
            HttpWebRequest all_codeRequest = (HttpWebRequest)WebRequest.Create(url);
            WebResponse all_codeResponse = all_codeRequest.GetResponse();
            StreamReader the_Reader = new StreamReader(all_codeResponse.GetResponseStream());
            all_code = the_Reader.ReadToEnd();
            the_Reader.Close();
            ArrayList my_list = new ArrayList();
            string p = Reg;
            Regex re = new Regex(p, RegexOptions.IgnoreCase);
            MatchCollection mc = re.Matches(all_code);

            for (int i = 0; i <= mc.Count - 1; i++)
            {
                bool _foo = false;
                string name = mc[i].ToString();
                name = GetHtmlATitle(name);
                foreach (string list in my_list)
                {
                    if (name == list)
                    {
                        _foo = true;
                        break;
                    }
                }//过滤

                if (!_foo)
                {
                    all_code += name + ",";
                }
            }
            return all_code;
        }
        #endregion

        #region 获取a标签的title的值
        /// <summary>
        /// 获取a标签的title的值
        /// </summary>
        /// <param name="title">传过来的标签字符串</param>
        /// <returns></returns>
        public static string GetHtmlATitle(string title)
        {
            Match m = Regex.Match(title, @"<a\s+.*?title=""([^""]*)"".*?>");
            if (m.Groups.Count > 1)
            {
                return m.Groups[1].Value;
            }
            return "";
        }
        #endregion
        
        #region 判断字符串中方是否有汉字
        /// <summary>
        /// 判断字符串中方是否有汉字
        /// </summary>
        /// <param name="Chinese">字符串</param>
        /// <returns></returns>
        public static string IfChinese(string Chinese)
        {
            if (Regex.IsMatch(Chinese, @".*[\\u4e00-\\u9faf].*"))
            {
                return Chinese;
            }
            return "";
        }
        #endregion

        #region 搜索的结果数据
        /// <summary>
        /// 搜索的结果数据
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        public static string SearchString(string Search)
        {
            string all_code = "";
            string Temp = "";
            HttpWebRequest all_codeRequest = (HttpWebRequest)WebRequest.Create(Search);
            WebResponse all_codeResponse = all_codeRequest.GetResponse();
            StreamReader the_Reader = new StreamReader(all_codeResponse.GetResponseStream());
            all_code = the_Reader.ReadToEnd();
            the_Reader.Close();
            ArrayList my_list = new ArrayList();
            string p = @"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>";
            Regex re = new Regex(p, RegexOptions.IgnoreCase);
            MatchCollection mc = re.Matches(all_code);

            for (int i = 3; i <= mc.Count - 1; i++)
            {
                bool _foo = false;
                string name = mc[i].ToString();
                name = GetSearchImageSrc(name);
                foreach (string list in my_list)
                {
                    if (name == list)
                    {
                        _foo = true;
                        break;
                    }
                }//过滤

                if (!_foo)
                {
                    Temp += name+",";
                }
            }
            return Temp;
        }
        #endregion

        #region 截取一个标签特定的一部分
        /// <summary>
        /// 截取一个标签特定的一部分
        /// </summary>
        /// <param name="Image"></param>
        /// <returns></returns>
        public static string GetSearchImageSrc(string Image)
        {
            string[] sArray = Image.Split(new string[] { "src=" }, StringSplitOptions.RemoveEmptyEntries);
            string imageString = sArray[1].Substring(0, sArray[1].Length-1);
            return imageString;
        }
        #endregion

        #region 获取搜索中的a标签链接
        /// <summary>
        /// 获取搜索中的a标签链接
        /// </summary>
        /// <param name="SearchString"></param>
        /// <returns></returns>
        public static string GetSearchSrc(string SearchString)
        {
            string all_code = "";
            string Temp = "";
            HttpWebRequest all_codeRequest = (HttpWebRequest)WebRequest.Create(SearchString);
            WebResponse all_codeResponse = all_codeRequest.GetResponse();
            StreamReader the_Reader = new StreamReader(all_codeResponse.GetResponseStream());
            all_code = the_Reader.ReadToEnd();
            the_Reader.Close();
            ArrayList my_list = new ArrayList();
            string p = @"(?i)<a\s[^>]*?href=(['""]?)(?!javascript|__doPostBack)(?<url>[^'""\s*#<>]+)[^>]*>";
            Regex re = new Regex(p, RegexOptions.IgnoreCase);
            MatchCollection mc = re.Matches(all_code);

            for (int i = 0; i <= mc.Count - 1; i++)
            {
                bool _foo = false;
                string name = mc[i].ToString();
                name = GetHtmlAHref(name);
                name = GetHtmlAHrefLinkDiZhi(name);
                foreach (string list in my_list)
                {
                    if (name == list)
                    {
                        _foo = true;
                        break;
                    }
                }//过滤

                if (!_foo)
                {
                    Temp += name + ",";
                }
            }
            return Temp;
        } 
        #endregion

        #region 获取搜索网页中的p标签
        /// <summary>
        /// 获取搜索网页中的p标签
        /// </summary>
        /// <param name="HtmlSrout"></param>
        /// <returns></returns>
        public static string GetHtmlP(string HtmlSrout)
        {
            string temp = "";
            string all_code = "";
            HttpWebRequest all_codeRequest = (HttpWebRequest)WebRequest.Create(HtmlSrout);
            WebResponse all_codeResponse = all_codeRequest.GetResponse();
            StreamReader the_Reader = new StreamReader(all_codeResponse.GetResponseStream());
            all_code = the_Reader.ReadToEnd();
            the_Reader.Close();
            ArrayList my_list = new ArrayList();
            Regex Reg = new Regex(@"(?is)(?<=<P>).*?(?=</P>)", RegexOptions.IgnoreCase);
            MatchCollection mc = Reg.Matches(all_code);

            for (int i = 0; i <= mc.Count - 4; i++)
            {
                bool _foo = false;
                string name = mc[i].ToString();
                foreach (string list in my_list)
                {
                    if (name == list)
                    {
                        _foo = true;
                        break;
                    }
                }//过滤

                if (!_foo)
                {
                    temp += name + "^";
                }
            }
            return temp;
        } 
        #endregion
    }
}
