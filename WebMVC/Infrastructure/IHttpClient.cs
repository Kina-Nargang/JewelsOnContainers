using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string uri,
            string authorizationToken = null,
            string authorizationMethod = "Bearer");

        // HttpRequestMessage gives the response status back (200,404,...)
        Task<HttpResponseMessage> PostAsync<T>(string uri,
            T item,
            string authorizationToken = null,
            string authorizationMethod = "Bearer");

        Task<HttpRequestMessage> PutAsync<T>(string uri,
            T item,
            string authorizationToken = null,
            string authorizationMethod = "Bearer");

        Task<HttpRequestMessage> DeleteAsync<T>(string uri,
            T item,
            string authorizationToken = null,
            string authorizationMethod = "Bearer");
    }
}
