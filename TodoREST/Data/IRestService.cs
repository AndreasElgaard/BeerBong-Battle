using System.Collections.Generic;
using System.Threading.Tasks;
using TodoREST.Models;

namespace TodoREST
{
	public interface IRestService
	{
		Task<List<OnlineLeaderboard>> RefreshDataAsync ();

        Task<List<OpretBrugerModel>> GetLoginDataAsync();

        Task SaveTodoItemAsync (BrugerTest item, bool isNewItem);

        Task SaveOpretBrugerAsync(RegisterUser bruger);

		Task DeleteTodoItemAsync (string id);
	}
}
