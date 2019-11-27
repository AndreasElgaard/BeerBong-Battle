using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjekt4.Controllers.Responses;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.Dto;
using WebApiProjekt4.Data.EFCore;

namespace WebApiProjekt4.Repositories
{
    public interface ILeaderBoardRepository : IRepository<LeaderBoard>
    {
        Task<IEnumerable<TopTimes>> GetTopTimes();
        Task<LeaderBoard> InsertPlayer(int playerId);
    }
}
