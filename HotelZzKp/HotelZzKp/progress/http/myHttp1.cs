using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
namespace HotelZzKp
{
    class myHttp1
    {
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
        /// 创建POST方式的HTTP请求  
        public static HttpWebResponse CreateHttpResponse(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            request.ReadWriteTimeout = 3000;
            request.Timeout = 30 * 1000;
            request.ContentLength = 0; //解决了远程服务器返回错误: (411) 所需的长度的问题；问题原因是POST发送方式需要参数的填写
            return request.GetResponse() as HttpWebResponse;

        }
    }
}
