using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TodoREST.Models;

namespace TodoREST.Data
{
    public class RestServicePlayer : IRestServicePlayer
    {
        HttpClient _client;

        public RestServicePlayer()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            _client = new HttpClient(clientHandler);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
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

        public async Task<int> GetPlayerId(Player player)
        {
            player = new Player();


            var uri = new Uri(string.Format(Constants.TestBaseAddress, string.Empty));
            try
            {
                var response = await _client.GetAsync("https://webapiprojekt420191125022155.azurewebsites.net/api/Players/GetPlayerId");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    player = JsonConvert.DeserializeObject<Player>(content);
                    App.player.PlayerId = player.PlayerId;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return player.PlayerId;

        }

    }
}