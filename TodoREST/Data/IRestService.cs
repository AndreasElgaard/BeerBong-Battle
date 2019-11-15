using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoREST
{
	public interface IRestService
	{
		Task<List<OnlineLeaderboard>> RefreshDataAsync ();

        Task<List<OpretBrugerModel>> GetLoginDataAsync();

        Task SaveTodoItemAsync (BrugerTest item, bool isNewItem);

        Task SaveOpretBrugerAsync(OpretBrugerModel bruger, bool isNewItem);

		Task DeleteTodoItemAsync (string id);
	}
}
