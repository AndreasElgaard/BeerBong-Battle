using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoREST.Models;

namespace TodoREST
{
	public class TodoItemManager
	{
		IRestService restService;
        public List<BrugerTest> LoginList { get; private set; }

        public TodoItemManager (IRestService service)
		{
			restService = service;
		}

		

        public Task<List<OnlineLeaderboard>> GetOnlineLeaderboardAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task<List<OpretBrugerModel>> GetLoginDataAsync()
        {
            return restService.GetLoginDataAsync();
        }

		public Task SaveTaskAsync (BrugerTest item, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync (item, isNewItem);
		}

        public Task SaveOpretBruger(RegisterUser item)
        {
            return restService.SaveOpretBrugerAsync(item);
        }

        public Task DeleteTaskAsync (BrugerTest item)
		{
			return restService.DeleteTodoItemAsync (item.brugerid.ToString());
		}

      
    }
}
