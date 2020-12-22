using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers
{
    public class HttpResponseWrapper<T>
    {
        public bool Sucess { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public HttpResponseWrapper(T response, bool success, HttpResponseMessage httpResponseMessage) 
        {
            Sucess = success;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        /// <summary>
        /// A method to access error text when the Http Request is not sucessful.
        /// </summary>
        /// <returns>string</returns>
        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
