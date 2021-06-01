using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WpfApplication.Models;

namespace WpfApplication.ViewModel.Service
{
    public class DrugStoreService
    {
        public const string baseUrl = "https://localhost:44371/DrugStore";                

        public static async Task<List<DrugStore>> Get(int size, string drugStoreName)
        {
            var url = baseUrl + "?size=" + size + "&drugStoreName=" + drugStoreName;
            List<DrugStore> drugStores = new List<DrugStore>();

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = GetJsonOptions();

                drugStores = JsonSerializer.Deserialize<List<DrugStore>>(json, options);
            }

            return drugStores;
        }

        public static async Task<List<DrugStore>> GetByNeighborhood(int idNeighborhood, bool flg_round_the_clock)
        {
            var url = baseUrl + "/GetByNeighborhood?idNeighborhood=" + idNeighborhood + "&flg_round_the_clock=" + flg_round_the_clock;
            List<DrugStore> drugStores = new List<DrugStore>();

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = GetJsonOptions();
                drugStores = JsonSerializer.Deserialize<List<DrugStore>>(json, options);
            }

            return drugStores;
        }

        public static async Task<DrugStore> GetById(int id)
        {
            var url = baseUrl + "/GetById?id=" + id ;
            DrugStore drugStore = new DrugStore();

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = GetJsonOptions();
                drugStore = JsonSerializer.Deserialize<DrugStore>(json, options);
            }

            return drugStore;
        }

        public static async Task<bool> Post(DrugStore drugStore)
        {
            var result = false;
            var url = baseUrl;
            var json = JsonSerializer.Serialize(drugStore);
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

        public static async Task<DrugStore> Put(DrugStore drugStore)
        {
            var result = new DrugStore();
            var url = baseUrl;
            var json = JsonSerializer.Serialize(drugStore);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync(url, data);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                JsonSerializerOptions options = GetJsonOptions();

                result = JsonSerializer.Deserialize<DrugStore>(jsonResponse, options);
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

        public static async Task<bool> Delete(DrugStore drugStore)
        {
            var url = baseUrl + "/?id=" + drugStore.Id;
            var result = false;

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions options = GetJsonOptions();
                result = JsonSerializer.Deserialize<bool>(json, options);
            }

            return result;
        }

        
    }
}
