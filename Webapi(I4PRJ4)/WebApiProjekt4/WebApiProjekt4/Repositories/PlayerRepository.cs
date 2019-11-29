using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApiProjekt4.options;
using Microsoft.Extensions.Options;
using WebApiProjekt4.Controllers.Responses;
using WebApiProjekt4.Data.Dto;

namespace WebApiProjekt4.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(DataContext context) : base(context)
        {
        }
        public async Task<Player> AddStats(int playerid, int StatsId)
        {
            var updatedPlayer = await DataContext.Players
                .Include(p => p.Stats)
                .SingleAsync(p => p.PlayerId == playerid);

            if(updatedPlayer == null)
            {
                return null;
            }

            var Stats = await DataContext.Stats.FindAsync(StatsId);

            if(Stats == null)
            {
                return null;
            }

            updatedPlayer.Stats.Add(Stats);

            return updatedPlayer;
        }

        public async Task<IEnumerable<PlayerStatsResult>> GetStats(int playerid)
        {

            var player = await DataContext.Players
               .Include(p => p.Stats)
               .SingleAsync(p => p.PlayerId == playerid);

            if(player == null)
            {
                return null;
            }

            var Stats = new List<PlayerStatsResult>();

            Stats = player.Stats.Select(p => 
                new PlayerStatsResult
                {
                    DrinkingTime = p.DateTime,
                    Time = p.Time
                }).OrderBy(s => s.Time).ToList();

            return Stats;
        }

        public async Task<bool> PlayerOwnsStats(int playerid, string userid)
        {
            var player = await DataContext.Players
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.PlayerId == playerid);

            if(player == null)
            {
                return false;
            }

            if(player.UserId != userid)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DoesPlayerExists(string userid)
        {
            var player = await DataContext.Players
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.UserId == userid);

            if (player == null)
            {
                return true;
            }

            return false;
        }

        public async Task<Player> GetplayerId(string userId)
        {
            var player = await DataContext.Players
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.UserId == userId);

            if (player == null)
            {
                return null;
            }


            return player;
        }


        public DataContext DataContext
        {
            get { return _context as DataContext; }
        }
    }
}
