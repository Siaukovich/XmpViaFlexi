﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace VacationsTracker.Core.DataAccess
{
    internal class VacationContext : IVacationContext
    {
        private readonly IRestClient _client;

        public VacationContext(ISecureStorage _storage)
        {
            var token = _storage.GetAsync(Settings.TokenStorageKey).Result;
            _client = new RestClient
            {
                BaseUrl = new Uri(Settings.VacationApiUrlLocal),
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer")
            };
        }

        public async Task<TResponse> GetAsync<TResponse>(string resource) 
            where TResponse : new()
        {
            var request = new RestRequest(resource);
            var response = await _client.GetAsync<TResponse>(request);

            return response;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string resource, TRequest requestBody) 
            where TResponse : new()
        {
            var request = GetRequest(resource, requestBody);
            var response = await _client.PostAsync<TResponse>(request);

            return response;
        }

        private static RestRequest GetRequest<TRequest>(string url, TRequest requestBody)
        {
            var request = new RestRequest(url);

            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(requestBody);

            return request;
        }
    }
}
