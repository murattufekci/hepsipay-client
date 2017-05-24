using System.Collections.Generic;
using System.Net;

namespace HepsiPay.Client
{
    public interface IApiBase   
    {
        /// <summary>
        /// Gets the response object.
        /// </summary>
        /// <typeparam name="T">Target type of return object</typeparam>
        /// <param name="response">The response.</param>
        /// <returns>T.</returns>
        T GetResponseObject<T>(WebResponse response);

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
        TK MakeApiRequest<T, TK>(
            T request,
            string url,
            Dictionary<string, string> headers,
            string contentType = "application/json",
            string method = "POST");

        /// <summary>
        /// Creates the sha 256 hash.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        string CreateSHA256Hash(string value);
    }
}