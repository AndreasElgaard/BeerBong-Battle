using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoREST
{
	public interface IRestService
	{
		Task<List<BrugerTest>> RefreshDataAsync ();

		Task SaveTodoItemAsync (BrugerTest item, bool isNewItem);

		Task DeleteTodoItemAsync (string id);
	}
}
