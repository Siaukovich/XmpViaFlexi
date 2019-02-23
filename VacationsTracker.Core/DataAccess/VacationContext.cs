using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace VacationsTracker.Core.DataAccess
{
    internal class VacationContext : IVacationContext
    {
        private readonly HttpClient _client;

        public VacationContext(ISecureStorage storage)
        {
            var token = storage.GetAsync(Settings.TokenStorageKey).Result;

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<TResponse> GetAsync<TResponse>(string resource, CancellationToken token = default) 
            where TResponse : new()
        {
            token.ThrowIfCancellationRequested();

            var request = GetRequest(resource, HttpMethod.Get);

            var responseObj = await SendRequest<TResponse>(request, token);

            return responseObj;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(
            string resource, 
            TRequest requestBody,
            CancellationToken token = default) 
                where TResponse : new()
        {
            token.ThrowIfCancellationRequested();

            var request = GetRequest(resource, HttpMethod.Post, requestBody);

            var responseObj = await SendRequest<TResponse>(request, token);

            return responseObj;
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string resource, CancellationToken token = default) where TResponse : new()
        {
            token.ThrowIfCancellationRequested();

            var request = GetRequest(resource, HttpMethod.Delete);

            var responseObj = await SendRequest<TResponse>(request, token);

            return responseObj;
        }

        private static HttpRequestMessage GetRequest(string resource, HttpMethod method)
        {
            var requestUri = Settings.VacationApiUrl + resource;
            var request = new HttpRequestMessage(method, requestUri);

            return request;
        }

        private static HttpRequestMessage GetRequest<TRequest>(string resource, HttpMethod method, TRequest requestBody)
        {
            var requestUri = Settings.VacationApiUrl + resource;
            var request = new HttpRequestMessage(method, requestUri);

            var jsonBody = JsonConvert.SerializeObject(requestBody);
            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            return request;
        }

        private async Task<TResponse> SendRequest<TResponse>(HttpRequestMessage request, CancellationToken token = default)
        {
            var response = await _client.SendAsync(request, token);
            var content = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<TResponse>(content);

            return responseObj;
        }
    }
}
