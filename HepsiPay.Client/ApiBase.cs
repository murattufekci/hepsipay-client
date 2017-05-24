using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace HepsiPay.Client
{
    public abstract class ApiBase : IApiBase
    {        
        /// <summary>
        /// Gets the response object.
        /// </summary>
        /// <typeparam name="T">Target type of return object</typeparam>
        /// <param name="response">The response.</param>
        /// <returns>T.</returns>
        public virtual T GetResponseObject<T>(WebResponse response)
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var responseFromServer = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            response.Close();
            response.Dispose(); ;
            return JsonConvert.DeserializeObject<T>(responseFromServer);
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <param name="headers">The request headers.</param>
        /// <param name="contentType">The content type of request.</param>
        /// <param name="method">The http method.</param>
        /// <returns>WebResponse.</returns>
        protected virtual WebResponse GetResponse(string url,
            string data,
            Dictionary<string, string> headers,
            string contentType = "application/json",
            string method = "POST")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            request.KeepAlive = true;
            request.Headers.Add("Keep-Alive: 300");
            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    request.Headers.Add(key, headers[key]);
                }
            }
            request.Method = method;
            if (method != "GET" && !string.IsNullOrEmpty(data))
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(data);
                request.ContentType = contentType;
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                dataStream.Dispose();
            }
            try
            {
                return request.GetResponse();
            }
            catch (WebException e)
            {
                return (HttpWebResponse)e.Response;
            }
        }

        /// <summary>
        /// Generates the base64 hash.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns>System.String.</returns>
        protected virtual string GenerateBase64Hash(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Does the API request.
        /// </summary>
        /// <typeparam name="T">The type of Request</typeparam>
        /// <typeparam name="TK">The type of Response.</typeparam>
        /// <param name="request">The request object</param>
        /// <param name="url">The Url of Request</param>
        /// <param name="headers">The headers.</param>
        /// <param name="contentType">Content type of request</param>
        /// <param name="method">Http method of request</param>
        /// <returns>TK.</returns>
        public virtual TK MakeApiRequest<T, TK>(
            T request,
            string url,
            Dictionary<string, string> headers,
            string contentType = "application/json",
            string method = "POST")
        {
            string requestJson = JsonConvert.SerializeObject(request);
            var response = GetResponse(url, requestJson, headers, contentType, method);
            return GetResponseObject<TK>(response);
        }

        /// <summary>
        /// Creates the sha 256 hash.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public virtual string CreateSHA256Hash(string value)
        {
            using (SHA256 hash = SHA256.Create())
            {
                return String.Join("", hash
                    .ComputeHash(Encoding.UTF8.GetBytes(value))
                    .Select(item => item.ToString("x2")));
            }
        }
    }
}