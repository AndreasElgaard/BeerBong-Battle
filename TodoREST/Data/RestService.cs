using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TodoREST.Models;
using Xamarin.Forms.Internals;

namespace TodoREST
{
    public class RestService : IRestService
    {
        HttpClient _client;

        
        public List<OnlineLeaderboard> LeaderboardTider { get; set; }

        

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

        public async Task<bool> GetLoginDataAsync(LoginUser login)
        {
            bool status = false;
            try
            {
                var json = JsonConvert.SerializeObject(login);
                var content = new StringContent(json, Encoding.UTF8, "application/json");


                HttpResponseMessage response = null;
                response = await _client.PostAsync(
                    "https://webapiprojekt420191120040352.azurewebsites.net/api/Identity/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonlogin = await response.Content.ReadAsAsync<LoginResponse>();
                    App.Token = jsonlogin.token;
                     status = true;
                }
                else
                {
                    status = false;
                }
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return status;
        }


        public async Task SaveOpretBrugerAsync(RegisterUser bruger)
        {
            try
            {
                var json = JsonConvert.SerializeObject(bruger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                
                response = await _client.PostAsync("https://webapiprojekt420191120040352.azurewebsites.net//api/Identity/Register", content);


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
