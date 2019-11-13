using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

		public Task<List<TodoItem>> GetTasksAsync ()
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

        public Task SaveOpretBruger(OpretBrugerModel item, bool isNewItem = false)
        {
            return restService.SaveOpretBrugerAsync(item, isNewItem);
        }

        public Task DeleteTaskAsync (BrugerTest item)
		{
			return restService.DeleteTodoItemAsync (item.brugerid.ToString());
		}

      
    }
}
