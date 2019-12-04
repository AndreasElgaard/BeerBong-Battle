﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TodoREST.Models;
using Xamarin.Forms.Internals;

namespace TodoREST
{
	public interface IRestService
	{
		Task<List<OnlineLeaderboard>> RefreshDataAsync ();

        Task<bool> GetLoginDataAsync(LoginUser login);

        Task<bool> QueueGetPlayer(QueueModstander modstander);

        Task SaveOpretBrugerAsync(RegisterUser bruger);

        Task PushTimes(int id);

        Task<List<GameResult>> GetGameResult(int id);

        Task<Game> CreateGame(Game game);

        Task AddPlayerToGame(Game game);

        Task AddStats(Stats stat);

        Task<List<WebsocketData>> GetWebsocketData();

    }
}
