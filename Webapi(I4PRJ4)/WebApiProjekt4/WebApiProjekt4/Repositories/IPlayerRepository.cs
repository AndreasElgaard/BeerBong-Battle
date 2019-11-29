using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjekt4.Controllers.Responses;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.Dto;

namespace WebApiProjekt4.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<Player> AddStats(int id, int statid);
        Task<IEnumerable<PlayerStatsResult>> GetStats(int playerid);
        Task<bool> PlayerOwnsStats(int playerid, string userid);
        Task<bool> DoesPlayerExists(string userid);
        Task<Player> GetplayerId(string userid);
    }
}
