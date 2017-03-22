using Invoice.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static Invoice.Models.Reponses.RequestModel;

namespace WebDemoAsp.Controllers
{
    public class HomeController : Controller
    {
        private static string CookieStr;
        private static string CurrentPath = HttpRuntime.AppDomainAppPath.ToString();
        public ActionResult Index()
        {
            //var source= @"{"message":"鎮ㄦ墍鏌ヨ鐨勫彂绁ㄤ俊鎭笌鎶ョ◣璁板綍涓嶄竴鑷达紒","lsh":"TypeJ2017032010101210.104.120.106","flag":true,"queryCount":4,"options":[{"flag":0,"name":"鍙戠エ浠ｇ爜","inputValue":"012001600111"},{"flag":0,"name":"鍙戠エ鍙风爜","inputValue":"10645196"},{"flag":0,"name":"寮€绁ㄦ棩鏈 ?,"inputValue":"2017-03-09"},{"flag":2,"name":"璐揣鏂圭◣鍙?,"inputValue":""},{"flag":0,"name":"閿€璐ф柟绋庡彿","inputValue":"911201163409833307"},{"flag":1,"name":"閿€璐ф柟鍚嶇О","inputValue":"忙禄麓忙禄麓氓\u0087潞猫隆\u008C莽搂\u0091忙\u008A\u0080忙\u009C\u0089茅\u0099\u0090氓\u0085卢氓\u008F赂"},{"flag":0,"name":"閲戦","inputValue":"36.7"},{"flag":0,"name":"绋庨","inputValue":"1.1"},{"flag":0,"name":"浠风◣鍚堣","inputValue":"37.80"}]}";

            GetHenanMethod();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string model)
        {
            var result = GetHenanPostMethod(Request.Form.Get("vcode"));
            if (result.Contains("请输入正确的验证码"))
            {
                return RedirectToAction("Index");
            }

            return new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult IndexDemo()
        {
            ViewBag.Title = "Home Page";

            //string CookieStr = GetMethod();
            GetHenanMethod();
            //GetHenanPostMethod();
            // POST
            //var requestModel = new Sichuan() { fpdm = "151001665018", fphm = "01444200", type = "0" };
            //var s = JsonSerializer.Create();
            //s.Serialize()
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    IFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(ms, requestModel);
            WebClient wbxPost = new WebClient();
            //HttpClient client = new HttpClient();
            //wbx.BaseAddress = StateTaxationConstants.Sichuan;
            //wbx.BaseAddress = StateTaxationConstants.Sichuan;Accept:*/*
            wbxPost.Headers.Add("Accept", "*/*");
            wbxPost.Headers.Add("Origin", "http://wsbs.sc-n-tax.gov.cn");
            wbxPost.Headers.Add("X-Requested-With", "XMLHttpRequest");
            wbxPost.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
            wbxPost.Headers.Add("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
            wbxPost.Headers.Add("Referer", "http://wsbs.sc-n-tax.gov.cn/fpcy/init.htm");
            wbxPost.Headers.Add("Accept-Encoding", "gzip, deflate");
            wbxPost.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
            Byte[] pageReponseData = wbxPost.UploadData(StateTaxationConstants.SichuanPost, "POST", Encoding.UTF8.GetBytes(@"fpcy.fpdm=151001665018&
fpcy.fphm=01444200&
fpcy.type=0"));
            Encoding enc2 = Encoding.GetEncoding("UTF-8");
            string reponse = enc2.GetString(pageReponseData);
            CookieStr = wbxPost.ResponseHeaders["Set-Cookie"].ToString();

            return View(CookieStr);
            //}
        }

        private static string GetMethod()
        {
            // GET
            WebClient wbx = new WebClient();
            //HttpClient client = new HttpClient();
            //wbx.BaseAddress = StateTaxationConstants.Sichuan;
            //wbx.BaseAddress = StateTaxationConstants.Sichuan;Accept:*/*
            wbx.Headers.Add("Accept", "*/*");
            wbx.Headers.Add("Origin", "http://wsbs.sc-n-tax.gov.cn");
            wbx.Headers.Add("X-Requested-With", "XMLHttpRequest");
            wbx.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
            wbx.Headers.Add("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
            wbx.Headers.Add("Referer", "http://wsbs.sc-n-tax.gov.cn/fpcy/init.htm");
            wbx.Headers.Add("Accept-Encoding", "gzip, deflate");
            wbx.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
            Encoding enc = Encoding.GetEncoding("UTF-8");
            Byte[] pageData = wbx.DownloadData(StateTaxationConstants.SichuanGet);

            string re = enc.GetString(pageData);
            CookieStr = wbx.ResponseHeaders["Set-Cookie"].ToString();
            return CookieStr;
        }
        private static string GetChongqingMethod()
        {
            // GET
            WebClient wbx = new WebClient();
            //HttpClient client = new HttpClient();
            //wbx.BaseAddress = StateTaxationConstants.Sichuan;
            //wbx.BaseAddress = StateTaxationConstants.Sichuan;Accept:*/*
            wbx.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            wbx.Headers.Add("Upgrade-Insecure-Requests", "1");
            wbx.Headers.Add("X-DevTools-Emulate-Network-Conditions-Client-Id", "69edf282-4b99-4b92-8607-d5b7cd38f43f");
            wbx.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
            wbx.Headers.Add("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
            wbx.Headers.Add("Referer", "http://wsbs.sc-n-tax.gov.cn/fpcy/init.htm");
            wbx.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            wbx.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
            Encoding enc = Encoding.GetEncoding("UTF-8");
            wbx.DownloadFile(StateTaxationConstants.ChongqingGet, @"D:/code.png");//Byte[] pageData = 

            var cookieStrin = wbx.ResponseHeaders[""];
            CookieStr = wbx.ResponseHeaders["Set-Cookie"].ToString();
            //File storeFile = new File("c:/2008sohu.gif");
            //FileOutputStream output = new FileOutputStream(storeFile);
            ////得到网络资源的字节数组,并写入文件    
            //output.write(getMethod.getResponseBody());
            //output.close();
            //InputStreamReader is = new InputStreamReader(System.in);
            //BufferedReader br = new BufferedReader(is);
            //String ValidCode = "";
            //try
            //{
            //    ValidCode = br.readLine();
            //    br.close();
            //is.close();
            //}
            //catch (Exception e)
            //{
            //    e.printStackTrace();
            //}
            return CookieStr;


            //string re = enc.GetString(pageData);
            //var CookieStr = wbx.ResponseHeaders["Set-Cookie"].ToString();
            //return CookieStr;
        }

        private static string GetHenanMethod()
        {
            WebClient wbx = new WebClient();
            wbx.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            wbx.Headers.Add("Upgrade-Insecure-Requests", "1");
            wbx.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
            wbx.Headers.Add("Accept-Encoding", "gzip, deflate");
            wbx.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
            Encoding enc = Encoding.GetEncoding("UTF-8");
            wbx.DownloadFile(StateTaxationConstants.HenanGet, $@"{CurrentPath}/Vcode/Vcode.png");
            CookieStr = wbx.ResponseHeaders["Set-Cookie"].ToString();
            return CookieStr;
        }
        private static string GetHenanPostMethod(string vcode)
        {
            WebClient wbx = new WebClient();
            wbx.Headers.Add("Accept", "application/json, text/javascript, */*");
            wbx.Headers.Add("Origin", "http://bsfwt.12366.ha.cn");
            wbx.Headers.Add("X-Requested-With", "XMLHttpRequest");
            wbx.Headers.Add("X-DevTools-Emulate-Network-Conditions-Client-Id", "69edf282-4b99-4b92-8607-d5b7cd38f43f");
            wbx.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
            wbx.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            wbx.Headers.Add("Referer", "http://bsfwt.12366.ha.cn/bsfwt/wsbsfwt/sscx/fpzwcx/fpzwcx_ppzl.html");
            wbx.Headers.Add("Accept-Encoding", "gzip, deflate");
            wbx.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
            wbx.Headers.Add("Cookie", CookieStr);
            wbx.Encoding = Encoding.UTF8;

            Encoding enc = Encoding.GetEncoding("UTF-8");
            string vCode = vcode;
            StringBuilder sb = new StringBuilder();
            sb.Append(HttpUtility.UrlEncode("ACTION"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("getFpzw"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("FPDM"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("141001620043"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("FPHM"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("09767750"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("NSRSBH"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("92410300MA3XG28Q9U"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("rcode"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode(vCode));
            var result = wbx.UploadString(StateTaxationConstants.HenanPost, "POST", sb.ToString());

            return result;
        }

        private static string GetTianjinMethod()
        {
            // GET
            WebClient wbx = new WebClient();
            //HttpClient client = new HttpClient();
            //wbx.BaseAddress = StateTaxationConstants.Sichuan;
            //wbx.BaseAddress = StateTaxationConstants.Sichuan;Accept:*/*
            wbx.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            wbx.Headers.Add("Upgrade-Insecure-Requests", "1");
            wbx.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
            wbx.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            wbx.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
            wbx.DownloadFile(StateTaxationConstants.TianjinGet, @"D:\SourceCode\WebDemoAsp\WebDemoAsp\Vcode\Vcode.png");
            CookieStr = wbx.ResponseHeaders["Set-Cookie"].ToString();
            return CookieStr;
        }
        private static string GetTianjinPostMethod(string vcode)
        {
            WebClient wbx = new WebClient();
            wbx.Headers.Add("Accept", "application/json, text/javascript, */*");
            wbx.Headers.Add("Origin", "http://fpxxbd.tjsat.gov.cn:8001");
            wbx.Headers.Add("X-Requested-With", "XMLHttpRequest");
            wbx.Headers.Add("X-DevTools-Emulate-Network-Conditions-Client-Id", "87b42e78-7b13-4739-ba86-e57657d5bf2d");
            wbx.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
            wbx.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            wbx.Headers.Add("Referer", "http://bsfwt.12366.ha.cn/bsfwt/wsbsfwt/sscx/fpzwcx/fpzwcx_ppzl.html");
            wbx.Headers.Add("Accept-Encoding", "gzip, deflate");
            wbx.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
            wbx.Headers.Add("Cookie", CookieStr);
            wbx.Encoding = Encoding.UTF8;
            //wbx.ResponseHeaders.Add("Content-Type", "text/html; charset=utf-8;");
            Encoding enc = Encoding.GetEncoding("UTF-8");
            string vCode = vcode;
            StringBuilder sb = new StringBuilder();
            sb.Append(HttpUtility.UrlEncode("fpDm"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("012001600111"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("fpHm"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("10645196"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("invoiceType"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("TypeJ"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("je"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("36.7"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("kpRq"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("2017-03-09"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("kpje"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("37.80"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("nsrmc"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("滴滴出行科技有限公司"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("vcode"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode($"{vCode}"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("nsrsbh"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("911201163409833307"));
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode("se"));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode("1.1"));
            //var data = new NameValueCollection();
            //data.Add("fpDm", "012001600111");
            //data.Add("fpHm", "10645196");
            //data.Add("invoiceType", "TypeJ");
            //data.Add("je", "36.7");
            //data.Add("kpRq", "2017-03-09");
            //data.Add("kpje", "37.80");
            //data.Add("nsrmc", "滴滴出行科技有限公司");
            //data.Add("nsrsbh", "911201163409833307");
            //data.Add("se", "1.1");
            //data.Add("vcode", vCode);
            //var byteResult = wbx.UploadValues(StateTaxationConstants.TianjinPost, "POST", data); 
            //、var result = Encoding.UTF8.GetString(byteResult);
            var result = wbx.UploadString(StateTaxationConstants.TianjinPost, "POST", sb.ToString());
            //string 
            //byte[] utf8 = Encoding.UTF8.GetBytes(byteResult);

            return result;
        }
    }
}
