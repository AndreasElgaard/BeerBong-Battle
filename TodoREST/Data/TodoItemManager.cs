using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoREST.Models;

namespace TodoREST
{
	public class TodoItemManager
	{
		IRestService restService;
       

        public TodoItemManager (IRestService service)
		{
			restService = service;
		}

		

        public Task<List<OnlineLeaderboard>> GetOnlineLeaderboardAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task<bool> GetLoginDataAsync(LoginUser login)
        {
            return restService.GetLoginDataAsync(login);
        }

        public Task GetFirstPlayerInQueue(QueueModstander modstander)
        {
            return restService.QueueGetPlayer(modstander);
        }
		

        public Task SaveOpretBruger(RegisterUser item)
        {
            return restService.SaveOpretBrugerAsync(item);
        }

       

      
    }
}
