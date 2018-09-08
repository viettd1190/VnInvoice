using System.Collections.Generic;
using System.IO;
using System.Net;
using vnyi.HaLinh.Enums;
using vnyi.HaLinh.Models;

namespace vnyi.HaLinh
{
    public class AppUtil
    {
        public static Dictionary<string,UserToken> UserTokens=new Dictionary<string, UserToken>();

        public static string CreateRequest(string url,
                                           string data,
                                           string token,
                                           MethodType method = MethodType.POST,
                                           string contentType = "application/json")
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            httpWebRequest.ContentType = contentType;
            switch (method)
            {
                case MethodType.POST:
                    httpWebRequest.Method = "POST";
                    break;
                case MethodType.PUT:
                    httpWebRequest.Method = "PUT";
                    break;
                case MethodType.GET:
                    httpWebRequest.Method = "GET";
                    break;
                case MethodType.DELETE:
                    httpWebRequest.Method = "DELETE";
                    break;
                default:
                    httpWebRequest.Method = "POST";
                    break;
            }

            if(!string.IsNullOrEmpty(token))
            {
                httpWebRequest.Headers.Add("Authorization",
                                           "Bearer " + token);
            }
            
            httpWebRequest.Proxy = new WebProxy(); //no proxy

            if(!string.IsNullOrEmpty(data))
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = data;

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            string result = string.Empty;
            if(httpResponse.GetResponseStream() != null)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }

            return result;
        }
    }
}
