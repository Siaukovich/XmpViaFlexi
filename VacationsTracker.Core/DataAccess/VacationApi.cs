using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VacationsTracker.Core.DataAccess
{
    internal class VacationApi : IVacationApi
    {
        private readonly HttpClient _client;

        public VacationApi()
        {
            _client = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _client.GetAsync(url);
            var jsonBody = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<T>(jsonBody);

            return obj;
        }

        public Task<T> PostAsync<T>(string url, T obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> DeleteAsync<T>(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}