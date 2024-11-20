using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using UTBDesktopApp.Helpers;
using UTBDesktopApp.Models;

namespace UTBDesktopApp.Services
{
    public class DbService : IDbService
    {
        HttpClient client;

        public DbService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Constants.ServerUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue
                ("application/json"));
        }


        public async Task<bool> Add<T>(string endpoint, T s)
        {
            var response = await
                client.PostAsJsonAsync(endpoint, s);

            return response.IsSuccessStatusCode;
        }

        public async Task<T> Get<T>(string endpoint, int id) where T : class
        {
            var fullEndpoint = endpoint + "/" + id;
            var response = await client.GetAsync(fullEndpoint);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.
                    ReadFromJsonAsync<T>();
                return data;
            }
            else
                return (default);
        }

        public async Task<List<T>> GetAll<T>(string endpoint) where T : class
        {
            var response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var data = await
                    response.Content
                    .ReadFromJsonAsync<List<T>>();

                return data;
            }
            else
                return (default);
        }
    }
}
