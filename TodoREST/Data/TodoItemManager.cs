using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoREST.Data;
using TodoREST.Models;

namespace TodoREST
{
	public class TodoItemManager
	{
		IRestService restService;
        private IRestServicePlayer restServicePlayer;
       

        public TodoItemManager (IRestService service, IRestServicePlayer player)
		{
			restService = service;
            restServicePlayer = player;
        }

		

        public Task<List<OnlineLeaderboard>> GetOnlineLeaderboardAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task<bool> GetLoginDataAsync(LoginUser login)
        {
            return restService.GetLoginDataAsync(login);
        }

        public Task<bool> GetFirstPlayerInQueue(QueueModstander modstander)
        {
            return restService.QueueGetPlayer(modstander);
        }
		

        public Task SaveOpretBruger(RegisterUser item)
        {
            return restService.SaveOpretBrugerAsync(item);
        }


        public Task<List<WebsocketData>> GetWebsocketData()
        {
            return restService.GetWebsocketData();
        }

        public Task PushStats(Stats stats)
        {
            return restService.AddStats(stats);
        }

        public Task PushtoLeaderboard(int id)
        {
            return restService.PushTimes(id);
        }

        public Task<List<GameResult>> GetGameResult(int id)
        {
            return restService.GetGameResult(id);
        }
      
    }
}
