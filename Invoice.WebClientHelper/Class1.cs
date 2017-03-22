using System;
using System.Linq;
using System.Net;
using System.Text;

namespace Invoice.WebClientHelper
{
    public static class HelperExtension
    {
        public static string Get(string Url, string Referer, Encoding Encoder, ref string CookieStr)
        {
            string result = "";

            WebClient myClient = new WebClient();
            //myClient.Headers.Add("Accept: */*");
            //myClient.Headers.Add("User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; .NET4.0E; .NET4.0C; InfoPath.2; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; SE 2.X MetaSr 1.0)");
            //myClient.Headers.Add("Accept-Language: zh-cn");
            //myClient.Headers.Add("Content-Type: multipart/form-data");
            //myClient.Headers.Add("Accept-Encoding: gzip, deflate");
            //myClient.Headers.Add("Cache-Control: no-cache");
            if (CookieStr != "")
            {
                myClient.Headers.Add(CookieStr);
            }
            myClient.Encoding = Encoder;
            result = myClient.DownloadString(Url);
            if (CookieStr == "")
            {
                CookieStr = myClient.ResponseHeaders["Set-Cookie"].ToString();
                CookieStr = GetCookie(CookieStr);
            }
            return result;
        }

        public static string Post(string Url, string Referer, Encoding Encoder, ref string CookieStr, string Data)
        {
            string result = "";

            WebClient myClient = new WebClient();
            myClient.Headers.Add("Accept: */*");
            myClient.Headers.Add("User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; .NET4.0E; .NET4.0C; InfoPath.2; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; SE 2.X MetaSr 1.0)");
            myClient.Headers.Add("Accept-Language: zh-cn");
            myClient.Headers.Add("Content-Type: multipart/form-data");
            myClient.Headers.Add("Accept-Encoding: gzip, deflate");
            myClient.Headers.Add("Cache-Control: no-cache");
            if (CookieStr != "")
            {
                myClient.Headers.Add(CookieStr);
            }
            myClient.Encoding = Encoder;
            result = myClient.UploadString(Url, Data);
            if (CookieStr == "")
            {
                CookieStr = myClient.ResponseHeaders["Set-Cookie"].ToString();
                CookieStr = GetCookie(CookieStr);
            }
            return result;
        }

        private static string GetCookie(string CookieStr)
        {
            string result = "";

            string[] myArray = CookieStr.Split(',');
            if (myArray.Count() > 0)
            {
                result = "Cookie: ";
                foreach (var str in myArray)
                {
                    string[] CookieArray = str.Split(';');
                    result += CookieArray[0].Trim();
                    result += "; ";
                }
                result = result.Substring(0, result.Length - 2);
            }
            return result;
        }
    }
}
