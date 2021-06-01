using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WpfApplication.Models;

namespace WpfApplication.ViewModel.Service
{
    public class NeighborhoodService
    {
        public const string baseUrl = "https://localhost:44371/Neighborhood";

        public static async Task<List<Neighborhood>> Get(string neighborhoodSearch, int size = 1000)
        {
            var url = baseUrl + "?neighborhoodSearch=" + neighborhoodSearch + "&size=" + size ;
            List<Neighborhood> neighborhoods = new List<Neighborhood>();

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = GetJsonOptions();
                neighborhoods = JsonSerializer.Deserialize<List<Neighborhood>>(json, options);
            }

            return neighborhoods;
        }

        public static async Task<bool> Post(Neighborhood neighborhood)
        {
            var result = false;
            var url = baseUrl;
            var json = JsonSerializer.Serialize(neighborhood);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(url, data);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = GetJsonOptions();
                result = JsonSerializer.Deserialize<bool>(jsonResponse, options);
            }

            return result;
        }

        private static JsonSerializerOptions GetJsonOptions()
        {
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());
            return options;
        }
    }
}
