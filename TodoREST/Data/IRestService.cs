using System.Collections.Generic;
using System.Threading.Tasks;
using TodoREST.Models;
using Xamarin.Forms.Internals;

namespace TodoREST
{
	public interface IRestService
	{
		Task<List<OnlineLeaderboard>> RefreshDataAsync ();

        Task<bool> GetLoginDataAsync(LoginUser login);

        Task SaveOpretBrugerAsync(RegisterUser bruger);

		Task DeleteTodoItemAsync (string id);
	}
}
