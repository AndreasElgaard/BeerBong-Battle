using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoREST
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public List<BrugerTest> Items { get;  set; }
        public List<OnlineLeaderboard> LeaderboardTider { get; set; }

        public List<OpretBrugerModel> Logins { get; set; }

        public RestService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            _client = new HttpClient(clientHandler);
        }

        public async Task<List<OnlineLeaderboard>> RefreshDataAsync()
        {
            LeaderboardTider = new List<OnlineLeaderboard>();
            
            
            var uri = new Uri(string.Format(Constants.TestBaseAddress, string.Empty));
            try
            {
                var response = await _client.GetAsync("https://my-json-server.typicode.com/MathiasTP/apileaderboard/tider");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LeaderboardTider = JsonConvert.DeserializeObject<List<OnlineLeaderboard>>(content);
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return LeaderboardTider;
            
        }

        public async Task<List<OpretBrugerModel>> GetLoginDataAsync()
        {
            Logins = new List<OpretBrugerModel>();


            //var uri = new Uri(string.Format(Constants.TestBaseAddress, string.Empty));

            try
            {
                var response = await _client.GetAsync("https://my-json-server.typicode.com/MathiasTP/apitest1/logins")
                    .ConfigureAwait(false);
                
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                Logins = JsonConvert.DeserializeObject<List<OpretBrugerModel>>(content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Logins;
        }


        public async Task SaveTodoItemAsync(BrugerTest item, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.TodoItemsUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task SaveOpretBrugerAsync(OpretBrugerModel bruger, bool isNewItem)
        {
            var uri = new Uri(string.Format(Constants.TodoItemsUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(bruger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tBruger er oprettet");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }


        public async Task DeleteTodoItemAsync(string id)
        {
            var uri = new Uri(string.Format(Constants.TodoItemsUrl, id));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
