using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoREST
{
	public class TodoItemManager
	{
		IRestService restService;

		public TodoItemManager (IRestService service)
		{
			restService = service;
		}

		public Task<List<BrugerTest>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}

		public Task SaveTaskAsync (BrugerTest item, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync (item, isNewItem);
		}

		public Task DeleteTaskAsync (BrugerTest item)
		{
			return restService.DeleteTodoItemAsync (item.brugerid.ToString());
		}
	}
}
