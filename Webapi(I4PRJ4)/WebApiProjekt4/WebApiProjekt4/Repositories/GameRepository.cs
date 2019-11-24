using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.Dto;

namespace WebApiProjekt4.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(DataContext context) : base(context)
        {
        }

        public async Task<Game> AddUserToGame(int id, int player1Id, int player2Id)
        {

            var Updatedgame = await DataContext.Games
                .Include(g => g.Players)
                .SingleAsync(g => g.GameId == id);

            if(Updatedgame == null)
            {
                return null;
            }

            var player1 = await DataContext.Players.FindAsync(player1Id);

            if(player1 == null)
            {
                return null;
            }

            var player2 = await DataContext.Players.FindAsync(player2Id);

            if(player2 == null)
            {
                return null;
            }

            Updatedgame.Players.Add(player1);

            Updatedgame.Players.Add(player2);

            return Updatedgame;
        }

        public async Task<IEnumerable<GameWinnerResult>> Winner(int Gameid)
        {
            var game = await DataContext.Games
                .Include(g => g.Players)
                    .ThenInclude(p => p.Stats)
                .SingleAsync(g => g.GameId == Gameid);

            var latest = new List<GameWinnerResult>();

            foreach (var player in game.Players)
            {
                latest.Add (player.Stats.Select(s =>
                new GameWinnerResult
                {
                    Playerid = s.PlayerId,
                    Time = s.Time,
                    DateTime = s.DateTime
                }).OrderBy(s => s.Time).First());
            }


            return latest;
        }

        public DataContext DataContext
        {
            get { return _context as DataContext; }
        }


    }
}
