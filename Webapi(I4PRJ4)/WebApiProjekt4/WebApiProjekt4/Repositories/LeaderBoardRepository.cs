using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiProjekt4.Controllers.Responses;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.Dto;

namespace WebApiProjekt4.Repositories
{
    public class LeaderBoardRepository : Repository<LeaderBoard>, ILeaderBoardRepository
    {
        public LeaderBoardRepository(DataContext context) : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return _context as DataContext; }
        }

        public async Task<IEnumerable<TopTimes>> GetTopTimes()
        {
            var Items = await DataContext.LeaderBoards
                .Include(p => p.Players)
                    .ThenInclude(p => p.identityUser)
                .Include(p => p.Players)
                    .ThenInclude(s => s.Stats)
                .FirstAsync();

            var Top = new List<TopTimes>();

            foreach (var player in Items.Players)
            {
                Top.Add(player.Stats.Select(s =>
                new TopTimes
                {
                    UserName = player.identityUser.UserName,
                    Time = s.Time,
                    DateTime = s.DateTime

                }).OrderBy(s => s.Time).First());
            }

            var Topresult = Top.OrderBy(t => t.Time);

            return Topresult;
        }

        public async Task<LeaderBoard> InsertPlayer(int playerId)
        {
            var updatedLeaderboard = await DataContext.LeaderBoards
                .Include(p => p.Players)
                .FirstAsync();

            var player = await DataContext.Players.FindAsync(playerId);

            if (player == null)
            {
                return null;
            }

            updatedLeaderboard.Players.Add(player);


            return updatedLeaderboard;
        }
    }
}
