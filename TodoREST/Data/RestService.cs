using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
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
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
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
                    "https://webapiprojekt420191125022155.azurewebsites.net/api/Identity/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonlogin = await response.Content.ReadAsAsync<LoginResponse>();
                    App.Token = jsonlogin.token;
                     status = true;
                     _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
                    var player = new Player();
                     await AddPlayer(player);
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

        public async Task AddPlayer(Player player)
        {
            var json = JsonConvert.SerializeObject(player);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            
            try
            {
                response = await _client.PostAsync(
                    "https://webapiprojekt420191125022155.azurewebsites.net/api/Players/Add", content);
                var jsonlogin = await response.Content.ReadAsAsync<Player>();
                App.player = jsonlogin;


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task QueueGetPlayer(QueueModstander modstander)
        {
            var json = JsonConvert.SerializeObject(modstander);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;

            try
            {
                response = await _client.GetAsync("https://webapiprojekt420191125022155.azurewebsites.net/api/Queue/GetFirstPlayer");
                if (response.IsSuccessStatusCode)
                {
                    var jsonlogin = await response.Content.ReadAsAsync<QueueModstander>();
                    App.modstander = jsonlogin;
                    await CreateGame(App.game);
                    
                    await AddPlayerToGame(App.game);
                    await RemovePlayerQueue();
                }
                else
                {
                   response = await _client.PostAsync("https://webapiprojekt420191125022155.azurewebsites.net/api/Queue/AddPlayer?PlayerId=" + App.player.PlayerId, content);
                   var jsonlogin = await response.Content.ReadAsAsync<QueueModstander>();
                }
                


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public async Task SaveOpretBrugerAsync(RegisterUser bruger)
        {
            try
            {
                var json = JsonConvert.SerializeObject(bruger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                
                response = await _client.PostAsync("https://webapiprojekt420191125022155.azurewebsites.net/api/Identity/Register", content);


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

        public async Task CreateGame(Game game)
        {
            try
            {
                var json = JsonConvert.SerializeObject(game);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await _client.PostAsync("https://webapiprojekt420191125022155.azurewebsites.net/api/Game/Add", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\t Game er oprettet");
                }

                var jsonlogin = await response.Content.ReadAsAsync<Game>();
                App.game = jsonlogin;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task RemovePlayerQueue()
        {
            HttpResponseMessage response = null;
            var json = JsonConvert.SerializeObject(App.modstander.Playerid);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                response = await _client.PutAsync(
                    "https://webapiprojekt420191125022155.azurewebsites.net/api/Queue/RemovePlayer?playerId=" +
                    App.modstander.Playerid, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Player slettet fra queue");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
        }

        public async Task AddPlayerToGame(Game game)
        {
            var uri = new Uri($"https://webapiprojekt420191125022155.azurewebsites.net/api/Game/AddPlayerToGame?gameid={App.game.gameId}&player1id={App.player.PlayerId}&player2id={App.modstander.Playerid}");
            try
            {
                var json = JsonConvert.SerializeObject(game);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                
                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\t Game er oprettet");
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

        }
    }
}
